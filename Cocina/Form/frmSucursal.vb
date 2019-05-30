Public Class frmSucursal
    Dim aux As Integer = 0
    Sub cargarDatos()
        Using dbCocina As New CocinaDataContext
            Dim reg = From s In dbCocina.Sucursal Select s

            dgvSucursal.DataSource = reg
        End Using
    End Sub
    Private Sub frmSucursal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cargarDatos()
        diseñoDgv(dgvSucursal)
    End Sub

    Private Sub txtFiltrar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltrar.TextChanged
        Using dbCocina As New CocinaDataContext
            dgvSucursal.DataSource = dbCocina.FiltrarSucursal(txtFiltrar.Text)
        End Using
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        aux = 0
        txtNombre.Enabled = True
        txtNombre.Clear()
        txtNombre.Focus()
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True
        btnEditar.Enabled = False
        btnBorrar.Enabled = False
        btnCancelar.Enabled = True
        dgvSucursal.Enabled = False
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        aux = 1
        txtNombre.Enabled = True
        txtNombre.Clear()
        txtNombre.Focus()
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True
        btnEditar.Enabled = False
        btnBorrar.Enabled = False
        btnCancelar.Enabled = True
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        dgvSucursal.Enabled = True
        txtNombre.Enabled = False
        btnNuevo.Enabled = True
        btnGuardar.Enabled = False
        btnEditar.Enabled = True
        btnBorrar.Enabled = True
        btnCancelar.Enabled = False
        cargarDatos()
        dgvSucursal_SelectionChanged(sender, e)
    End Sub

    Private Sub dgvSucursal_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvSucursal.SelectionChanged
        Try
            Dim row As DataGridViewRow = dgvSucursal.CurrentRow
            txtNombre.Text = row.Cells(1).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If txtNombre.Text = "" Then
                MsgBox("El nombre no puede ser vacio, intente nuevamente", MsgBoxStyle.Information, _
                       "Nueva sucursal")
                Return
            End If
            Using dbCocina As New CocinaDataContext
                'Guardar sucursal
                If aux = 0 Then
                    Dim nSuc As New Sucursal With {.Nombre = txtNombre.Text}
                    dbCocina.Sucursal.InsertOnSubmit(nSuc)
                    Try
                        dbCocina.SubmitChanges()
                        MsgBox("Sucursal ingresada al sistema", MsgBoxStyle.Information, _
                               "Nueva sucursal")
                    Catch ex As Exception
                        If MsgBox("Error al intentar guardar, ¿Volver a intentar?", MsgBoxStyle.YesNo, _
                               "Nueva sucursal") = MsgBoxResult.Yes Then
                            dbCocina.SubmitChanges()
                        Else
                            Return
                        End If

                    End Try
                End If
                'Editar sucursal
                If aux = 1 Then
                    Dim row As DataGridViewRow = dgvSucursal.CurrentRow
                    Dim id As Integer = row.Cells(0).Value
                    Dim editSuc = (From s In dbCocina.Sucursal
                                   Where s.IdSucursal = id
                                   Select s).First
                    editSuc.Nombre = txtNombre.Text
                    Try
                        dbCocina.SubmitChanges()
                        MsgBox("Registro editado correctamente", MsgBoxStyle.Exclamation, _
                               "Editar Registro")
                    Catch ex As Exception
                        If MsgBox("Error al intentar editar", MsgBoxStyle.OkCancel, _
                               "¿Intentar otra ves?") = MsgBoxResult.Ok Then
                            dbCocina.SubmitChanges()
                        End If
                    End Try
                End If
                btnCancelar_Click(sender, e)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar.Click
        If MsgBox("¿Eliminar sucursal del registro del sistema?", MsgBoxStyle.YesNo, _
                  "Eliminar Sucursal") = MsgBoxResult.Yes Then
            Dim row As DataGridViewRow = dgvSucursal.CurrentRow
            Dim id As Integer = row.Cells(0).Value
            Using dbCocina As New CocinaDataContext
                Dim dSuc = (From s In dbCocina.Sucursal
                            Where s.IdSucursal = id
                            Select s).First
                dbCocina.Sucursal.DeleteOnSubmit(dSuc)
                Try
                    dbCocina.SubmitChanges()
                    MsgBox("Sucursal eliminada correctamente", MsgBoxStyle.Information, _
                           "Eliminar sucursal")
                Catch ex As Exception
                    MsgBox("Error " + ex.Message)
                End Try
            End Using
        End If
        btnCancelar_Click(sender, e)
    End Sub
End Class