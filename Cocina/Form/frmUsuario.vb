Public Class frmUsuario
    Dim aux As Integer = 0
    Sub controles(ByVal opcion As Boolean)
        txtNombre.Enabled = opcion
        txtApellido.Enabled = opcion
        txtUsuario.Enabled = opcion
        txtClave.Enabled = opcion
        txtConfirmar.Enabled = opcion
        cmbNivel.Enabled = opcion
    End Sub
    Sub limpiar()
        txtNombre.Clear()
        txtApellido.Clear()
        txtUsuario.Clear()
        txtClave.Clear()
        txtConfirmar.Clear()
        txtNombre.Focus()
    End Sub
    Sub cargarDatos()
        Using dbCocina As New CocinaDataContext
            Dim reg = From u In dbCocina.Usuario
                      Select No = u.IdUsuairo, u.Nombre, u.Apellido, NombreUsuario = u.Usuario, u.Nivel, u.FCrea

            dgvUser.DataSource = reg
        End Using

    End Sub
    Private Sub frmUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        controles(False)
        diseñoDgv(dgvUser)
        cargarDatos()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        aux = 1
        controles(True)
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True
        btnBorrar.Enabled = False
        btnEditar.Enabled = False
        btnCancelar.Enabled = True
        dgvUser.Enabled = False
        limpiar()
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        aux = 2
        controles(True)
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True
        btnBorrar.Enabled = False
        btnEditar.Enabled = False
        btnCancelar.Enabled = True
        dgvUser.Enabled = False
        Using dbCocina As New CocinaDataContext
            Dim row As DataGridViewRow = dgvUser.CurrentRow
            Dim idusuario As Integer = row.Cells(0).Value
            Dim modUsuario = (From u In dbCocina.Usuario
                              Where u.IdUsuairo = idusuario
                              Select u).First
            txtClave.Text = modUsuario.Clave
            txtConfirmar.Text = modUsuario.Clave
        End Using
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        controles(False)
        btnNuevo.Enabled = True
        btnGuardar.Enabled = False
        btnBorrar.Enabled = True
        btnEditar.Enabled = True
        btnCancelar.Enabled = False
        dgvUser.Enabled = True
        cargarDatos()
        dgvUser_SelectionChanged(sender, e)
    End Sub

    Private Sub dgvUser_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvUser.SelectionChanged
        Dim row As DataGridViewRow = dgvUser.CurrentRow
        Try
            txtNombre.Text = row.Cells(1).Value
            txtApellido.Text = row.Cells(2).Value
            txtUsuario.Text = row.Cells(3).Value
            txtClave.Text = "*********"
            txtConfirmar.Text = "*********"
            If row.Cells(4).Value = 1 Then
                cmbNivel.SelectedIndex = 1
            End If
            If row.Cells(4).Value = 2 Then
                cmbNivel.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If Len(txtNombre.Text) = 0 Then
            Erp.SetError(Me.txtNombre, "Debe especificar un nombre para continuar")
            Return
        Else
            Erp.SetError(Me.txtNombre, "")
        End If
        If Len(txtApellido.Text) = 0 Then
            Erp.SetError(Me.txtApellido, "Debe especificar un apellido para continuar")
            Return
        Else
            Erp.SetError(Me.txtApellido, "")
        End If
        If Len(txtUsuario.Text) = 0 Then
            Erp.SetError(Me.txtUsuario, "Debe especificar un nombre de usuario para continuar")
            Return
        Else
            Erp.SetError(Me.txtUsuario, "")
        End If
        If Len(txtClave.Text) = 0 Then
            Erp.SetError(Me.txtClave, "Debe especificar una clave de usuario para continuar")
            Return
        Else
            Erp.SetError(Me.txtClave, "")
        End If
        If Not txtClave.Text = txtConfirmar.Text Then
            Erp.SetError(Me.txtConfirmar, "La confirmación de contraseña y la clave deben ser iguales")
            Return
        Else
            Erp.SetError(Me.txtConfirmar, "")
        End If
        Using dbCocina As New CocinaDataContext
            Try
                'ingreso de usuario
                If aux = 1 Then
                    Dim nivel As Integer
                    If cmbNivel.SelectedIndex = 0 Then
                        nivel = 2
                    End If
                    If cmbNivel.SelectedIndex = 1 Then
                        nivel = 1
                    End If
                    Dim nuevoUsuario As New Usuario With {.Nombre = txtNombre.Text,
                                                          .Apellido = txtApellido.Text,
                                                          .Usuario = txtUsuario.Text,
                                                          .Clave = txtConfirmar.Text,
                                                          .Nivel = nivel,
                                                          .FCrea = Now()}
                    dbCocina.Usuario.InsertOnSubmit(nuevoUsuario)
                    Try
                        dbCocina.SubmitChanges()
                        MsgBox("Ingreso de usuario completado", MsgBoxStyle.Information, "Nuevo usuario")
                    Catch ex As Exception
                        MsgBox("Error al ingresar usuario " & ex.Message)
                    End Try
                End If
                'Editar usuario
                If aux = 2 Then
                    Dim row As DataGridViewRow = dgvUser.CurrentRow
                    Dim nivel As Integer
                    If cmbNivel.SelectedIndex = 0 Then
                        nivel = 2
                    End If
                    If cmbNivel.SelectedIndex = 1 Then
                        nivel = 1
                    End If
                    Dim idusuario As Integer = row.Cells(0).Value
                    Dim modUsuario = (From u In dbCocina.Usuario
                                      Where u.IdUsuairo = idusuario
                                      Select u).First
                    modUsuario.Nombre = txtNombre.Text
                    modUsuario.Apellido = txtApellido.Text
                    modUsuario.Usuario = txtUsuario.Text
                    modUsuario.Clave = txtConfirmar.Text
                    modUsuario.Nivel = nivel
                    Try
                        dbCocina.SubmitChanges()
                        MsgBox("Usuario modificado", MsgBoxStyle.Information, "Editar usuario")
                    Catch ex As Exception
                        MsgBox("Error al editar " & ex.Message)
                    End Try
                End If
                limpiar()
                btnCancelar_Click(sender, e)
            Catch ex As Exception
                MsgBox("Error en " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnBorrar_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar.Click
        Try
            If MsgBox("¿Eliminar usuario del sistema?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                Using dbCocina As New CocinaDataContext
                    Dim row As DataGridViewRow = dgvUser.CurrentRow
                    Dim id As Integer = row.Cells(0).Value
                    Dim consulta = (From u In dbCocina.Usuario
                                    Where u.IdUsuairo = id
                                    Select u).First
                    dbCocina.Usuario.DeleteOnSubmit(consulta)
                    Try
                        dbCocina.SubmitChanges()
                        MsgBox("Usuario elminado", MsgBoxStyle.Information, "Elminar usuario")
                    Catch ex As Exception
                        MsgBox("No se elminó por el error " & ex.Message)
                    End Try
                End Using
            Else
                Return
            End If
            btnCancelar_Click(sender, e)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try

    End Sub
End Class