Public Class frmRptProd
    Dim moverFormulario As PanelMovible
    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        If Len(txtCodigo.Text) <= 0 Then
            MsgBox("Especifique un código de producto para continuar", MsgBoxStyle.Information, "Buscar producto")
            Return
        End If
        Using dbCocina As New CocinaDataContext
            Try
                Dim rptProd As New rptDetaProducto
                Dim reg = From t In dbCocina.DetalleCompras _
                          Where t.Codigo = txtCodigo.Text And _
                          t.Fecha >= txtDesde.Value And t.Fecha <= txtHasta.Value
                          Order By t.NumFactura _
                          Join p In dbCocina.Proveedor On t.IdProveedor Equals p.IdProveedor
                          Join c In dbCocina.Compra On t.NumFactura Equals c.NumFac
                          Select CodProducto = t.Codigo, Descripcion = t.Nombre, UM = t.UnidadM, t.Cantidad, _
                          Precio = t.PrecioC, t.NumFactura, t.Fecha, Importe = t.PrecioC * t.Cantidad, _
                          Proveedor = p.Nombre, Factura = c.Referencia
                rptProd.SetDataSource(reg)
                frmReportes.rptViewer.ReportSource = rptProd
                crpParametros(txtDesde.Value, txtHasta.Value)
                frmReportes.Show()
            Catch ex As Exception

            End Try
        End Using
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lblX_MouseEnter(sender As System.Object, e As System.EventArgs) Handles lblX.MouseEnter
        lblX.ForeColor = Color.Red
    End Sub

    Private Sub lblX_MouseLeave(sender As System.Object, e As System.EventArgs) Handles lblX.MouseLeave
        lblX.ForeColor = Color.White
    End Sub

    Private Sub lblX_Click(sender As System.Object, e As System.EventArgs) Handles lblX.Click
        Me.Close()
    End Sub

    Private Sub frmRptProd_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtCodigo.Focus()
        Me.moverFormulario = New PanelMovible(Me)
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