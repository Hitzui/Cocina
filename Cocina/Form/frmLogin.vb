Public Class frmLogin
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtusuario.Text.Length = 0 Then
            Erp.SetError(Me.txtusuario, "Debe especificar un usuario")
            Return
        Else
            Erp.SetError(Me.txtusuario, "")
        End If
        If txtClave.Text.Length = 0 Then
            Erp.SetError(Me.txtClave, "Debe espcificar una clave para continuar")
            Return
        Else
            Erp.SetError(Me.txtClave, "")
        End If
        Try
            Dim usuario As String = txtusuario.Text
            Dim clave As String = txtClave.Text
            Using dbCocina As New CocinaDataContext
                Try
                    Dim verUsuario = (From u In dbCocina.Usuario Where u.Usuario = usuario Select u).Single
                Catch ex As Exception
                    MsgBox("No existe el usuario, intente nuevamente", MsgBoxStyle.Information, "Ingreso al sistema")
                    Return
                End Try
                Try
                    Dim verUsuario = (From u In dbCocina.Usuario Where u.Clave = clave Select u).Single
                Catch ex As Exception
                    MsgBox("Contraseña incorrecta, por favor intente nuevamente", MsgBoxStyle.Information, "Ingreso al sistema")
                    Return
                End Try
                Dim consulta = (From u In dbCocina.Usuario
                               Where u.Usuario = usuario And u.Clave = clave
                               Select u).Single
                If consulta.Nivel = 1 Then
                    Principal.Text = "Cocina de Doña Hayde " & "  -  " & " Nombre: " + consulta.Nombre & " - " & " Administrador"
                    Principal.toGrupo.Enabled = True
                    Principal.toCategoria.Enabled = True
                    Principal.toUsuario.Enabled = True
                    Principal.Focus()
                    Me.Hide()
                ElseIf consulta.Nivel = 2 Then
                    Principal.Text = "Cocina de Doña Hayde " & "  -  " & " Nombre: " + consulta.Nombre & " - " & " Administrador"
                    Principal.toGrupo.Enabled = False
                    Principal.toCategoria.Enabled = False
                    Principal.toUsuario.Enabled = False
                    Principal.Focus()
                    Me.Hide()
                Else
                    MsgBox("No hay registros", MsgBoxStyle.Information, "Ingreso al sistema")
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error en inicio de sesión " + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Principal.Dispose()
    End Sub

    Private Sub frmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtClave.Text = ""
        txtusuario.Text = ""
        txtusuario.Focus()
        AbrirConexion()
    End Sub


    Private Sub frmLogin_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        CerrarConexion()
    End Sub


    Private Sub btnX_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnX.MouseHover
        btnX.ForeColor = Color.Red
        btnX.BackgroundImage = My.Resources.degradado_menu
    End Sub

    Private Sub btnX_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnX.MouseLeave
        btnX.BackgroundImage = My.Resources.title_bar
        btnX.ForeColor = Color.White
    End Sub

    Private Sub btnX_Click(sender As System.Object, e As System.EventArgs) Handles btnX.Click
        Me.Close()
        Principal.Dispose()
    End Sub

    Private Sub txtusuario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtusuario.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Enter)
                e.Handled = True
                txtClave.Focus()
        End Select
    End Sub

    Private Sub txtClave_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtClave.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Enter)
                e.Handled = True
                btnAceptar.Focus()
        End Select
    End Sub
End Class
