Public Class frmGrupo
    Dim ultReg As Integer
    Dim aux As Integer = 0
    Sub cargarDatos()
        Try
            Using dbCocina As New CocinaDataContext
                Dim consulta = From gr In dbCocina.Grupo Select gr

                dgvGrupo.DataSource = consulta
                Dim ultimo = (From gr In dbCocina.Grupo Order By gr.IdGrupo Descending Select gr).First
                If ultimo.IdGrupo.Trim.Length > 0 Then
                    txtNumGrupo.Text = ultimo.IdGrupo
                    ultReg = CInt(ultimo.IdGrupo)
                Else
                    txtNumGrupo.Text = "NO hay registros"
                    ultReg = 0
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmGrupo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        diseñoDgv(dgvGrupo)
        cargarDatos()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If txtNombre.Text = "" Then
                MsgBox("Debe especificar un nombre de grupo para poder continuar", MsgBoxStyle.Information, "Guardar Registro")
                Return
            End If
            Using dbCocina As New CocinaDataContext
                'Ingresamos un nuevo registro de grupo
                If aux = 0 Then
                    Dim idReg As String
                    Dim desc As String = txtNombre.Text
                    idReg = txtNumGrupo.Text
                    Dim inGrupo As New Grupo With {.IdGrupo = idReg, .Descripcion = desc}

                    dbCocina.Grupo.InsertOnSubmit(inGrupo)
                    Try
                        dbCocina.SubmitChanges()
                    Catch ex As Exception
                        MsgBox("Intentando insertar los registros... por favor espere, si tarda demasiado reinicie el sistema, sino pongase en contacto con el administrador", MsgBoxStyle.Exclamation, "Guardar grupo")
                        dbCocina.SubmitChanges()
                    End Try
                    MessageBox.Show("Ingreso del Grupo en el sistema realizado", "Guardar Grupo", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                'Actualizamos un registro existente
                If aux = 1 Then
                    Dim actGr = (From gr In dbCocina.Grupo Where gr.IdGrupo = txtNumGrupo.Text Select gr).First
                    actGr.Descripcion = txtNombre.Text
                    dbCocina.SubmitChanges()
                    MsgBox("Actualización del nombre del grupo realizada", MsgBoxStyle.Information, "Actualizar grupo")
                End If
                cargarDatos()
                dgvGrupo_SelectionChanged(sender, e)
            End Using
        Catch ex As Exception
            MsgBox("Error al guardar " + ex.Message)
        End Try
        btnEditar.Enabled = True
        btnBorrar.Enabled = True
        btnCancelar.Enabled = False
        btnNuevo.Enabled = True
        btnGuardar.Enabled = False
        dgvGrupo.Enabled = True
        txtNombre.Enabled = False
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        txtNombre.Enabled = True
        txtNombre.Clear()
        dgvGrupo.Enabled = False
        aux = 0
        Using dbCocina As New CocinaDataContext
            Dim id As String
            Try
                Dim ultimo = (From gr In dbCocina.Grupo Order By gr.IdGrupo Descending Select gr).First
                If ultimo.IdGrupo.Trim.Length > 0 Then
                    ultReg = CInt(ultimo.IdGrupo)
                    id = 1 + ultReg
                    txtNumGrupo.Text = "0" + id
                End If
            Catch ex As Exception
                txtNumGrupo.Text = "01"
            End Try
        End Using
        btnNuevo.Enabled = False
        btnEditar.Enabled = False
        btnBorrar.Enabled = False
        btnGuardar.Enabled = True
        btnCancelar.Enabled = True
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        aux = 1
        dgvGrupo.Enabled = True
        txtNombre.Enabled = True
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True
        btnCancelar.Enabled = True
        btnBorrar.Enabled = False
        btnEditar.Enabled = False
    End Sub

    Private Sub btnBorrar_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar.Click
        If MessageBox.Show("¿Eliminar registro de grupo del sistema?", "Eliminar grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Using dbCocina As New CocinaDataContext
                Dim deleteGr = (From gr In dbCocina.Grupo Where gr.IdGrupo = txtNumGrupo.Text Select gr).First
                dbCocina.Grupo.DeleteOnSubmit(deleteGr)
                Try
                    dbCocina.SubmitChanges()
                    cargarDatos()
                Catch ex As Exception
                    MsgBox("Error al intentar eliminar el registro " + ex.Message)
                End Try
            End Using
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        dgvGrupo.Enabled = True
        txtNombre.Enabled = False
        btnNuevo.Enabled = True
        btnGuardar.Enabled = False
        btnBorrar.Enabled = True
        btnEditar.Enabled = True
        btnCancelar.Enabled = False
    End Sub

    Private Sub dgvGrupo_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvGrupo.SelectionChanged
        Try
            Dim row As DataGridViewRow = dgvGrupo.CurrentRow
            txtNombre.Text = row.Cells(1).Value
            txtNumGrupo.Text = row.Cells(0).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        Using dbCocina As New CocinaDataContext
            dgvGrupo.DataSource = dbCocina.filtrarGrupo(txtBuscar.Text)
        End Using
    End Sub

    Private Sub txtNombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = vbCr Then
            btnGuardar_Click(sender, e)
        End If
    End Sub
End Class
