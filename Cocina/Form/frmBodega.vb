Public Class frmBodega
    Dim aux As Integer = 0

    Sub cargarDatos()
        Using dbCocina As New CocinaDataContext
            Dim reg = From b In dbCocina.Bodegas Select b

            dgvBodega.DataSource = reg
        End Using
    End Sub
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        aux = 0
        dgvBodega.Enabled = False
        txtNombre.Enabled = True
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True
        btnBorrar.Enabled = False
        btnEditar.Enabled = False
        btnCancelar.Enabled = True
        txtNombre.Clear()
        txtNombre.Focus()
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        aux = 1
        dgvBodega.Enabled = True
        txtNombre.Enabled = True
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True
        btnBorrar.Enabled = False
        btnEditar.Enabled = False
        btnCancelar.Enabled = True
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        dgvBodega.Enabled = True
        txtNombre.Enabled = False
        btnNuevo.Enabled = True
        btnGuardar.Enabled = False
        btnBorrar.Enabled = True
        btnEditar.Enabled = True
        btnCancelar.Enabled = False
        cargarDatos()
        dgvBodega_SelectionChanged(sender, e)
    End Sub

    Private Sub frmBodega_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cargarDatos()
        diseñoDgv(dgvBodega)
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            Using dbCocina As New CocinaDataContext
                'Guardar registro
                If aux = 0 Then
                    Dim actB As New Bodegas With {.Nombre = txtNombre.Text}
                    dbCocina.Bodegas.InsertOnSubmit(actB)
                    Try
                        dbCocina.SubmitChanges()
                        MsgBox("Registro guardado exitosamente", MsgBoxStyle.Information, _
                               "Guardar Registro")
                    Catch ex As Exception
                        MsgBox("No se pudo guardar el registro, intente nuevamente o pongase en contacto con el administrador", _
                               MsgBoxStyle.Information, "Guardar Registro")
                    End Try
                End If
                'Editar registro
                If aux = 1 Then
                    Dim row As DataGridViewRow = dgvBodega.CurrentRow
                    Dim id As Integer = row.Cells(0).Value
                    Dim actB = (From b In dbCocina.Bodegas
                                Where b.IdBodega = id
                                Select b).First
                    actB.Nombre = txtNombre.Text
                    Try
                        dbCocina.SubmitChanges()
                        MsgBox("Registro modificado exitosamente", MsgBoxStyle.Information, _
                               "Editar Registro")
                    Catch ex As Exception
                        MsgBox("No se pudo editar el registro, intente nuevamente o pongase en contacto con el administrador", _
                               MsgBoxStyle.Information, "Editar Registro")
                    End Try
                End If
                btnCancelar_Click(sender, e)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvBodega_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvBodega.SelectionChanged
        Dim row As DataGridViewRow = dgvBodega.CurrentRow
        txtNombre.Text = row.Cells(1).Value
    End Sub

    Private Sub btnBorrar_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar.Click
        If MessageBox.Show("¿Eliminar registro de bodega del sistema?", "Eliminar bodega", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Using dbCocina As New CocinaDataContext
                Dim row As DataGridViewRow = dgvBodega.CurrentRow
                Dim id As Integer = row.Cells(0).Value
                Dim reg = (From b In dbCocina.Bodegas
                           Where b.IdBodega = id
                           Select b).Single
                dbCocina.Bodegas.DeleteOnSubmit(reg)
                Try
                    dbCocina.SubmitChanges()
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Eliminar registro")
                    cargarDatos()
                Catch ex As Exception
                    MsgBox("Error al intentar eliminar el registro", MsgBoxStyle.Critical, _
                           "Eliminar Registro")
                    btnCancelar_Click(sender, e)
                End Try
            End Using
        End If
    End Sub
End Class