Public Class frmProveedor
    Dim aux As Integer = 1
    Sub controles(ByVal opcion As Boolean)
        txtRuc.Enabled = opcion
        txtCodigo.Enabled = opcion
        txtNombre.Enabled = opcion
        txtDireccion.Enabled = opcion
        txtTelefono.Enabled = opcion
    End Sub
    Sub botones(ByVal nuevo As Boolean, ByVal guardar As Boolean, _
                ByVal editar As Boolean, ByVal borrar As Boolean, ByVal cancelar As Boolean)
        btnNuevo.Enabled = nuevo
        btnGuardar.Enabled = guardar
        btnEditar.Enabled = editar
        btnBorrar.Enabled = borrar
        btnCancelar.Enabled = cancelar
    End Sub
    Sub limpiar()
        txtFiltrar.Clear()
        txtRuc.Clear()
        txtCodigo.Clear()
        txtNombre.Clear()
        txtDireccion.Clear()
        txtTelefono.Clear()
        txtRuc.Focus()
    End Sub
    Sub cargar()
        Try
            Using dbCocina As New CocinaDataContext
                Dim reg = (From p In dbCocina.Proveedor Select p)
                dgvProveedor.DataSource = reg
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmProveedor_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim respuesta As DialogResult = MessageBox.Show("¿Cerrar el formulario proveedor?", "Salir", MessageBoxButtons.YesNo)
        If respuesta = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
    Private Sub frmProveedor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cargar()
        diseñoDgv(dgvProveedor)
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        aux = 1
        botones(False, True, False, False, True)
        limpiar()
        dgvProveedor.Enabled = False
        controles(True)
        txtRuc.Focus()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If Len(txtRuc.Text) = 0 Then
            Erp.SetError(txtRuc, "No puede estar vacio el número ruc")
            Return
        Else
            Erp.SetError(txtRuc, "")
        End If
        If Len(txtNombre.Text) = 0 Then
            Erp.SetError(txtNombre, "No puede estar vacio el nombre del proveedor")
            Return
        Else
            Erp.SetError(txtNombre, "")
        End If
        If Len(txtDireccion.Text) = 0 Then
            Erp.SetError(txtDireccion, "Especifique una dirección...")
            Return
        Else
            Erp.SetError(txtDireccion, "")
        End If
        If Len(txtTelefono.Text) = 0 Then
            Erp.SetError(txtTelefono, "Especifique un teléfono...")
            Return
        Else
            Erp.SetError(txtRuc, "")
        End If
        Try
            Using dbCocina As New CocinaDataContext
                'Guardar nuevo proveedor
                If aux = 1 Then
                    Dim nuevoPro As New Proveedor With {.NumRuc = txtRuc.Text,
                                                        .Nombre = txtNombre.Text,
                                                        .Codigo = txtCodigo.Text,
                                                        .Direccion = txtDireccion.Text,
                                                        .Telefono = txtTelefono.Text,
                                                        .FCrea = Now()}
                    dbCocina.Proveedor.InsertOnSubmit(nuevoPro)
                    Try
                        dbCocina.SubmitChanges()
                        MsgBox("Proveedor ingresado al sistema", MsgBoxStyle.Information, "Proveedor")
                        btnCancelar_Click(sender, e)
                    Catch ex As Exception
                        MsgBox("Error al ingresar proveedor " & ex.Message)
                        Return
                    End Try
                End If
                'Editar proveedor
                If aux = 2 Then
                    Dim row As DataGridViewRow = dgvProveedor.CurrentRow
                    Dim id As Integer = row.Cells(0).Value
                    Dim editarPro = (From p In dbCocina.Proveedor
                                     Where p.IdProveedor = id
                                     Select p).First
                    editarPro.Nombre = txtNombre.Text
                    editarPro.Codigo = txtCodigo.Text
                    editarPro.Direccion = txtDireccion.Text
                    editarPro.Telefono = txtTelefono.Text
                    editarPro.NumRuc = txtRuc.Text
                    Try
                        dbCocina.SubmitChanges()
                        MsgBox("Proveedor ha sido editado", MsgBoxStyle.Information, "Proveedor")
                        btnCancelar_Click(sender, e)
                    Catch ex As Exception
                        MsgBox("Error al editar proveedor " & ex.Message)
                        Return
                    End Try
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error al guardar: " & ex.Message)
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        txtFiltrar.Enabled = False
        dgvProveedor.Enabled = False
        aux = 2
        botones(False, True, False, False, True)
        controles(True)
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        txtFiltrar.Enabled = True
        dgvProveedor.Enabled = True
        botones(True, False, True, True, False)
        controles(False)
        cargar()
        dgvProveedor_SelectionChanged(sender, e)
    End Sub

    Private Sub dgvProveedor_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvProveedor.SelectionChanged
        Try
            Dim row As DataGridViewRow = dgvProveedor.CurrentRow
            txtRuc.Text = row.Cells(1).Value
            txtNombre.Text = row.Cells(2).Value
            txtDireccion.Text = row.Cells(4).Value
            txtTelefono.Text = row.Cells(5).Value
            txtCodigo.Text = row.Cells(6).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs)
        Try
            Using dbCocina As New CocinaDataContext
                dgvProveedor.DataSource = dbCocina.FiltrarProveedor(txtFiltrar.Text)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTelefono_Enter(sender As System.Object, e As System.EventArgs) Handles txtTelefono.Enter
        Me.txtTelefono.Text = "0"
    End Sub

    Private Sub txtTelefono_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        If e.KeyChar > "0" And e.KeyChar < "9" Then
            e.Handled = False
        ElseIf e.KeyChar = "0" Then
            e.Handled = False
        ElseIf e.KeyChar = vbBack Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar.Click
        Try
            Using dbCocina As New CocinaDataContext
                If MsgBox("¿Borrar proveedor del sistema?", MsgBoxStyle.YesNo, "Proveedor") = MsgBoxResult.Yes Then
                    Dim row As DataGridViewRow = dgvProveedor.CurrentRow
                    Dim id As Integer = row.Cells(0).Value
                    Dim reg = (From p In dbCocina.Proveedor
                               Where p.IdProveedor = id
                               Select p)
                    dbCocina.Proveedor.DeleteOnSubmit(reg)
                    Try
                        dbCocina.SubmitChanges()
                        MsgBox("Proveedor eliminado del sistema", MsgBoxStyle.Information, "Proveedor")
                        btnCancelar_Click(sender, e)
                    Catch ex As Exception
                        MsgBox("Error al eliminar: " & ex.Message)
                    End Try
                Else
                    Return
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error al eliminar: " & ex.Message)
        End Try
    End Sub

    Private Sub frmProveedor_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        Try
            Using dbCocina As New CocinaDataContext
                ''Bodegas
                'Dim regBod = (From b In dbCocina.Bodegas Order By b.Nombre Select b)
                'frmCompras.cmbBodega.DataSource = regBod
                'frmCompras.cmbBodega.DisplayMember = "Nombre"
                'frmCompras.cmbBodega.ValueMember = "IdBodega"

                'Proveedor
                Dim regProv = (From p In dbCocina.Proveedor Select p.IdProveedor, Desc = p.Codigo.PadLeft(3, "0"c) + " | " + p.Nombre)
                frmCompras.cmbProveedor.DataSource = regProv
                frmCompras.cmbProveedor.DisplayMember = "Desc"
                frmCompras.cmbProveedor.ValueMember = "IdProveedor"
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtFiltrar_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltrar.KeyPress
        Try
            Using dbCocina As New CocinaDataContext
                Dim ver = (From p In dbCocina.Proveedor
                           Where p.Nombre.Contains(txtFiltrar.Text)
                           Select p)
                dgvProveedor.DataSource = ver
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class

