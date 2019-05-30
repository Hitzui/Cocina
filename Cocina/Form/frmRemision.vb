Imports System.Globalization.CultureInfo
Imports System.Transactions

Public Class frmRemision
    Dim numFactura As Integer
    Dim idRemision As String
    Dim aux As Integer
    Sub calcular()
        Dim col As DataGridViewRow = dgvRemision.CurrentRow
        Dim suma As Decimal = 0
        Dim importe As Decimal = 0
        Dim iva As Decimal = 0
        For Each row As DataGridViewRow In dgvRemision.Rows
            importe += row.Cells("Importe").Value
        Next
        iva = importe * 0.15
        suma = importe + iva
        lblSubTotal.Text = importe.ToString("C$ ##,#00.00")
        lblIva.Text = iva.ToString("C$ ##,#00.00")
        lblTotal.Text = suma.ToString("C$ ##,#00.00")
    End Sub
    Sub ComboSucursal()
        Using dbCocina As New CocinaDataContext
            'combo box sucursal
            Dim regSuc = (From suc In dbCocina.Sucursal
                         Order By suc.Nombre
                         Select suc)
            cmbSuc.DataSource = regSuc
            cmbSuc.DisplayMember = "Nombre"
            cmbSuc.ValueMember = "IdSucursal"
        End Using
    End Sub
    Sub cargar()
        Try
            Using dbCocina As New CocinaDataContext
                'buscamos remision
                Try
                    Dim buscarFact = (From fact In dbCocina.IdTablas Order By fact.IdRemision Descending Select fact).First
                    numFactura = buscarFact.IdRemision
                    lblRemision.Text = numFactura
                    lblRemision.Text = lblRemision.Text.PadLeft(6, "0"c)
                Catch ex As Exception
                    lblRemision.Text = "000001"
                End Try

                'combo box bodega
                Dim regBod = (From bo In dbCocina.Bodegas
                              Order By bo.Nombre
                              Select bo)
                cmbBodega.DataSource = regBod
                cmbBodega.DisplayMember = "Nombre"
                cmbBodega.ValueMember = "IdBodega"

                'combo box productos
                Dim regProd = From p In dbCocina.Productos
                              Order By p.Nombre
                              Select p

                cmbProducto.DataSource = regProd
                cmbProducto.DisplayMember = "Nombre"
                cmbProducto.ValueMember = "CodProducto"

                'combo box sucursal
                ComboSucursal()
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Sub limpiar()
        txtCantidad.Clear()
        txtPrecio.Clear()
        txtImporte.Clear()
        txtFecha.Value = Now
    End Sub
    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        If txtCantidad.Text = "0.0" Or txtCantidad.Text = "" Or Len(txtCantidad.Text) = 0 Then
            txtCantidad.Focus()
            MsgBox("No puede ingresar un producto sin una cantidad especifica", MsgBoxStyle.Exclamation, "Remisiones")
            Return
        End If
        If txtPrecio.Text = "" Or txtPrecio.Text = "0" Then
            txtPrecio.Focus()
            MsgBox("No puede ingresar un producto sin un precio especifico", MsgBoxStyle.Exclamation, "Remisiones")
            Return
        End If
        'validamos que exista en la bodega
        Try
            Using dbCocina As New CocinaDataContext
                Dim idprod As String = cmbProducto.SelectedValue
                Dim idbod As Integer = cmbBodega.SelectedValue
                Dim cant As Decimal = txtCantidad.Text
                Dim revBod = (From b In dbCocina.DetaBodega
                              Where b.IdBodega = idbod And b.CodProducto = idprod
                              Select b).Single
                If revBod.Existencia <= 0 Then
                    MsgBox("El producto que intenta ingresar no tiene existencia en la bodega", MsgBoxStyle.Critical, "Remisión")
                    Return
                End If
                If revBod.Existencia < cant Then
                    MsgBox("No puede ingresar una cantidad mayor a la existencia del produco en bodega " & vbCr & _
                           "Cantidad a ingresar: " & cant & vbCr & " Existencia en bodega: " & revBod.Existencia, _
                           MsgBoxStyle.Critical, "Remisión")
                    Return
                End If
            End Using
        Catch ex As Exception
            MsgBox("El producto que intenta ingresar no existe en la bodega seleccionada", MsgBoxStyle.Information, "Remisión")
            Return
        End Try
        Try
            For Each cel As DataGridViewRow In dgvRemision.Rows
                If cel.Cells("CodProductos").Value = lblCodprod.Text Then
                    If MsgBox("Producto ya existe en la grilla" + vbCr + "¿Actualizar cantidad?", _
                           MsgBoxStyle.YesNo, "Ingreso de Producto") = MsgBoxResult.Yes Then
                        Dim cant As Decimal
                        cant = Convert.ToDecimal(txtCantidad.Text)
                        cel.Cells("Cantidad").Value = cant
                        cant = Convert.ToDecimal(txtPrecio.Text)
                        cel.Cells("Precio").Value = cant
                        cant = txtImporte.Text
                        cel.Cells("Importe").Value = cant.ToString("C$ ##,#00.00")
                        cant = 0
                        calcular()
                        Return
                    Else
                        Return
                    End If
                End If
            Next
            Me.dgvRemision.Rows.Add(lblCodprod.Text, cmbProducto.Text, txtCantidad.Text, txtPrecio.Text, txtImporte.Text, cmbBodega.Text)
            calcular()
            txtCantidad.Clear()
            txtPrecio.Clear()
            txtImporte.Clear()
        Catch ex As Exception
            MsgBox("Error al intentar agregar al grid " + ex.Message)
        End Try
    End Sub

    Private Sub frmRemision_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        diseñoDgv(dgvRemision)
        cargar()
        limpiar()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmSucursal.ShowDialog()
    End Sub

    Private Sub cmbProducto_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbProducto.SelectedValueChanged
        Try
            Using dbCocina As New CocinaDataContext
                Dim id As String = cmbProducto.SelectedValue
                lblCodprod.Text = id
                Dim reg = (From p In dbCocina.Productos
                           Where p.CodProducto = id
                           Select p).First
                txtPrecio.Text = reg.Costo
                txtCantidad.Focus()
            End Using
        Catch ex As Exception
            txtPrecio.Text = "0"
        End Try
    End Sub

    Private Sub cmbProducto_Validated(sender As Object, e As System.EventArgs) Handles cmbProducto.Validated
        Try
            Using dbCocina As New CocinaDataContext
                Dim id As String = cmbProducto.SelectedValue
                lblCodprod.Text = id
                Dim reg = (From p In dbCocina.Productos
                Where (p.CodProducto = id)
                           Select p).First
                txtPrecio.Text = reg.Costo
            End Using
        Catch ex As Exception
            txtPrecio.Text = "0"
        End Try
    End Sub

    Private Sub txtCantidad_Enter(sender As System.Object, e As System.EventArgs) Handles txtCantidad.Enter
        If txtCantidad.Text.Trim.Length = 0 Then
            Me.txtCantidad.Text = "1.0"
        Else
            Return
        End If
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        Select Case e.KeyCode
            Case Keys.Left
                If txtCantidad.SelectionStart = 0 Then
                    cmbProducto.Focus()
                End If
            Case Keys.Right
                If txtCantidad.SelectionStart = Len(txtCantidad.Text) Then
                    btnAgregar.Focus()
                End If
        End Select
    End Sub

    Private Sub txtCantidad_Validated(sender As Object, e As System.EventArgs) Handles txtCantidad.Validated
        Try
            Dim importe As Decimal
            Dim cantidad As Decimal
            Dim precio As Decimal
            cantidad = Decimal.Parse(txtCantidad.Text, InvariantCulture)
            precio = Decimal.Parse(txtPrecio.Text, InvariantCulture)
            importe = cantidad * precio
            txtImporte.Text = importe.ToString("C$ ##,#00.00")

            Using dbCocina As New CocinaDataContext
                Dim id As String = cmbProducto.SelectedValue
                lblCodprod.Text = id
                Dim reg = (From p In dbCocina.Productos
                Where (p.CodProducto = id)
                           Select p).First
                txtPrecio.Text = reg.Costo
            End Using
        Catch ex As Exception
            txtPrecio.Text = "0"
        End Try
    End Sub

    Private Sub txtPrecio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPrecio.KeyDown
        Select Case e.KeyCode
            Case Keys.Right
                If txtPrecio.SelectionStart = Len(txtPrecio.Text) Then
                    btnAgregar.Focus()
                End If
            Case Keys.Left
                If txtPrecio.SelectionStart = 0 Then
                    txtCantidad.Focus()
                End If
        End Select
    End Sub

    Private Sub txtPrecio_Validated(sender As Object, e As System.EventArgs) Handles txtPrecio.Validated
        Try
            Dim importe As Decimal
            Dim cantidad As Decimal
            Dim precio As Decimal
            cantidad = Decimal.Parse(txtCantidad.Text, InvariantCulture)
            precio = Decimal.Parse(txtPrecio.Text, InvariantCulture)
            importe = cantidad * precio
            txtImporte.Text = importe.ToString("C$ ##,##00.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If dgvRemision.Rows.Count <= 0 Then
            MsgBox("Error: " + vbCr + "La lista de productos esta vacia", MsgBoxStyle.Information, _
                   "Guardar")
            Return
        End If
        Using scope As New TransactionScope()
            Try
                aux = 0
                Dim idbodega As Integer = cmbBodega.SelectedValue
                Dim idsucursal As Integer = cmbSuc.SelectedValue
                Using dbCocina As New CocinaDataContext
                    'revisar existencia para ver si no es mayor la salida que la entrada
                    For Each columna As DataGridViewRow In dgvRemision.Rows
                        Dim id As String = columna.Cells("CodProductos").Value
                        Dim cant As Decimal = columna.Cells("Cantidad").Value
                        Dim desc As String = columna.Cells("Descripcion").Value
                        Dim verExist As Decimal
                        Dim existencia = (From p In dbCocina.DetaBodega
                                          Where p.CodProducto = id And p.IdBodega = idbodega
                                          Select p).Single
                        verExist = existencia.Existencia
                        If verExist < cant Then
                            MsgBox("El Producto Nº " & id & " " & desc & " tiene en existencia " & existencia.Existencia & _
                                   " por tanto no puede retirar " & cant & " de la bodega.", MsgBoxStyle.Information, _
                                   "Retirar producto")
                            aux += 1
                        End If
                    Next
                    If aux > 0 Then
                        Return
                    End If
                    'consultar el ultimo id de factura para seguir
                    Try
                        Dim buscarRem = (From fact In dbCocina.IdTablas Order By fact.IdRemision Descending Select fact).First
                        numFactura = buscarRem.IdRemision + 1
                        idRemision = numFactura
                        idRemision = idRemision.PadLeft(6, "0"c)
                    Catch ex As Exception
                        numFactura = 1
                        idRemision = numFactura
                        idRemision = idRemision.PadLeft(6, "0"c)
                    End Try
                    'ingresamos los datos en la tabla remision

                    Try
                        'actualizamos la secuencia de idremision
                        dbCocina.actIdRemision()
                        'Aceptamos el ingreso de la remision
                        dbCocina.SubmitChanges()
                        MsgBox("Se ingresó la remisión al sistema..", MsgBoxStyle.Information, "Remisiones")
                    Catch ex As Exception
                        MsgBox("Error en ingrso de remisión " & ex.Message)
                    End Try
                    'desarrollo para guardar el producto
                    For Each columna As DataGridViewRow In dgvRemision.Rows
                        Dim id As String = columna.Cells("CodProductos").Value
                        Dim idum As Integer
                        Dim medida As String
                        Dim idgrupo As String
                        Dim idcategoria As String
                        Dim cant As Decimal
                        Dim precioC As Decimal
                        Dim descrip As String
                        Dim idprod As String

                        'recuperamos la unidad de medida del producto
                        Dim recUpr = (From p In dbCocina.Productos
                                      Where p.CodProducto = id
                                      Select p).First
                        idum = recUpr.IdUnidad
                        Dim unidadMed = (From m In dbCocina.Unidad
                                         Where m.IdUnidad = idum
                                         Select m).First
                        medida = unidadMed.UdidadM
                        idgrupo = recUpr.IdGrupo
                        idcategoria = recUpr.IdCategoria
                        idprod = columna.Cells("CodProductos").Value
                        descrip = columna.Cells("Descripcion").Value
                        precioC = Convert.ToDecimal(columna.Cells("Precio").Value)
                        cant = Convert.ToDecimal(columna.Cells("Cantidad").Value)
                        'ingresamos los detalle de la compra
                        'Dim insertDetaRemi As New DetaRemision With {.CodProducto = idprod,
                        '                                                 .Nombre = descrip,
                        '                                                 .Cantidad = cant,
                        '                                                 .IdUnidadM = medida,
                        '                                                 .Precio = precioC,
                        '                                                  .Fecha = txtFecha.Value,
                        '                                                  .IdCategoria = idcategoria,
                        '                                                  .IdGrupo = idgrupo,
                        '                                                  .IdRemision = idRemision,
                        '                                                  .IdBodega = idbodega,
                        '                                                  .IdSucursal = idsucursal}
                        'insertar en la base de datos
                        'dbCocina.DetaRemision.InsertOnSubmit(insertDetaRemi)
                        Try
                            dbCocina.SubmitChanges()
                        Catch ex As Exception
                            MsgBox("Error en funcion " & ex.Message)
                        End Try
                    Next
                    'Ingresamos los productos en las respectivas bodegas
                    'Tambien se ingresa en la tabla kardex los productos
                    For i As Integer = 0 To dgvRemision.Rows.Count - 1
                        Dim idprod As String = dgvRemision.Rows(i).Cells("CodProductos").Value
                        Dim cantIngresar As Decimal = dgvRemision.Rows(i).Cells("Cantidad").Value
                        Dim inicial As Decimal = 0
                        Dim bal As Decimal = 0
                        Try
                            bal = 0
                            inicial = 0
                            Dim actDetaBodega = (From det In dbCocina.DetaBodega
                                             Where det.IdBodega = idbodega And
                                             det.CodProducto = idprod
                                             Select det).Single
                            inicial = actDetaBodega.Existencia
                            bal = inicial - cantIngresar
                            actDetaBodega.Existencia = bal
                        Catch ex As Exception
                            'si no encuentra el producto en la tabla detabodega, entonces lo crea
                            MsgBox("Producto no existe en bodega", MsgBoxStyle.Information, "Remisión")
                            scope.Dispose()
                        End Try
                        Dim newKardex As New Kardex With {.CodProducto = idprod,
                                                               .Inicial = inicial,
                                                               .Balance = bal,
                                                               .Salida = cantIngresar,
                                                               .Entrada = 0,
                                                               .IdBodega = idbodega,
                                                               .Referencia = lblRemision.Text,
                                                               .Fecha = txtFecha.Value}
                        dbCocina.Kardex.InsertOnSubmit(newKardex)
                        Try
                            dbCocina.SubmitChanges()
                        Catch ex As Exception
                            MsgBox("Error al ingresar a bodega los productos " & ex.Message)
                        End Try
                    Next
                    dgvRemision.Rows.Clear()
                End Using
                scope.Complete()
            Catch ex As Exception
                MsgBox("Error en remision: " & ex.Message)
                scope.Dispose()
            End Try

        End Using
    End Sub

    Private Sub btnQuitar_Click(sender As System.Object, e As System.EventArgs) Handles btnQuitar.Click
        Try
            If dgvRemision.Rows.Count = 0 Then
                MsgBox("No hay filas que remover de la tabla", MsgBoxStyle.Information, "Quitar producto")
                Return
            End If
            Dim row As DataGridViewRow = dgvRemision.CurrentRow
            dgvRemision.Rows.Remove(row)
            calcular()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbProducto_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbProducto.KeyDown
        Select Case e.KeyCode
            Case Keys.Left
                If cmbProducto.SelectionStart = 0 Then
                    cmbProducto.Focus()
                End If
            Case Keys.Right
                If cmbProducto.SelectionStart > Len(txtCantidad.Text) Then
                    txtCantidad.Focus()
                End If
        End Select
    End Sub

    Private Sub btnProductos_Click(sender As System.Object, e As System.EventArgs) Handles btnProductos.Click
        frmProducto.ShowDialog()
    End Sub

    Private Sub frmRemision_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show("¿Salir del formulario remisiones?" + vbCr + "Cualquier cambio será omitido", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
End Class