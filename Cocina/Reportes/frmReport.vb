Public Class frmReport
    Dim aux As Integer = 0
    Private Sub frmReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        diseñoDgv(dgvReporte)
    End Sub

    Private Sub radDetaCompra_Click(sender As System.Object, e As System.EventArgs) Handles radDetaCompra.Click
        aux = 1
        Try
            Using dbCocina As New CocinaDataContext
                Dim consulta = (From deta In dbCocina.DetalleCompras
                                Group deta.IdGrupo, deta.IdCategoria, deta.Codigo, deta.Nombre,
                                deta.Cantidad, deta.PrecioC, deta.Fecha, deta.UnidadM
                                By deta.IdGrupo, deta.IdCategoria, deta.Codigo, deta.Nombre, deta.UnidadM
                                Into Cantidad = Sum(Cantidad), Prec = Sum(Cantidad * PrecioC)
                                Join cat In dbCocina.Categoria
                                On IdCategoria Equals cat.IdCategoria
                                Join gr In dbCocina.Grupo
                                On IdGrupo Equals gr.IdGrupo
                                Select IdGrupo, IdCategoria, Codigo, Nombre, Cantidad, PrecioC = Prec / Cantidad, Promedio = Prec,
                                UnidadM, cat.Descripcion, NomGr = gr.Descripcion, NomCat = cat.Descripcion)
                dgvReporte.DataSource = consulta
            End Using
        Catch ex As Exception
            MsgBox("Error en deta compra: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            Using dbCocina As New CocinaDataContext
                'Dim rptRemision As New rptRemision
                'Dim reg = (From rm In dbCocina.DetaRemision
                '           Join cat In dbCocina.Categoria
                '           On rm.IdCategoria Equals cat.IdCategoria
                '           Join gr In dbCocina.Grupo
                '           On rm.IdGrupo Equals gr.IdGrupo
                '           Group By Grupo = gr.Descripcion, Categoria = cat.Descripcion,
                '           rm.CodProducto, rm.Nombre
                '           Into Cantidad = Sum(rm.Cantidad), PUnt = Max(rm.Precio), Valor = Sum(rm.Cantidad * rm.Precio)
                '           Select CodProducto, Categoria, Grupo, Nombre, Cantidad, PUnt, Valor)
                'dgvReporte.DataSource = reg
            End Using
        Catch ex As Exception

        End Try
    End Sub
   
End Class