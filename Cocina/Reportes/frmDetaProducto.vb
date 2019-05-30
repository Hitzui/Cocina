Public Class frmDetaProducto
    Dim aux As Integer = 0
    Dim exist As Integer = 0
    Dim moverFormulario As PanelMovible
    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Try
            Using dbCocina As New CocinaDataContext
                Select Case aux
                    Case 0
                        Select Case exist
                            Case 0
                                'con existencias
                                Dim rptRemision As New rptConsolidadoProductos
                                Dim reg = (From v In dbCocina.VistaProd
                                           Where v.Existencia > 0
                                           Select v)
                                rptRemision.SetDataSource(reg)
                                frmReportes.rptViewer.ReportSource = rptRemision
                                frmReportes.Show()
                            Case 1
                                'sin existencias
                                Dim rptRemision As New rptConsolidadoProductos
                                Dim reg = (From v In dbCocina.VistaProd
                                           Group v.Bodega, v.CodProducto, v.Nombre, v.Existencia, v.Costo, v.UdidadM, v.Total
                                           By v.CodProducto, v.Nombre, v.UdidadM
                                           Into Exist = Sum(Existencia), Costo = Max(Costo), Total = Max(Total), gr = Group
                                           Where Exist = 0
                                           Order By Nombre Ascending
                                           Select CodProducto, Costo, Existencia = Exist, Nombre, Total, UdidadM)
                                rptRemision.SetDataSource(reg)
                                frmReportes.rptViewer.ReportSource = rptRemision
                                frmReportes.Show()
                            Case 2
                                'todos
                                Dim rptRemision As New rptConsolidadoProductos
                                Dim reg = (From v In dbCocina.VistaProd Order By v.Nombre
                                           Select v)
                                rptRemision.SetDataSource(reg)
                                frmReportes.rptViewer.ReportSource = rptRemision
                                frmReportes.Show()
                        End Select
                    Case 1
                        Select Case exist
                            Case 0
                                'con existencias
                                Dim rptRemision As New rptProducto
                                Dim reg = (From v In dbCocina.VistaProd
                                           Where v.Existencia > 0
                                           Order By v.Nombre Ascending
                                           Select v)
                                rptRemision.SetDataSource(reg)
                                frmReportes.rptViewer.ReportSource = rptRemision
                                frmReportes.Show()
                            Case 1
                                'sin existencias
                                Dim rptRemision As New rptProducto
                                Dim reg = (From v In dbCocina.VistaProd
                                           Group v.Bodega, v.CodProducto, v.Nombre, v.Existencia, v.Costo, v.UdidadM, v.Total
                                           By v.CodProducto, v.Nombre, v.UdidadM
                                           Into Exist = Sum(Existencia), Costo = Max(Costo), Total = Max(Total), gr = Group
                                           Where Exist = 0 Order By Nombre Ascending
                                           Select CodProducto, Costo, Existencia = Exist, Nombre, Total, UdidadM)
                                rptRemision.SetDataSource(reg)
                                frmReportes.rptViewer.ReportSource = rptRemision
                                frmReportes.Show()
                            Case 2
                                'todos
                                Dim rptRemision As New rptProducto
                                Dim reg = (From v In dbCocina.VistaProd
                                          Order By v.Nombre Ascending Select v)
                                rptRemision.SetDataSource(reg)
                                frmReportes.rptViewer.ReportSource = rptRemision
                                frmReportes.Show()
                        End Select
                End Select
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

   
    Private Sub radConsolidado_Click(sender As System.Object, e As System.EventArgs) Handles radConsolidado.Click
        aux = 0
    End Sub

    Private Sub radDetallado_Click(sender As System.Object, e As System.EventArgs) Handles radDetallado.Click
        aux = 1
    End Sub


    Private Sub radConExistencia_Click(sender As System.Object, e As System.EventArgs) Handles radConExistencia.Click
        exist = 0
    End Sub

    Private Sub radSinExistencia_Click(sender As System.Object, e As System.EventArgs) Handles radSinExistencia.Click
        exist = 1
    End Sub

    Private Sub radTodos_Click(sender As System.Object, e As System.EventArgs) Handles radTodos.Click
        exist = 2
    End Sub

    Private Sub frmDetaProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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