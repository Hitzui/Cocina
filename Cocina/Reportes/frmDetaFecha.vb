Imports CrystalDecisions.Shared

Public Class frmDetaFecha
    Private aux As Integer = 0
    Private moverFormulario As PanelMovible
    
    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Try
            Using dbCocina As New CocinaDataContext
                Dim rptProd As New rptDetaCompra

                Dim consulta = (From deta In dbCocina.DetalleCompras
                                Where deta.Fecha >= txtFechaDesde.Value And deta.Fecha <= txtFechaHasta.Value
                                Group deta.IdGrupo, deta.IdCategoria, deta.Codigo, deta.Nombre,
                                deta.Cantidad, deta.PrecioC, deta.Fecha, deta.UnidadM
                                By deta.IdGrupo, deta.IdCategoria, deta.Codigo, deta.Nombre, deta.UnidadM
                                Into Cantidad = Sum(Cantidad), Prec = Sum(Cantidad * PrecioC)
                                Join cat In dbCocina.Categoria
                                On IdCategoria Equals cat.IdCategoria
                                Join gr In dbCocina.Grupo
                                On IdGrupo Equals gr.IdGrupo
                                Order By Nombre Ascending
                                Select IdGrupo, IdCategoria, Codigo, Nombre, Cantidad, PrecioC = Prec / Cantidad, Promedio = Prec,
                                UnidadM, cat.Descripcion, NomGr = gr.Descripcion, NomCat = cat.Descripcion)
                rptProd.SetDataSource(consulta)
                frmReportes.rptViewer.ReportSource = rptProd
                crpParametros(txtFechaDesde.Value, txtFechaHasta.Value)
                frmReportes.Show()
                frmReportes.Focus()
            End Using
        Catch ex As Exception
            MsgBox("Error en deta compra: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Label4_Click(sender As System.Object, e As System.EventArgs) Handles lblX.Click
        Me.Close()
    End Sub

    Private Sub Label4_MouseEnter(sender As System.Object, e As System.EventArgs) Handles lblX.MouseEnter
        lblX.ForeColor = Color.Red
    End Sub

    Private Sub lblX_MouseLeave(sender As System.Object, e As System.EventArgs) Handles lblX.MouseLeave
        lblX.ForeColor = Color.White
    End Sub

    Private Sub frmDetaFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.moverFormulario = New PanelMovible(Me)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.moverFormulario.Click(sender, e)
    End Sub

    Private Sub Label3_MouseDown(sender As Object, e As MouseEventArgs) Handles Label3.MouseDown
        Me.moverFormulario.MouseDown(sender, e)
    End Sub

    Private Sub Label3_MouseMove(sender As Object, e As MouseEventArgs) Handles Label3.MouseMove
        Me.moverFormulario.MouseMove(sender, e)
    End Sub

    Private Sub Label3_MouseUp(sender As Object, e As MouseEventArgs) Handles Label3.MouseUp
        Me.moverFormulario.MouseUp(sender, e)
    End Sub
End Class