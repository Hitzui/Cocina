Imports System.Globalization.CultureInfo
Imports System.Transactions

Public Class frmCompras
    Dim numFactura As Integer
    Dim idFactura As String
    Dim iva As Decimal
    Dim total As Decimal
    Function verProveedor(ByVal nombre As String, Optional ByVal idprov As Integer = Nothing) As String
        Using dbCocina As New CocinaDataContext
            Dim retorno As String = "000"
            Try
                If idprov = Nothing Then
                    Dim verReg = (From prov In dbCocina.Proveedor
                                    Where prov.Nombre = nombre
                                    Select prov.IdProveedor).Single
                    retorno = verReg
                End If
                If idprov > 0 Then
                    Dim verReg = (From prov In dbCocina.Proveedor
                                    Where prov.Nombre = nombre And prov.IdProveedor = idprov
                                    Select prov.IdProveedor).Single
                    retorno = verReg
                End If
                Return retorno
            Catch ex As Exception
                Return retorno
            End Try
        End Using
    End Function
    Function actualizarCosto(ByVal codprod As String, ByVal precio As Decimal, ByVal cant As Decimal) As Decimal
        Try
            Using dbCocina As New CocinaDataContext
                Dim exist As Decimal = 0
                Dim precPro As Decimal = 0
                Dim costo1 As Decimal = 0
                Dim costo2 As Decimal = 0
                Dim costoT As Decimal = 0
                'recuperamos la existencia de todas las bodegas
                Try
                    Dim regExi = (From db In dbCocina.DetaBodega
                                                  Where db.CodProducto = codprod
                                                  Group By db.CodProducto
                                                  Into SumExi = Sum(db.Existencia)
                                                  Select SumExi).Single
                    exist = regExi
                Catch ex As Exception
                    exist = 0
                End Try
                Try
                    'recuperamos el coto del producto
                    Dim regCost1 = (From p In dbCocina.Productos
                                    Where p.CodProducto = codprod
                                    Select p.Costo).Single
                    precPro = regCost1
                Catch ex As Exception
                    precPro = 0
                End Try
                costo1 = exist * precPro
                costo2 = cant * precio
                costoT = CDec((costo1 + costo2) / (exist + cant))
                Return costoT
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Sub limpiar()
        cmbProducto.Focus()
        cmbProducto.SelectAll()
        txtCantidad.Clear()
        txtPrecio.Clear()
        txtImporte.Clear()
        txtNoFacturaR.Clear()
        dgvCompras.Rows.Clear()
        lblSubTotal.Text = "(SubTotal)"
        lblIva.Text = "(IVA)"
        lblTotal.Text = "(Total)"
    End Sub
    Sub ingresarProducto()

    End Sub
    Sub calcular()
        Dim col As DataGridViewRow = dgvCompras.CurrentRow
        Dim suma As Decimal = 0
        Dim importe As Decimal = 0
        Me.iva = 0
        For Each row As DataGridViewRow In dgvCompras.Rows
            importe += row.Cells("Importe").Value
        Next
        iva = importe * 0.15
        suma = importe + iva
        Me.total = suma
        lblSubTotal.Text = importe.ToString("C$ ##,#00.000")
        lblIva.Text = iva.ToString("C$ ##,#00.000")
        lblTotal.Text = suma.ToString("C$ ##,#00.000")
    End Sub
    Sub cargarDatos()
        Using dbCocina As New CocinaDataContext
            Dim reg = (From p In dbCocina.Productos Order By p.Nombre Select p)
            cmbProducto.DataSource = reg
            cmbProducto.DisplayMember = "Nombre"
            cmbProducto.ValueMember = "CodProducto"
            Try
                Dim buscarFact = (From fact In dbCocina.IdTablas Order By fact.IdCompra Descending Select fact).First
                numFactura = buscarFact.IdCompra
                lblFactura.Text = numFactura + 1
                lblFactura.Text = lblFactura.Text.PadLeft(6, "0"c)
            Catch ex As Exception
                lblFactura.Text = "000001"
            End Try
            'Bodegas
            'Dim regBod = (From b In dbCocina.Bodegas Order By b.Nombre Select b)
            'cmbBodega.DataSource = regBod
            'cmbBodega.DisplayMember = "Nombre"
            'cmbBodega.ValueMember = "IdBodega"

            'Proveedor
            Dim regProv = (From p In dbCocina.Proveedor Select p.IdProveedor, p.Codigo, Desc = p.Codigo.PadLeft(3, "0"c) + " | " + p.Nombre)
            cmbProveedor.DataSource = regProv
            cmbProveedor.DisplayMember = "Desc"
            cmbProveedor.ValueMember = "IdProveedor"
            lblProveedor.Text = "(Proveedor)"
        End Using
    End Sub
    Private Sub frmCompras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        diseñoDgv(dgvCompras)
        lblProveedor.Text = verProveedor(cmbProveedor.Text)
        cargarDatos()
    End Sub

    Private Sub cmbProducto_TextChanged(sender As System.Object, e As System.EventArgs) Handles cmbProducto.TextChanged
        Me.cmbProducto.Text.ToUpper()
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        'For Each col As DataGridViewRow In dgvCompras.Rows
        '    If col.Cells(0).Value = lblCodprod.Text Then
        '        MsgBox("El producto seleccionado ya existe en la tabla, puede editar la cantidad de dicho producto en la tabla", _
        '               MsgBoxStyle.Information, "Información de sistema")
        '        Return
        '    End If
        'Next
        If txtCantidad.Text = "" Or txtCantidad.Text = "0" Or txtCantidad.Text = "0.0" Then
            MsgBox("No puede ingresar un producto con una cantidad vacia", MsgBoxStyle.Information, _
                   "Ingresar item")
            Return
        End If
        If txtPrecio.Text = "" Or txtPrecio.Text = "0.0" Then
            MsgBox("No puede ingresar un producto sin precio, especifique el precio para continuar", MsgBoxStyle.Information, _
                               "Ingresar item")
            Return
        ElseIf txtPrecio.Text = "0" Then
            MsgBox("No puede ingresar un producto sin precio, especifique el precio para continuar", MsgBoxStyle.Information, _
                               "Ingresar item")
            Return
        End If
        Try
            Me.dgvCompras.Rows.Add(lblCodprod.Text, cmbProducto.Text, txtCantidad.Text, txtPrecio.Text, txtImporte.Text)
            calcular()
            txtCantidad.Clear()
            txtPrecio.Clear()
            txtImporte.Clear()
            cmbProducto.Focus()
        Catch ex As Exception
            MsgBox("Error al intentar agregar al grid " + ex.Message)
        End Try
    End Sub

    Private Sub txtCantidad_Enter(sender As System.Object, e As System.EventArgs) Handles txtCantidad.Enter
        If txtCantidad.Text.Trim.Length = 0 Then
            Me.txtCantidad.Text = "0"
            txtCantidad.SelectAll()
        Else
            Return
        End If
    End Sub

    Private Sub txtCantidad_Validated(sender As System.Object, e As System.EventArgs) Handles txtCantidad.Validated
        Try
            Dim importe As Decimal
            Dim cantidad As Decimal
            Dim precio As Decimal
            cantidad = Decimal.Parse(txtCantidad.Text, InvariantCulture)
            precio = Decimal.Parse(txtPrecio.Text, InvariantCulture)
            importe = cantidad * precio
            txtImporte.Text = importe.ToString("##,#00.000")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCantidad_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles txtCantidad.Validating
        Try
            Dim importe As Decimal
            importe = CDec(txtPrecio.Text) * CDec(txtCantidad.Text)
            txtImporte.Text = importe
        Catch ex As Exception
            txtImporte.Text = "0"
        End Try
    End Sub


    Private Sub txtCantidad_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        Select Case e.KeyCode
            Case Keys.Left
                If txtCantidad.SelectionStart = 0 Then
                    cmbProducto.Focus()
                End If
            Case Keys.Right
                If txtCantidad.SelectionStart = Len(txtCantidad.Text) Then
                    txtPrecio.Focus()
                End If
            Case Keys.Enter
                txtPrecio.Focus()
                txtPrecio.SelectAll()
                e.Handled = False
        End Select

    End Sub

    Private Sub cmbProducto_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbProducto.KeyDown
        Select Case e.KeyCode
            Case Keys.Right
                If cmbProducto.SelectionStart = Len(cmbProducto.Text) Then
                    txtCantidad.Focus()
                End If
            Case Keys.Enter
                txtCantidad.Focus()
                txtCantidad.SelectAll()
                e.Handled = False
            Case Keys.F5
                If MessageBox.Show("¿Guardar lista de productos de compras al sistema?", "Guardar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    Button2_Click(sender, e)
                End If
        End Select

    End Sub

    Private Sub txtPrecio_Enter(sender As Object, e As System.EventArgs) Handles txtPrecio.Enter
        If Len(txtPrecio.Text) = 0 Then
            Me.txtPrecio.Text = "0"
            txtPrecio.SelectAll()
        Else
            Return
        End If
    End Sub

    Private Sub txtPrecio_Validated(sender As System.Object, e As System.EventArgs) Handles txtPrecio.Validated
        Try
            Dim importe As Decimal
            Dim cantidad As Decimal
            Dim precio As Decimal
            cantidad = Decimal.Parse(txtCantidad.Text, InvariantCulture)
            precio = Decimal.Parse(txtPrecio.Text, InvariantCulture)
            importe = cantidad * precio
            txtImporte.Text = importe.ToString("##,##00.000")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPrecio_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPrecio.KeyDown
        Select Case e.KeyCode
            Case Keys.Right
                If txtPrecio.SelectionStart = Len(txtPrecio.Text) Then
                    btnAgregar.Focus()
                End If
            Case Keys.Left
                If txtPrecio.SelectionStart = 0 Then
                    txtCantidad.Focus()
                End If
            Case Keys.Enter
                btnAgregar.Focus()
                e.Handled = False
        End Select
    End Sub
#Region "Guardar compra"
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If dgvCompras.Rows.Count <= 0 Then
            MsgBox("Error: " + vbCr + "La lista de productos esta vacia", MsgBoxStyle.Information, _
                   "Guardar")
            Return
        End If
        Dim idproveedor As Integer = Convert.ToInt32(cmbProveedor.SelectedValue)
        idFactura = String.Empty
        Dim dao As New DaoCompras()
        'Try
        Dim compra As New Compra
        compra.Fecha = txtFecha.Value
        compra.IdProveedor = idproveedor
        compra.Iva = Me.iva
        compra.Referencia = txtNoFacturaR.Text
        compra.Total = Me.total
        Dim detacompra As New List(Of DetalleCompra)
        'desarrollo para guardar el producto
        For Each columna As DataGridViewRow In dgvCompras.Rows
            Dim deta As New DetalleCompra
            Dim idprod As String = columna.Cells("CodProductos").Value
            'recuperamos la unidad de medida del producto    
            Dim producto = dao.recuperarProducto(idprod)
            Dim unidad = dao.recupearUnidadMedida(producto.IdUnidad)
            Dim descrip As String = columna.Cells("Descripcion").Value
            Dim precioC As Decimal = Convert.ToDecimal(columna.Cells("Precio").Value)
            Dim cant As Decimal = Convert.ToDecimal(columna.Cells("Cantidad").Value)
            deta.Codigo = idprod
            deta.Nombre = producto.Nombre
            deta.Cantidad = cant
            deta.UnidadM = unidad.UdidadM
            deta.PrecioC = precioC
            deta.Fecha = txtFecha.Value
            deta.IdCategoria = producto.IdCategoria
            deta.IdGrupo = producto.IdGrupo
            deta.IdProveedor = idproveedor
            detacompra.Add(deta)
        Next
        If dao.crearCompra(compra, detacompra) Then
            MsgBox("Se ingresó la compra al sistema..", MsgBoxStyle.Information, "Detalle de compra")
            dao.actualizarIdCompra()
            limpiar()
            txtFecha.Focus()
            cargarDatos()
        Else
            MsgBox("Error: " & dao.errorMsg, MsgBoxStyle.Critical, "Error al ingresar la compra")
        End If
        'Catch ex As Exception
        '    MsgBox("Error general al ingresar la compra: " & ex.Message, MsgBoxStyle.Critical, "Error al guardar la compra")
        'End Try
    End Sub
#End Region
    Private Sub btnQuitar_Click(sender As System.Object, e As System.EventArgs) Handles btnQuitar.Click
        Try
            If dgvCompras.Rows.Count = 0 Then
                MsgBox("No hay filas que remover de la tabla", MsgBoxStyle.Information, "Quitar producto")
                Return
            End If
            Dim row As DataGridViewRow = dgvCompras.CurrentRow
            dgvCompras.Rows.Remove(row)
            calcular()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbProducto_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles cmbProducto.Validating
        Try
            Using dboCocina As New CocinaDataContext
                Dim id As String = cmbProducto.SelectedValue
                lblCodprod.Text = id
                Dim ultprecio = (From p In dboCocina.Productos
                                 Where p.CodProducto = id
                                 Select p).Single
                txtPrecio.Text = ultprecio.UltPrecioC
            End Using
        Catch ex As Exception
            txtPrecio.Text = "0"
        End Try
    End Sub

    Private Sub txtCantidad_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        NumeroDec(e, Me.txtCantidad)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio.KeyPress
        NumeroDec(e, Me.txtPrecio)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnProductos_Click(sender As System.Object, e As System.EventArgs) Handles btnProductos.Click
        frmProducto.ShowDialog()
    End Sub

    Private Sub cmbProducto_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbProducto.SelectedValueChanged
        Try
            Using dboCocina As New CocinaDataContext
                Dim id As String = cmbProducto.SelectedValue
                lblCodprod.Text = id
                Dim ultprecio = (From p In dboCocina.Productos
                                 Where p.CodProducto = id
                                 Select p).Single
                txtPrecio.Text = ultprecio.UltPrecioC
            End Using
        Catch ex As Exception
            txtPrecio.Text = "0"
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmProveedor.ShowDialog()
    End Sub

    Private Sub cmbProducto_Validated(sender As System.Object, e As System.EventArgs) Handles cmbProducto.Validated
        Try
            Using dboCocina As New CocinaDataContext
                Dim id As String = cmbProducto.SelectedValue
                lblCodprod.Text = id
                Dim ultprecio = (From p In dboCocina.Productos
                                 Where p.CodProducto = id
                                 Select p).Single
                txtPrecio.Text = ultprecio.UltPrecioC
            End Using
        Catch ex As Exception
            txtPrecio.Text = "0"
        End Try
    End Sub

    Private Sub frmCompras_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If dgvCompras.Rows.Count > 0 Then
            If MessageBox.Show("¿Cerrar el formulario de compras de productos, cualquier cambio hecho no se guardará?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub cmbProveedor_SelectionChangeCommitted(sender As System.Object, e As System.EventArgs) Handles cmbProveedor.SelectionChangeCommitted
        Try
            Using dbCocina As New CocinaDataContext
                Dim id As String = cmbProveedor.SelectedValue
                Dim re = (From p In dbCocina.Proveedor
                          Where p.IdProveedor = id
                          Select p.Nombre).Single
                lblProveedor.Text = re
            End Using
        Catch ex As Exception

        End Try
    End Sub


    Private Sub cmbProveedor_Validated(sender As System.Object, e As System.EventArgs) Handles cmbProveedor.Validated
        Using dbCocina As New CocinaDataContext

            Try
                Dim vprov = (From p In dbCocina.Proveedor
                             Where p.Nombre = lblProveedor.Text
                             Select New With {.Desc = p.Codigo.PadLeft(3, "0"c) + " | " + p.Nombre}).Single
                cmbProveedor.Text = vprov.Desc
            Catch ex As Exception

            End Try
        End Using

    End Sub

    Private Sub cmbProveedor_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbProveedor.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Using dbCocina As New CocinaDataContext
                    Try
                        Dim verReg = (From prov In dbCocina.Proveedor
                                    Where prov.Nombre = lblProveedor.Text
                                    Select Desc = prov.Codigo + " | " + prov.Nombre).Single()

                        cmbProveedor.Text = verReg.PadLeft(4, "0"c)
                        txtNoFacturaR.Focus()
                        txtNoFacturaR.SelectAll()
                    Catch ex As Exception

                    End Try
                End Using
                txtNoFacturaR.Focus()
        End Select
    End Sub

    Private Sub txtNoFacturaR_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNoFacturaR.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                cmbProducto.Focus()
                cmbProducto.SelectAll()
                e.Handled = False
        End Select
    End Sub

    Private Sub cmbProveedor_TextChanged(sender As System.Object, e As System.EventArgs) Handles cmbProveedor.TextChanged
        Using dbCocina As New CocinaDataContext
            Dim filtrar As String = cmbProveedor.Text
            Try
                Dim buscar = (From prov In dbCocina.Proveedor
                              Where prov.Nombre.Contains(filtrar)
                              Select prov.Nombre)
                lblProveedor.Text = buscar.Single()
            Catch ex As Exception

            End Try
        End Using
    End Sub

    Private Sub cmbProveedor_Leave(sender As System.Object, e As System.EventArgs) Handles cmbProveedor.Leave
        Using dbCocina As New CocinaDataContext
            Try
                Dim verReg = (From prov In dbCocina.Proveedor
                            Where prov.Nombre = lblProveedor.Text
                            Select Desc = prov.Codigo.PadLeft(4, "0"c) + " | " + prov.Nombre).Single()
                cmbProveedor.Text = verReg
            Catch ex As Exception
                lblProveedor.Text = "(Proveedor)"
            End Try
        End Using
    End Sub

    Private Sub cmbProveedor_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbProveedor.KeyPress
        Try
            e.KeyChar = e.KeyChar.ToString.ToUpper()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCompras_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompras.CellEndEdit
        Try
            Dim cant As Decimal = 0
            Dim precio As Decimal = 0
            Dim total As Decimal = 0
            Dim iva As Decimal
            Dim suma As Decimal = 0
            For Each col As DataGridViewRow In dgvCompras.Rows
                If col.Cells("Cantidad").Value = 0 Or col.Cells("Cantidad").Value = Nothing Then
                    MsgBox("No puede modificar una cantidad a cero o dejar vacio el campo por favor intente nuevamente", MsgBoxStyle.Information, "Información de sistema")
                    Exit For
                    Return
                End If
                Dim importe As Decimal = 0
                cant = col.Cells("Cantidad").Value
                precio = col.Cells("Precio").Value
                importe = cant * precio
                col.Cells("Importe").Value = importe.ToString("##,##0.000")
                suma += col.Cells("Importe").Value
            Next
            iva = suma * 0.15
            total = suma + iva
            lblSubTotal.Text = suma.ToString("C$ ##,#00.000")
            lblIva.Text = iva.ToString("C$ ##,#00.000")
            lblTotal.Text = total.ToString("C$ ##,#00.000")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEditarCompras_Click(sender As System.Object, e As System.EventArgs) Handles btnEditarCompras.Click
        frmEditCompras.ShowDialog()
    End Sub

    Private Sub cmbProducto_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbProducto.KeyPress
        Try
            e.KeyChar.ToString.ToUpper()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbProveedor_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles cmbProveedor.Validating
        Using dbCocina As New CocinaDataContext
            Try
                Dim id As String = cmbProveedor.SelectedValue
                Dim re = (From p In dbCocina.Proveedor
                          Where p.IdProveedor = id
                          Select p.Nombre).Single
                lblProveedor.Text = re
            Catch ex As Exception

            End Try
            Dim filtrar As String = cmbProveedor.Text
            Try
                Dim buscar = (From prov In dbCocina.Proveedor
                              Where prov.Nombre Like cmbProveedor.Text _
                              Or prov.Codigo Like cmbProveedor.Text
                              Select prov.Nombre)
                lblProveedor.Text = buscar.Single()
            Catch ex As Exception

            End Try
        End Using
    End Sub

    Private Sub txtFecha_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFecha.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    cmbProveedor.Focus()
                    cmbProveedor.SelectAll()
                    e.Handled = False
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtNoFacturaR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoFacturaR.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
        End If
    End Sub
End Class