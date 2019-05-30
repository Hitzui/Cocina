Public Class frmCategoria
    Dim aux As Integer = 0
    Dim grupo As Int32
    Sub cargarDatos()
        Try
            Using dbCocina As New CocinaDataContext
                'registros de grupos
                Dim query = (From gr In dbCocina.Grupo Select gr)
                cmbGrupo.DataSource = query
                cmbGrupo.DisplayMember = "Descripcion"
                cmbGrupo.ValueMember = "IdGrupo"

                Dim consulta = (From cat In dbCocina.Categoria
                                Join gr In dbCocina.Grupo
                                On cat.IdGrupo Equals gr.IdGrupo
                                Select Grupo = gr.Descripcion, SubGrupo = cat.IdCategoria, cat.Descripcion)
                dgvCategoria.DataSource = consulta
                Dim ultimo = (From cat In dbCocina.Categoria Order By cat.IdCategoria Descending Select cat).First
                If ultimo.IdGrupo.Trim.Length > 0 Then
                    txtCategoria.Text = ultimo.IdCategoria
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        aux = 0
        cmbGrupo.Enabled = False
        txtNombre.Enabled = True
        txtNombre.Clear()
        dgvCategoria.Enabled = False
        Dim id As String
        Dim gr As String
        Dim suma As Integer
        Dim idcat As Integer
        Try
            Using dbCocina As New CocinaDataContext

                Dim reg = (From cat In dbCocina.Categoria _
                           Where cat.IdGrupo = CStr(cmbGrupo.SelectedValue) _
                           Order By cat.IdCategoria Descending _
                           Select cat).First
                If Not IsNothing(reg) Then
                    idcat = CInt(reg.IdCategoria.Substring(2))
                    suma = idcat + 1
                    If suma <= 9 Then
                        id = reg.IdGrupo + "0" + suma.ToString()
                    Else
                        id = reg.IdGrupo + suma.ToString()
                    End If
                    txtCategoria.Text = id
                End If
            End Using
        Catch ex As Exception
            gr = cmbGrupo.SelectedValue
            id = gr + "01"
            txtCategoria.Text = id
        End Try
        txtNombre.Enabled = True
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True
        btnBorrar.Enabled = False
        btnEditar.Enabled = False
        btnCancelar.Enabled = True
        Label6.Text = cmbGrupo.SelectedValue
        txtNombre.Focus()
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        aux = 1
        cmbGrupo.Enabled = False
        txtNombre.Enabled = True
        btnNuevo.Enabled = False
        btnBorrar.Enabled = False
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnEditar.Enabled = False
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        cmbGrupo.Enabled = True
        btnNuevo.Enabled = True
        btnGuardar.Enabled = False
        btnEditar.Enabled = True
        btnBorrar.Enabled = True
        btnCancelar.Enabled = False
        dgvCategoria.Enabled = True
        txtNombre.Enabled = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Using dbCocina As New CocinaDataContext
            dgvCategoria.DataSource = dbCocina.FiltrarCategoria(TextBox1.Text)
        End Using
    End Sub

    Private Sub frmCategoria_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cargarDatos()
        diseñoDgv(dgvCategoria)
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If txtNombre.Text = "" Then
                MsgBox("Debe especificar un nombre para esta coategoria", MsgBoxStyle.Information, "Guardar Registro")
                Return
            End If
            Using dbCocina As New CocinaDataContext
                'Opcion para guardar registro
                If aux = 0 Then
                    Dim ingCat As New Categoria With {.IdCategoria = txtCategoria.Text, _
                                                      .Descripcion = txtNombre.Text, _
                                                      .IdGrupo = cmbGrupo.SelectedValue,
                                                      .NextIdProd = 1}
                    dbCocina.Categoria.InsertOnSubmit(ingCat)
                    Try
                        dbCocina.SubmitChanges()
                    Catch ex As Exception
                        MsgBox("Intentando insertar los registros... por favor espere, si tarda demasiado reinicie el sistema, sino pongase en contacto con el administrador", MsgBoxStyle.Exclamation, "Guardar categoria")
                        dbCocina.SubmitChanges()
                    End Try
                    MessageBox.Show("Ingreso de la nueva categoria en el sistema realizado", "Guardar Categoria", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                'Opcion para editar registro
                If aux = 1 Then
                    Dim reg = (From cat In dbCocina.Categoria
                               Where cat.IdCategoria = txtCategoria.Text
                               Select cat).First
                    reg.Descripcion = txtNombre.Text
                    dbCocina.SubmitChanges()
                    MsgBox("Categoria actualizada", MsgBoxStyle.Information, "Actualizar categoria")
                End If
            End Using
            cargarDatos()
            txtNombre.Enabled = False
            btnNuevo.Enabled = True
            btnGuardar.Enabled = False
            btnEditar.Enabled = True
            btnBorrar.Enabled = True
            btnCancelar.Enabled = False
            dgvCategoria.Enabled = True
            cmbGrupo.Enabled = True
            dgvCategoria_SelectionChanged(sender, e)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub cmbGrupo_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbGrupo.SelectedValueChanged
        Try
            Label6.Text = cmbGrupo.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCategoria_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvCategoria.SelectionChanged
        Try
            Dim row As DataGridViewRow = dgvCategoria.CurrentRow
            txtNombre.Text = row.Cells(1).Value
            txtCategoria.Text = row.Cells(0).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar.Click
        Try
            Using dbCocina As New CocinaDataContext
                If MessageBox.Show("¿Eliminar registro de categoria del sistema?", "Eliminar Categoria", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim deCat = (From cat In dbCocina.Categoria
                                 Where cat.IdCategoria = txtCategoria.Text
                                 Select cat).First
                    dbCocina.Categoria.DeleteOnSubmit(deCat)
                    Try
                        MsgBox("Registro eliminado", MsgBoxStyle.Exclamation, "Eliminar")
                        dbCocina.SubmitChanges()
                        cargarDatos()
                    Catch ex As Exception
                        MsgBox("Error al eliminar registro", MsgBoxStyle.Critical, "Eliminar registro")
                    End Try
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error en 'Eliminar' " + ex.Message)
        End Try
    End Sub
End Class