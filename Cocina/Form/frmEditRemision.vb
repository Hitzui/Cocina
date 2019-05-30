Public Class frmEditRemision
    Sub cargar()
        Try
            Using dbCocina As New CocinaDataContext
                Dim regSuc = (From suc In dbCocina.Sucursal
                              Select suc.IdSucursal, suc.Nombre)
                cmbSucursal.DataSource = regSuc
                cmbSucursal.DisplayMember = "Nombre"
                cmbSucursal.ValueMember = "IdSucursal"
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmEditRemision_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        diseñoDgv(dgvRemision)
        cargar()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            Dim suma As Decimal = 0
            Dim numr As String = lblRemision.Text
            Dim idsuc As Integer = cmbSucursal.SelectedValue
            Using dbCocina As New CocinaDataContext
                Try
                    Dim xrm = (From rm In dbCocina.Remision2 Where rm.Numremsion = numr Select rm)
                    Dim yrm = (From r In dbCocina.Remision Where r.IdRemision = numr Select r).Single
                    dbCocina.Remision.DeleteOnSubmit(yrm)
                    For Each vrm In xrm
                        dbCocina.Remision2.DeleteOnSubmit(vrm)
                    Next
                Catch ex As Exception
                    MsgBox("error al buscar: " & ex.Message)
                    Return
                End Try
                For Each col As DataGridViewRow In dgvRemision.Rows
                    Dim cod As String = col.Cells(2).Value
                    Dim umd As String = col.Cells(3).Value
                    Dim env As Decimal = 0
                    If col.Cells(0).Value = Nothing Then
                        env = 0
                    Else
                        env = col.Cells(0).Value
                    End If
                    Dim dscr As String = col.Cells(1).Value
                    If env > 0 Then
                        Dim inrm As New Remision2 With {.Codproducto = cod,
                                                       .Descripcion = dscr,
                                                       .Enviado = env,
                                                        .UnidadM = umd,
                                                       .Numremsion = numr}
                        dbCocina.Remision2.InsertOnSubmit(inrm)
                    End If
                Next
                Dim ingrm As New Remision With {.IdRemision = numr, .Fecha = txtFecha.Value,
                                                .Observacion = txtObservacion.Text, .IdSucursal = idsuc}
                dbCocina.Remision.InsertOnSubmit(ingrm)
                Try
                    dbCocina.SubmitChanges()
                    MsgBox("Registro modificado correctamente", MsgBoxStyle.Information, "Remisión")
                    Me.Close()
                Catch ex As Exception
                    MsgBox("No se puede actualizar la remision: " & ex.Message)
                End Try
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class