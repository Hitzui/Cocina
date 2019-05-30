Public Class frmMedidas
    Dim aux As Integer = 0
    Dim idmed As Integer
    Sub cargarDatos()
        Using dbCocina As New CocinaDataContext
            Dim reg = From med In dbCocina.Unidad Select med

            dgvUnidad.DataSource = reg
        End Using
    End Sub
    Private Sub frmMedidas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        diseñoDgv(dgvUnidad)
        cargarDatos()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        aux = 0
        txtDescripcion.Enabled = True
        txtSimbolo.Enabled = True
        txtDescripcion.Clear()
        txtSimbolo.Clear()
        txtSimbolo.Focus()
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True
        btnBorrar.Enabled = False
        btnEditar.Enabled = False
        btnCancelar.Enabled = True
        dgvUnidad.Enabled = False
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        aux = 1
        txtDescripcion.Enabled = True
        txtSimbolo.Enabled = True
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True
        btnBorrar.Enabled = False
        btnEditar.Enabled = False
        btnCancelar.Enabled = True
        dgvUnidad.Enabled = True
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        txtDescripcion.Enabled = False
        txtSimbolo.Enabled = False
        btnNuevo.Enabled = True
        btnGuardar.Enabled = False
        btnBorrar.Enabled = True
        btnEditar.Enabled = True
        btnCancelar.Enabled = False
        dgvUnidad.Enabled = True
        cargarDatos()
        dgvUnidad_SelectionChanged(sender, e)
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            Using dbCocina As New CocinaDataContext
                'Ingresar registro al sistema
                If aux = 0 Then
                    Dim med As String = txtSimbolo.Text
                    Dim desc As String = txtDescripcion.Text
                    Dim inMed As New Unidad With {.UdidadM = med, .Descripcion = desc}
                    dbCocina.Unidad.InsertOnSubmit(inMed)
                    Try
                        dbCocina.SubmitChanges()
                        MsgBox("Registro guardado exitosamente", MsgBoxStyle.Information, "Guardar registro")
                    Catch ex As Exception
                        MsgBox("Intentando insertar los registros... por favor espere, si tarda demasiado reinicie el sistema, sino pongase en contacto con el administrador", MsgBoxStyle.Exclamation, "Guardar Unidad de Medida")
                        dbCocina.SubmitChanges()
                    End Try
                End If
                'Modificar registro
                If aux = 1 Then
                    Dim actMed = (From med In dbCocina.Unidad
                                  Where med.IdUnidad = idmed
                                  Select med).First
                    actMed.Descripcion = txtDescripcion.Text
                    actMed.UdidadM = txtSimbolo.Text
                    dbCocina.SubmitChanges()
                    MsgBox("Actualización de medidas realizada", MsgBoxStyle.Information, "Actualizar Medida")
                End If
            End Using
            btnCancelar_Click(sender, e)
            dgvUnidad_SelectionChanged(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvUnidad_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvUnidad.SelectionChanged
        Try
            Dim row As DataGridViewRow = dgvUnidad.CurrentRow
            txtDescripcion.Text = row.Cells(2).Value
            txtSimbolo.Text = row.Cells(1).Value
            idmed = row.Cells(0).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar.Click
        If MessageBox.Show("¿Eliminar registro de medidas del sistema?", "Eliminar Medida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Using dbCocina As New CocinaDataContext
                Dim delMed = (From med In dbCocina.Unidad
                              Where med.IdUnidad = idmed
                              Select med).First
                dbCocina.Unidad.DeleteOnSubmit(delMed)
                MsgBox("Registro eliminado exitosamente", MsgBoxStyle.Information, "Eliminar Medida")
                Try
                    dbCocina.SubmitChanges()
                    cargarDatos()
                    dgvUnidad_SelectionChanged(sender, e)
                Catch ex As Exception

                End Try
            End Using
        End If
    End Sub
End Class