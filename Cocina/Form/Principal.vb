Imports System.Windows.Forms

Public Class Principal

    Private Sub Principal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        frmLogin.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        frmLogin.Dispose()
        Me.Close()
    End Sub

    Private Sub toGrupo_Click(sender As System.Object, e As System.EventArgs) Handles toGrupo.Click
        My.Forms.frmGrupo.MdiParent = Me
        My.Forms.frmGrupo.Show()
    End Sub

    Private Sub toCategoria_Click(sender As System.Object, e As System.EventArgs) Handles toCategoria.Click
        My.Forms.frmCategoria.MdiParent = Me
        My.Forms.frmCategoria.Show()
    End Sub

    Private Sub toProducto_Click(sender As System.Object, e As System.EventArgs) Handles toProducto.Click
        My.Forms.frmProducto.MdiParent = Me
        My.Forms.frmProducto.Show()
    End Sub

    Private Sub UMToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UMToolStripMenuItem.Click
        My.Forms.frmMedidas.MdiParent = Me
        My.Forms.frmMedidas.Show()
    End Sub

    Private Sub SucursalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SucursalToolStripMenuItem.Click
        My.Forms.frmSucursal.MdiParent = Me
        My.Forms.frmSucursal.Show()
    End Sub

    Private Sub CompraToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles CompraToolStripMenuItem1.Click
        My.Forms.frmCompras.MdiParent = Me
        My.Forms.frmCompras.Show()
    End Sub

    Private Sub CrearToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles toUsuario.Click
        My.Forms.frmUsuario.MdiParent = Me
        My.Forms.frmUsuario.Show()
    End Sub

    Private Sub DetallesDeComprasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DetallesDeComprasToolStripMenuItem.Click
        My.Forms.frmDetaFecha.MdiParent = Me
        My.Forms.frmDetaFecha.Show()
    End Sub

    Private Sub SalidaDeProductoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalidaDeProductoToolStripMenuItem.Click
        My.Forms.frmRemisionNuevo.MdiParent = Me
        My.Forms.frmRemisionNuevo.Show()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        My.Forms.frmProducto.MdiParent = Me
        My.Forms.frmProducto.Show()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        My.Forms.frmCategoria.MdiParent = Me
        My.Forms.frmCategoria.Show()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        My.Forms.frmGrupo.MdiParent = Me
        My.Forms.frmGrupo.Show()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        My.Forms.frmCompras.MdiParent = Me
        My.Forms.frmCompras.Show()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        My.Forms.frmRemisionNuevo.MdiParent = Me
        My.Forms.frmRemisionNuevo.Show()
    End Sub

    Private Sub RemisionesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemisionesToolStripMenuItem.Click
        My.Forms.frmDetaRemi.MdiParent = Me
        My.Forms.frmDetaRemi.Show()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProductosToolStripMenuItem.Click
        
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        My.Forms.frmMedidas.MdiParent = Me
        My.Forms.frmMedidas.Show()
    End Sub

    Private Sub BodegasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BodegasToolStripMenuItem.Click
        My.Forms.frmBodega.MdiParent = Me
        My.Forms.frmBodega.Show()
    End Sub

    Private Sub ProveedorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProveedorToolStripMenuItem.Click
        My.Forms.frmProveedor.MdiParent = Me
        My.Forms.frmProveedor.Show()
    End Sub

    Private Sub ComprasPorProveedorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ComprasPorProveedorToolStripMenuItem.Click
        My.Forms.frmPorProveedor.MdiParent = Me
        My.Forms.frmPorProveedor.Show()
    End Sub

    Private Sub GeneralToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GeneralToolStripMenuItem.Click
        My.Forms.frmDetaProducto.MdiParent = Me
        My.Forms.frmDetaProducto.Show()
    End Sub

    Private Sub DetalleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DetalleToolStripMenuItem.Click
        My.Forms.frmRptProd.MdiParent = Me
        My.Forms.frmRptProd.Show()
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        frmCalculadora.MdiParent = Me
        frmCalculadora.Show()
    End Sub
End Class
