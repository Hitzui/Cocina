Public Class frmEditarRem
    'Sub cargar()
    '    Try
    '        Using dbCocina As New CocinaDataContext
    '            Dim regSuc = (From suc In dbCocina.Sucursal
    '                          Select suc.IdSucursal, suc.Nombre)
    '            cmbSucursal.DataSource = regSuc
    '            cmbSucursal.DisplayMember = "Nombre"
    '            cmbSucursal.ValueMember = "IdSucursal"
    '        End Using
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub Label2_MouseEnter(sender As System.Object, e As System.EventArgs) Handles Label2.MouseEnter
        Label2.ForeColor = Color.Red
    End Sub

    Private Sub Label2_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Label2.MouseLeave
        Label2.ForeColor = Color.White
    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click
        Me.Close()
        frmEditRemision.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
        frmEditRemision.Close()
    End Sub

    Private Sub frmEditarRem_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtRemision.Focus()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Try
            Dim env As Decimal = 0
            Dim numr As String = txtRemision.Text
            Using dbCocina As New CocinaDataContext
                Dim dgvRem As DataGridView = frmEditRemision.dgvRemision
                dgvRem.Rows.Clear()
                Dim prod = (From p In dbCocina.Productos
                            Join um In dbCocina.Unidad On p.IdUnidad Equals um.IdUnidad
                            Select Descripcion = p.Nombre, Codigo = p.CodProducto, UM = um.UdidadM)
                For Each p In prod
                    dgvRem.Rows.Add("", p.Descripcion, p.Codigo, p.UM)
                Next
                Dim vrm = (From rm In dbCocina.Remision2 Where rm.Numremsion = numr Select Enviado = rm.Enviado, rm.Descripcion, Codigo = rm.Codproducto,
                           UM = (From p In dbCocina.Productos Join u In dbCocina.Unidad On p.IdUnidad Equals u.IdUnidad Where rm.Codproducto = p.CodProducto Select u.UdidadM).Single)
                For Each xrm In vrm
                    For i As Integer = 0 To dgvRem.Rows.Count - 1
                        If xrm.Codigo = dgvRem.Rows(i).Cells(2).Value Then
                            dgvRem.Rows.Remove(dgvRem.Rows(i))
                            dgvRem.Rows.Add(xrm.Enviado, xrm.Descripcion, xrm.Codigo, xrm.UM)
                        End If
                    Next
                Next
                Dim ob = (From r In dbCocina.Remision Where r.IdRemision = numr Select r.Observacion).Single
                frmEditRemision.txtObservacion.Text = ob
                frmEditRemision.lblRemision.Text = numr
                frmEditRemision.Show()
            End Using
        Catch ex As Exception
            MsgBox("Error " & ex.Message)
        End Try
    End Sub


    Private Sub txtRemision_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemision.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Enter)
                btnOk_Click(sender, e)
                e.Handled = True
        End Select
    End Sub
End Class