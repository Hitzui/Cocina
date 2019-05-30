Imports System.Globalization.CultureInfo
Imports System.Transactions
Imports System.Drawing.Drawing2D.LinearGradientBrush
Imports System.Drawing.Drawing2D

Public Class frmEditCompras
    Dim numFactura As Integer
    Dim idFactura As String
    Dim cant As Decimal = 0
    Dim suma As Decimal = 0
    Dim iva As Decimal = 0
    Dim imp As Decimal = 0
    Dim prec As Decimal = 0
    Sub limpiar()
        dgvCompras.Rows.Clear()
        txtCantidad.Clear()
        txtPrecio.Clear()
        txtCompra.Clear()
        txtNoFacturaR.Clear()
        cmbProveedor.Focus()
        cmbProveedor.SelectAll()
    End Sub
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
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        Using br As New LinearGradientBrush(Me.ClientRectangle, Color.FromArgb(185, 195, 213), Color.FromArgb(226, 233, 245), 90.0F)
            e.Graphics.FillRectangle(br, Me.ClientRectangle)
        End Using

    End Sub
    Sub calcular()
        suma = 0
        iva = 0
        imp = 0
        Try
            For Each col As DataGridViewRow In dgvCompras.Rows
                suma += col.Cells(4).Value
            Next
            iva = suma * 0.15
            imp = suma + iva
            lblSubTotal.Text = suma.ToString("C$ ##,##0.000")
            lblIva.Text = iva.ToString("C$ ##,##0.000")
            lblTotal.Text = imp.ToString("C$ ##,##0.00")
        Catch ex As Exception

        End Try
    End Sub
    Sub cargarDatos()
        Using dbCocina As New CocinaDataContext
            Dim reg = (From p In dbCocina.Productos Order By p.Nombre Select p)
            cmbProducto.DataSource = reg
            cmbProducto.DisplayMember = "Nombre"
            cmbProducto.ValueMember = "CodProducto"


            'Proveedor
            Dim regProv = (From p In dbCocina.Proveedor Select p.IdProveedor, p.Codigo, Desc = p.Codigo.PadLeft(3, "0"c) + " | " + p.Nombre)
            cmbProveedor.DataSource = regProv
            cmbProveedor.DisplayMember = "Desc"
            cmbProveedor.ValueMember = "IdProveedor"
            lblProveedor.Text = "(Proveedor)"
        End Using
    End Sub
    Private Sub frmEditCompras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        diseñoDgv(dgvCompras)
        Me.limpiar()
        cargarDatos()
    End Sub

    Private Sub lblClose_Click(sender As System.Object, e As System.EventArgs)
        If MessageBox.Show("¿Salir de la edición de compras?", "Salir", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
            Return
        Else
            Me.Close()
        End If
    End Sub


    Private Sub txtCompra_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCompra.KeyPress
        Try
            Dim numcompra As String = txtCompra.Text
            Select Case e.KeyChar
                Case ChrW(Keys.Enter)
                    dgvCompras.Rows.Clear()
                    e.Handled = True
                    Try
                        Using dbCocina As New CocinaDataContext
                            Dim compra = (From c In dbCocina.Compra Where c.NumFac = numcompra Select c).First()
                            Dim verCompra = (From dc In dbCocina.DetalleCompras
                                             Where dc.NumFactura = numcompra
                                             Select New With {.CodProductos = dc.Codigo, .Descripcion = dc.Nombre,
                                                              .Cantidad = dc.Cantidad, .Precio = dc.PrecioC,
                                                              .Importe = dc.PrecioC * dc.Cantidad})
                            'Dim proveedor = (From p In dbCocina.Proveedor
                            '                 Where p.IdProveedor = compra.IdProveedor Select p)
                            For Each ssc In verCompra
                                dgvCompras.Rows.Add(ssc.CodProductos, ssc.Descripcion, ssc.Cantidad, ssc.Precio, ssc.Importe)
                            Next
                            Dim verRef = (From c In dbCocina.Compra Where c.NumFac = numcompra
                                          Select c.Referencia).Single()
                            txtNoFacturaR.Text = verRef
                            txtNoFacturaR.Focus()
                            txtNoFacturaR.SelectAll()
                            Me.txtFecha.Value = compra.Fecha
                            Me.cmbProveedor.SelectedValue = compra.IdProveedor
                        End Using
                        calcular()
                    Catch ex As Exception

                    End Try
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbProveedor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbProveedor.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    txtCompra.Focus()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbProveedor_Validated(sender As System.Object, e As System.EventArgs) Handles cmbProveedor.Validated
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

    Private Sub dgvCompras_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompras.CellEndEdit
        Try
            Dim total As Decimal = 0
            suma = 0
            imp = 0
            cant = 0
            For Each col As DataGridViewRow In dgvCompras.Rows
                prec = col.Cells(3).Value
                cant = col.Cells(2).Value
                imp = prec * cant
                col.Cells(4).Value = imp.ToString("##,##0.000")
                suma += col.Cells(4).Value
            Next
            iva = suma * 0.15
            total = suma + iva
            lblIva.Text = iva.ToString("C$ ##,##0.000")
            lblSubTotal.Text = suma.ToString("C$ ##,##0.000")
            lblTotal.Text = total.ToString("C$ ##,##0.000")
        Catch ex As Exception

        End Try
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
            Case Keys.F5
                If MessageBox.Show("¿Guardar lista de productos de compras al sistema?", "Guardar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    btnGuardar_Click(sender, e)
                End If
        End Select
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            Me.calcular()
            If dgvCompras.Rows.Count <= 0 Then
                MsgBox("La tabla de datos esta vacia, por favor intente nuevamente", MsgBoxStyle.Information, "Información de sistema")
                Return
            End If
            Dim dao As New DaoCompras()
            Dim numr As String = txtCompra.Text
            Dim numf As String = txtNoFacturaR.Text
            Dim idproveedor As Integer = cmbProveedor.SelectedValue
            'ingresamos los datos en la tabla compras
            Dim ingresarCompra As New Compra With {.NumFac = numr,
                                                   .Fecha = txtFecha.Value,
                                                   .Total = imp,
                                                   .IdProveedor = idproveedor,
                                                   .Referencia = txtNoFacturaR.Text,
                                                   .Iva = iva}
            'desarrollo para guardar el producto
            Dim listarDetalleCompra As New List(Of DetalleCompra)
            For Each columna As DataGridViewRow In dgvCompras.Rows
                Dim id As String = columna.Cells("CodProductos").Value
                Dim prod As Productos = dao.recuperarProducto(id)
                Dim idum As Integer = prod.IdUnidad
                Dim uni As Unidad = dao.recupearUnidadMedida(idum)
                Dim medida As String = uni.UdidadM
                Dim idgrupo As String = prod.IdGrupo
                Dim idcategoria As String = prod.IdCategoria
                Dim cant As Decimal
                Dim precioC As Decimal
                Dim descrip As String
                descrip = columna.Cells("Descripcion").Value
                precioC = Convert.ToDecimal(columna.Cells("Precio").Value)
                cant = Convert.ToDecimal(columna.Cells("Cantidad").Value)
                'ingresamos los detalle de la compra
                Dim ingresarDetaCompra As New DetalleCompra With {.Codigo = id,
                                                                 .Nombre = descrip,
                                                                 .Cantidad = cant,
                                                                 .UnidadM = medida,
                                                                 .PrecioC = precioC,
                                                                  .Fecha = txtFecha.Value,
                                                                  .IdCategoria = idcategoria,
                                                                  .IdGrupo = idgrupo,
                                                                  .NumFactura = numr,
                                                                  .IdProveedor = idproveedor}
                listarDetalleCompra.Add(ingresarDetaCompra)
            Next
            If dao.actualizarCompra(ingresarCompra, listarDetalleCompra) Then
                MsgBox("Se a actualizado la compra seleccionada de forma correcta")
                Me.limpiar()
            Else
                MsgBox("Se produjo el siguiente error: " & dao.errorMsg)
            End If
        Catch ex As Exception
            MsgBox("Error al intentar actualizar la compra por: " & ex.Message)
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
        End Select
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
        End Select
    End Sub
    Private Sub txtCantidad_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Enter)
                e.Handled = True
        End Select
        NumeroDec(e, Me.txtCantidad)
    End Sub

    Private Sub txtPrecio_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio.KeyPress
        NumeroDec(e, Me.txtPrecio)
        Select Case e.KeyChar
            Case ChrW(Keys.Enter)
                e.Handled = True
        End Select
    End Sub

    Private Sub txtCantidad_Validated(sender As System.Object, e As System.EventArgs) Handles txtCantidad.Validated
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

    Private Sub txtPrecio_Validated(sender As System.Object, e As System.EventArgs) Handles txtPrecio.Validated
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

    Private Sub txtCantidad_Enter(sender As System.Object, e As System.EventArgs) Handles txtCantidad.Enter
        If txtCantidad.Text.Trim.Length = 0 Then
            Me.txtCantidad.Text = "0"
            txtCantidad.SelectAll()
        Else
            Return
        End If
    End Sub

    Private Sub txtPrecio_Enter(sender As System.Object, e As System.EventArgs) Handles txtPrecio.Enter
        If Len(txtPrecio.Text) = 0 Then
            Me.txtPrecio.Text = "0"
            txtPrecio.SelectAll()
        Else
            Return
        End If
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

    Private Sub cmbProveedor_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbProveedor.KeyPress
        Try
            Select Case e.KeyChar
                Case ChrW(Keys.Enter)
                    e.Handled = True
                    txtCompra.Focus()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        For Each col As DataGridViewRow In dgvCompras.Rows
            If col.Cells(0).Value = lblCodprod.Text Then
                MsgBox("El producto seleccionado ya existe en la tabla, puede editar la cantidad de dicho producto en la tabla", _
                       MsgBoxStyle.Information, "Información de sistema")
                Return
            End If
        Next
        If txtCantidad.Text = "" Or txtCantidad.Text = "0" Or txtCantidad.Text = "0.0" Then
            MsgBox("No puede ingresar un producto con una cantidad vacia", MsgBoxStyle.Information, _
                   "Ingresar item")
            txtCantidad.Focus()
            txtCantidad.SelectAll()
            Return
        End If
        If txtPrecio.Text = "" Or txtPrecio.Text = "0.0" Then
            MsgBox("No puede ingresar un producto sin precio, especifique el precio para continuar", MsgBoxStyle.Information, _
                               "Ingresar item")
            Return
        ElseIf txtPrecio.Text = "0" Then
            MsgBox("No puede ingresar un producto sin precio, especifique el precio para continuar", MsgBoxStyle.Information, _
                               "Ingresar item")
            txtPrecio.Focus()
            txtPrecio.SelectAll()
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

    Private Sub txtNoFacturaR_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoFacturaR.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Enter)
                cmbProducto.Focus()
                cmbProducto.SelectAll()
                e.Handled = True
        End Select
    End Sub

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
End Class