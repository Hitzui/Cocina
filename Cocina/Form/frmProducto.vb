Imports System.Data.Linq
Imports System.Data.Linq.Mapping

Public Class frmProducto
    'variable usada para guardar o editar
    Dim aux As Integer = 0
    Sub cargarDatos()
        Using dbCocina As New CocinaDataContext
            Dim prodt = From gr In dbCocina.Grupo
                        From cat In dbCocina.Categoria
                        From med In dbCocina.Unidad
                        Join prod In dbCocina.Productos
                        On gr.IdGrupo Equals prod.IdGrupo And
                        cat.IdCategoria Equals prod.IdCategoria And
                        med.IdUnidad Equals prod.IdUnidad
                        Select prod.CodProducto, prod.Nombre, Grupo = gr.Descripcion, Categoria = cat.Descripcion, Medida = med.Descripcion

            dgvProducto.DataSource = prodt
            'combo de grupo
            Dim g = From c In dbCocina.Grupo Select c

            cmbGrupo.DataSource = g
            cmbGrupo.DisplayMember = "Descripcion"
            cmbGrupo.ValueMember = "IdGrupo"
            'combo de medida
            Dim medi = From m In dbCocina.Unidad Select m

            cmbMedida.DataSource = medi
            cmbMedida.DisplayMember = "UdidadM"
            cmbMedida.ValueMember = "IdUnidad"
        End Using
    End Sub
    Private Sub frmProducto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        diseñoDgv(dgvProducto)
        cargarDatos()
        txtFiltrar.Clear()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        aux = 0
        Me.txtFiltrar.Clear()
        cmbCategoria.Enabled = True
        cmbGrupo.Enabled = True
        cmbMedida.Enabled = True
        dgvProducto.ClearSelection()
        dgvProducto.Enabled = False
        cmbCategoria.Enabled = True
        cmbMedida.Enabled = True
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True
        btnBorrar.Enabled = False
        btnEditar.Enabled = False
        btnCancelar.Enabled = True
        txtNombre.Enabled = True
        txtNombre.Clear()
        txtNombre.Focus()
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        aux = 1
        dgvProducto.Enabled = True
        txtNombre.Enabled = True
        cmbCategoria.Enabled = True
        cmbCategoria.Enabled = False
        cmbGrupo.Enabled = False
        cmbCategoria.Enabled = False
        cmbMedida.Enabled = True
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True
        btnBorrar.Enabled = False
        btnEditar.Enabled = False
        btnCancelar.Enabled = True
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        txtNombre.Enabled = False
        cmbCategoria.Enabled = False
        cmbMedida.Enabled = False
        btnNuevo.Enabled = True
        btnGuardar.Enabled = False
        btnBorrar.Enabled = True
        btnEditar.Enabled = True
        btnCancelar.Enabled = False
        dgvProducto.Enabled = True
        cmbGrupo.Enabled = False
        cargarDatos()
        dgvProducto_SelectionChanged(sender, e)
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If txtNombre.Text = "" Then
                MsgBox("No puede estar vacio el nombre del producto, intente nuevamente", _
                       MsgBoxStyle.Information, "Error")
                txtNombre.Focus()
                Return
            End If
            Using dbCocina As New CocinaDataContext
                Dim codprod As String = lblCod.Text
                Dim idgr As String = cmbGrupo.SelectedValue
                Dim idcat As String = cmbCategoria.SelectedValue
                Dim idMed As Integer = cmbMedida.SelectedValue
                Dim idBodega As Integer = 0
                'Guardar registro opc 0
                If aux = 0 Then
                    Dim deta = (From db In dbCocina.Bodegas Select db)
                    'For Each detalle In deta
                    '    idBodega = detalle.IdBodega
                    '    Dim detaBodega As New DetaBodega With {.IdBodega = idBodega,
                    '                                          .CodProducto = codprod,
                    '                                          .Existencia = 0}
                    '    dbCocina.DetaBodega.InsertOnSubmit(detaBodega)
                    'Next
                    Dim ingresarProducto As New Productos With {.CodProducto = codprod,
                                                                .Nombre = txtNombre.Text,
                                                                .IdGrupo = idgr,
                                                                .IdCategoria = idcat,
                                                                .IdUnidad = idMed,
                                                                .UltPrecioC = 0,
                                                                .Costo = 0}
                    dbCocina.Productos.InsertOnSubmit(ingresarProducto)

                    'actualizamos la tabla categoria para el siguiente registro
                    Dim actCat = (From c In dbCocina.Categoria
                                  Where c.IdCategoria = idcat
                                  Select c).First
                    actCat.NextIdProd = actCat.NextIdProd + 1
                    Try
                        dbCocina.SubmitChanges()
                        MsgBox("Producto ingresado correctamente al sistema", MsgBoxStyle.Information, _
                               "Ingreso de producto")
                    Catch ex As Exception
                        MsgBox("Error al intentar ingresar en " + ex.Message)
                    End Try
                End If
                'Editar registro opc 1
                If aux = 1 Then
                    Dim editarProd = (From p In dbCocina.Productos
                                      Where p.CodProducto = codprod
                                      Select p).First
                    editarProd.Nombre = txtNombre.Text
                    editarProd.IdUnidad = cmbMedida.SelectedValue
                    Try
                        dbCocina.SubmitChanges()
                        MsgBox("Producto actualizado", MsgBoxStyle.Information, _
                               "Editar producto")
                    Catch ex As Exception
                        MsgBox("Error al editar en " + ex.Message)
                    End Try
                End If
                btnCancelar_Click(sender, e)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvProducto_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvProducto.SelectionChanged
        Try
            Using dbCocina As New CocinaDataContext
                Dim row As DataGridViewRow = dgvProducto.CurrentRow
                lblCod.Text = row.Cells(0).Value
                txtNombre.Text = row.Cells(1).Value
            End Using
        Catch ex As Exception

        End Try
    End Sub



    Private Sub cmbGrupo_SelectionChangeCommitted(sender As System.Object, e As System.EventArgs) Handles cmbGrupo.SelectionChangeCommitted
        Try
            Dim idgrupo As String = cmbGrupo.SelectedValue
            Using dbCocina As New CocinaDataContext
                Dim categoria = From cat In dbCocina.Categoria
                                Where cat.IdGrupo = idgrupo
                                Select cat

                cmbCategoria.DataSource = categoria
                cmbCategoria.DisplayMember = "Descripcion"
                cmbCategoria.ValueMember = "IdCategoria"
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCategoria_SelectionChangeCommitted(sender As System.Object, e As System.EventArgs) Handles cmbCategoria.SelectionChangeCommitted
        Using dbCocina As New CocinaDataContext
            Dim ultReg As Integer
            Dim idCat As String = cmbCategoria.SelectedValue
            Dim reg = (From c In dbCocina.Categoria
                       Where c.IdCategoria = idCat
                       Select c).First
            ultReg = reg.NextIdProd
            If ultReg > 9 Then
                lblCod.Text = "" & idCat & ultReg
            Else
                lblCod.Text = idCat + "0" + ultReg.ToString()
            End If
        End Using
    End Sub

    Private Sub btnBorrar_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar.Click
        Try
            Using dbCocina As New CocinaDataContext
                If MessageBox.Show("¿Eliminar el producto del catalogo del sistema?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim borrarProd = (From p In dbCocina.Productos
                                      Where p.CodProducto = lblCod.Text
                                      Select p).First
                    dbCocina.Productos.DeleteOnSubmit(borrarProd)
                    Try
                        MsgBox("Producto elminado correctamente", MsgBoxStyle.Exclamation, "Catalogo de prodcutos")
                        dbCocina.SubmitChanges()
                    Catch ex As Exception
                        MsgBox("error al intentar eliminar en " & ex.Message)
                    End Try
                    btnCancelar_Click(sender, e)
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltrar.TextChanged
        Using dbCocina As New CocinaDataContext
            dgvProducto.DataSource = dbCocina.FiltrarProducto(txtFiltrar.Text)
        End Using
    End Sub

    Private Sub txtNombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Try
            If e.KeyChar = vbCr Then
                btnGuardar_Click(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)

    End Sub


    Private Sub frmProducto_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            Using dboCocina As New CocinaDataContext
                Dim reg = (From p In dboCocina.Productos Order By p.Nombre Select p)
                frmCompras.cmbProducto.DataSource = reg
                frmCompras.cmbProducto.DisplayMember = "Nombre"
                frmCompras.cmbProducto.ValueMember = "CodProducto"
            End Using
        Catch ex As Exception
            MsgBox("Error al cargar datos de productos en el combo box: " & ex.Message)
        End Try
    End Sub

    Private Sub cmbGrupo_Validated(sender As System.Object, e As System.EventArgs) Handles cmbGrupo.Validated
        Try
            Dim idgrupo As String = cmbGrupo.SelectedValue
            Using dbCocina As New CocinaDataContext
                Dim categoria = From cat In dbCocina.Categoria
                                Where cat.IdGrupo = idgrupo
                                Select cat

                cmbCategoria.DataSource = categoria
                cmbCategoria.DisplayMember = "Descripcion"
                cmbCategoria.ValueMember = "IdCategoria"
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCategoria_Validated(sender As Object, e As System.EventArgs) Handles cmbCategoria.Validated
        Try
            Using dbCocina As New CocinaDataContext
                Dim ultReg As Integer
                Dim idCat As String = cmbCategoria.SelectedValue
                Dim reg = (From c In dbCocina.Categoria
                           Where c.IdCategoria = idCat
                           Select c).Single
                ultReg = reg.NextIdProd
                If ultReg > 9 Then
                    lblCod.Text = "" & idCat & ultReg
                Else
                    lblCod.Text = idCat + "0" + ultReg.ToString()
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmProducto_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim respuesta As DialogResult = MessageBox.Show("¿Cerrar el formulario de productos?", "Salir", MessageBoxButtons.YesNo)
        If respuesta = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub


End Class