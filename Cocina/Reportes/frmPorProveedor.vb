Public Class frmPorProveedor
    Private aux As Integer = 0
    Dim moverFormulario As PanelMovible
    Sub cargar()
        Using dbCocina As New CocinaDataContext
            'registro del combobox
            Dim reg = (From p In dbCocina.Proveedor Order By p.Nombre Select p)
            cmbProveedor.DataSource = reg
            cmbProveedor.DisplayMember = "Nombre"
            cmbProveedor.ValueMember = "IdProveedor"
        End Using
    End Sub
    Sub seleccionar(ByVal opcion As Boolean)
        lblProveedor.Visible = opcion
        cmbProveedor.Visible = opcion
    End Sub
    Private Sub lblX_MouseLeave(sender As System.Object, e As System.EventArgs) Handles lblX.MouseLeave
        lblX.ForeColor = Color.White
    End Sub

    Private Sub lblX_MouseEnter(sender As System.Object, e As System.EventArgs) Handles lblX.MouseEnter
        lblX.ForeColor = Color.Red
    End Sub

    Private Sub lblX_Click(sender As System.Object, e As System.EventArgs) Handles lblX.Click
        Me.Close()
    End Sub

    Private Sub radTodos_Click(sender As System.Object, e As System.EventArgs) Handles radTodos.Click
        aux = 0
        seleccionar(False)
    End Sub

    Private Sub radUno_Click(sender As System.Object, e As System.EventArgs) Handles radUno.Click
        aux = 1
        seleccionar(True)
    End Sub

    Private Sub frmPorProveedor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cargar()
        Me.moverFormulario = New PanelMovible(Me)
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Try
            Dim desde As Date = txtDesde.Value
            Dim hasta As Date = txtHasta.Value
            Dim idpro As Integer = cmbProveedor.SelectedValue
            Using dbCocina As New CocinaDataContext
                'Todos
                If aux = 0 Then
                    Dim rptProv As New rptDetaProv
                    Dim reg = (From dc In dbCocina.DetalleCompras
                               Where dc.Fecha >= desde And dc.Fecha <= hasta
                                Select dc.NumFactura, Proveedor = "Todos", CodProducto = dc.Codigo,
                                Descripcion = dc.Nombre, UM = dc.UnidadM, dc.Cantidad, Iva = dc.Cantidad * dc.PrecioC * 0.15,
                                Precio = dc.PrecioC, Importe = dc.Cantidad * dc.PrecioC,
                                Fecha = (From c In dbCocina.Compra Where c.NumFac = dc.NumFactura Select c.Fecha).Single,
                                NoFact = (From c In dbCocina.Compra Where c.NumFac = dc.NumFactura Select c.Referencia).Single)
                    rptProv.SetDataSource(reg)
                    frmReportes.rptViewer.ReportSource = rptProv
                    crpParametros(txtDesde.Value, txtHasta.Value)
                    frmReportes.Show()
                End If
                If aux = 1 Then
                    Dim rptProv As New rptDetaProv
                    Dim reg = (From dc In dbCocina.DetalleCompras
                               Where dc.Fecha >= desde And dc.Fecha <= hasta And dc.IdProveedor = idpro
                               Join p In dbCocina.Proveedor On p.IdProveedor Equals dc.IdProveedor
                                Select dc.NumFactura, Proveedor = p.Nombre, CodProducto = dc.Codigo,
                                Descripcion = dc.Nombre, UM = dc.UnidadM, dc.Cantidad, Iva = dc.Cantidad * dc.PrecioC * 0.15,
                                Precio = dc.PrecioC, Importe = dc.Cantidad * dc.PrecioC,
                                Fecha = (From c In dbCocina.Compra Where c.NumFac = dc.NumFactura Select c.Fecha).Single,
                                NoFact = (From c In dbCocina.Compra Where c.NumFac = dc.NumFactura Select c.Referencia).Single)
                    rptProv.SetDataSource(reg)
                    frmReportes.rptViewer.ReportSource = rptProv
                    crpParametros(txtDesde.Value, txtHasta.Value)
                    frmReportes.Show()
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error al abrir el reporte: " & ex.Message)
        End Try
    End Sub

   
    Private Sub lblTitulo_Click(sender As Object, e As EventArgs) Handles lblTitulo.Click
        Me.moverFormulario.Click(sender, e)
    End Sub

    Private Sub lblTitulo_MouseDown(sender As Object, e As MouseEventArgs) Handles lblTitulo.MouseDown
        Me.moverFormulario.MouseDown(sender, e)
    End Sub

    Private Sub lblTitulo_MouseMove(sender As Object, e As MouseEventArgs) Handles lblTitulo.MouseMove
        Me.moverFormulario.MouseMove(sender, e)
    End Sub

    Private Sub lblTitulo_MouseUp(sender As Object, e As MouseEventArgs) Handles lblTitulo.MouseUp
        Me.moverFormulario.MouseUp(sender, e)
    End Sub
End Class