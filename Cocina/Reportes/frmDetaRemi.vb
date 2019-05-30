Public Class frmDetaRemi
    Private aux As Integer = 0
    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Try
            Using dbCocina As New CocinaDataContext
                Dim idprov As String = cmbProveedor.SelectedValue
                Dim rptRemision As New rptRemision
                Select Case aux
                    Case 0
                        Dim reg = (From rm In dbCocina.Remision
                                   Where rm.Fecha >= txtDesde.Value And rm.Fecha <= txtHasta.Value
                                   Join rm2 In dbCocina.Remision2
                                   On rm.IdRemision Equals rm2.Numremsion
                                   Join suc In dbCocina.Sucursal
                                   On rm.IdSucursal Equals suc.IdSucursal
                                   Select Sucursal = "TODAS", rm2.Codproducto, rm2.Descripcion, rm2.Enviado)
                        rptRemision.SetDataSource(reg)
                    Case 1
                        Dim reg = (From rm In dbCocina.Remision
                                   Where rm.Fecha >= txtDesde.Value And rm.Fecha <= txtHasta.Value And rm.IdSucursal = idprov
                                   Join rm2 In dbCocina.Remision2
                                   On rm.IdRemision Equals rm2.Numremsion
                                   Join suc In dbCocina.Sucursal
                                   On rm.IdSucursal Equals suc.IdSucursal
                                   Select Sucursal = suc.Nombre, rm2.Codproducto, rm2.Descripcion, rm2.Enviado)
                        rptRemision.SetDataSource(reg)
                End Select
                crpParametros(txtDesde.Value, txtHasta.Value)
                frmReportes.rptViewer.ReportSource = rptRemision
                frmReportes.Show()
            End Using
            'Dim reg = (From v In dbCocina.ViewRemision
            '           Where v.Fecha >= txtDesde.Value And v.Fecha <= txtHasta.Value And v.Sucursal = idprov
            '           Group By v.Categoria, v.Nombre, v.Sucursal, v.Grupo
            '           Into PUnt = Average(v.PUnt), Cantidad = Sum(v.Cantidad)
            '           Select Categoria, Nombre, Grupo, Sucursal, PUnt, Cantidad, Valor = (PUnt * Cantidad))
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Sub cargar()
        Using dbCocina As New CocinaDataContext
            Dim suc = From s In dbCocina.Sucursal Select s

            cmbProveedor.DataSource = suc
            cmbProveedor.DisplayMember = "Nombre"
            cmbProveedor.ValueMember = "IdSucursal"
        End Using
    End Sub
    Private Sub frmDetaRemi_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cargar()
    End Sub

    Private Sub radTodos_Click(sender As System.Object, e As System.EventArgs) Handles radTodos.Click
        aux = 0
        lblSuc.Visible = False
        cmbProveedor.Visible = False
    End Sub

    Private Sub radUno_Click(sender As System.Object, e As System.EventArgs) Handles radUno.Click
        aux = 1
        lblSuc.Visible = True
        cmbProveedor.Visible = True
    End Sub
End Class