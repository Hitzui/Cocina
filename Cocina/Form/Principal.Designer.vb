<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toGrupo = New System.Windows.Forms.ToolStripMenuItem()
        Me.toCategoria = New System.Windows.Forms.ToolStripMenuItem()
        Me.toProducto = New System.Windows.Forms.ToolStripMenuItem()
        Me.SucursalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BodegasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompraToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetallesDeComprasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemisionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneralToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetalleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprasPorProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalidaDeProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabCatalogo = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tabMovimientos = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.MenuStrip.SuspendLayout()
        Me.tabControl.SuspendLayout()
        Me.tabCatalogo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tabMovimientos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.Color.AliceBlue
        Me.MenuStrip.BackgroundImage = Global.Cocina.My.Resources.Resources.degradado_menu
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ProductoToolStripMenuItem, Me.CompraToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(786, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsuarioToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileMenu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(60, 20)
        Me.FileMenu.Text = "&Archivo"
        '
        'UsuarioToolStripMenuItem
        '
        Me.UsuarioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toUsuario})
        Me.UsuarioToolStripMenuItem.Name = "UsuarioToolStripMenuItem"
        Me.UsuarioToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.UsuarioToolStripMenuItem.Text = "Usuario"
        '
        'toUsuario
        '
        Me.toUsuario.Name = "toUsuario"
        Me.toUsuario.Size = New System.Drawing.Size(136, 22)
        Me.toUsuario.Text = "&Administrar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(111, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.ExitToolStripMenuItem.Text = "&Salir"
        '
        'ProductoToolStripMenuItem
        '
        Me.ProductoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toGrupo, Me.toCategoria, Me.toProducto, Me.SucursalToolStripMenuItem, Me.UMToolStripMenuItem, Me.BodegasToolStripMenuItem, Me.ProveedorToolStripMenuItem})
        Me.ProductoToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ProductoToolStripMenuItem.Name = "ProductoToolStripMenuItem"
        Me.ProductoToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.ProductoToolStripMenuItem.Text = "&Catalogo"
        '
        'toGrupo
        '
        Me.toGrupo.Name = "toGrupo"
        Me.toGrupo.Size = New System.Drawing.Size(128, 22)
        Me.toGrupo.Text = "&Grupo"
        '
        'toCategoria
        '
        Me.toCategoria.Name = "toCategoria"
        Me.toCategoria.Size = New System.Drawing.Size(128, 22)
        Me.toCategoria.Text = "Ca&tegoria"
        '
        'toProducto
        '
        Me.toProducto.Name = "toProducto"
        Me.toProducto.Size = New System.Drawing.Size(128, 22)
        Me.toProducto.Text = "&Producto"
        '
        'SucursalToolStripMenuItem
        '
        Me.SucursalToolStripMenuItem.Name = "SucursalToolStripMenuItem"
        Me.SucursalToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.SucursalToolStripMenuItem.Text = "&Sucursal"
        '
        'UMToolStripMenuItem
        '
        Me.UMToolStripMenuItem.Name = "UMToolStripMenuItem"
        Me.UMToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.UMToolStripMenuItem.Text = "&U/M"
        '
        'BodegasToolStripMenuItem
        '
        Me.BodegasToolStripMenuItem.Name = "BodegasToolStripMenuItem"
        Me.BodegasToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.BodegasToolStripMenuItem.Text = "Bodegas"
        '
        'ProveedorToolStripMenuItem
        '
        Me.ProveedorToolStripMenuItem.Name = "ProveedorToolStripMenuItem"
        Me.ProveedorToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.ProveedorToolStripMenuItem.Text = "Proveedor"
        '
        'CompraToolStripMenuItem
        '
        Me.CompraToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompraToolStripMenuItem1, Me.ReportesToolStripMenuItem, Me.SalidaDeProductoToolStripMenuItem})
        Me.CompraToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CompraToolStripMenuItem.Name = "CompraToolStripMenuItem"
        Me.CompraToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.CompraToolStripMenuItem.Text = "&Movimiento"
        '
        'CompraToolStripMenuItem1
        '
        Me.CompraToolStripMenuItem1.Name = "CompraToolStripMenuItem1"
        Me.CompraToolStripMenuItem1.Size = New System.Drawing.Size(173, 22)
        Me.CompraToolStripMenuItem1.Text = "&Ingreso de compra"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetallesDeComprasToolStripMenuItem, Me.RemisionesToolStripMenuItem, Me.ProductosToolStripMenuItem, Me.ComprasPorProveedorToolStripMenuItem})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'DetallesDeComprasToolStripMenuItem
        '
        Me.DetallesDeComprasToolStripMenuItem.Name = "DetallesDeComprasToolStripMenuItem"
        Me.DetallesDeComprasToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.DetallesDeComprasToolStripMenuItem.Text = "Detalles de compras"
        '
        'RemisionesToolStripMenuItem
        '
        Me.RemisionesToolStripMenuItem.Name = "RemisionesToolStripMenuItem"
        Me.RemisionesToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.RemisionesToolStripMenuItem.Text = "Remisiones"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneralToolStripMenuItem, Me.DetalleToolStripMenuItem})
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ProductosToolStripMenuItem.Text = "Productos"
        '
        'GeneralToolStripMenuItem
        '
        Me.GeneralToolStripMenuItem.Name = "GeneralToolStripMenuItem"
        Me.GeneralToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.GeneralToolStripMenuItem.Text = "General"
        '
        'DetalleToolStripMenuItem
        '
        Me.DetalleToolStripMenuItem.Name = "DetalleToolStripMenuItem"
        Me.DetalleToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.DetalleToolStripMenuItem.Text = "Detalle"
        '
        'ComprasPorProveedorToolStripMenuItem
        '
        Me.ComprasPorProveedorToolStripMenuItem.Name = "ComprasPorProveedorToolStripMenuItem"
        Me.ComprasPorProveedorToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ComprasPorProveedorToolStripMenuItem.Text = "Compras X Proveedor"
        '
        'SalidaDeProductoToolStripMenuItem
        '
        Me.SalidaDeProductoToolStripMenuItem.Name = "SalidaDeProductoToolStripMenuItem"
        Me.SalidaDeProductoToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SalidaDeProductoToolStripMenuItem.Text = "&Remision"
        '
        'Button1
        '
        Me.Button1.ImageKey = "grupo.ico"
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(4, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 60)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Productos"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Button1, "Ver productos")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "add.png")
        Me.ImageList1.Images.SetKeyName(1, "calendario.png")
        Me.ImageList1.Images.SetKeyName(2, "cancel.png")
        Me.ImageList1.Images.SetKeyName(3, "categoria.ico")
        Me.ImageList1.Images.SetKeyName(4, "compras.ico")
        Me.ImageList1.Images.SetKeyName(5, "delete.png")
        Me.ImageList1.Images.SetKeyName(6, "deshacer.png")
        Me.ImageList1.Images.SetKeyName(7, "error.ico")
        Me.ImageList1.Images.SetKeyName(8, "grupo.ico")
        Me.ImageList1.Images.SetKeyName(9, "inventory.ico")
        Me.ImageList1.Images.SetKeyName(10, "nuevo.png")
        Me.ImageList1.Images.SetKeyName(11, "ok.png")
        Me.ImageList1.Images.SetKeyName(12, "printer.png")
        Me.ImageList1.Images.SetKeyName(13, "producto.ico")
        Me.ImageList1.Images.SetKeyName(14, "proveedor.png")
        Me.ImageList1.Images.SetKeyName(15, "provider.ico")
        Me.ImageList1.Images.SetKeyName(16, "qutiar.png")
        Me.ImageList1.Images.SetKeyName(17, "remision.ico")
        Me.ImageList1.Images.SetKeyName(18, "reporte.ico")
        Me.ImageList1.Images.SetKeyName(19, "save as.png")
        Me.ImageList1.Images.SetKeyName(20, "save.png")
        Me.ImageList1.Images.SetKeyName(21, "save_as.png")
        Me.ImageList1.Images.SetKeyName(22, "sucursal.ico")
        Me.ImageList1.Images.SetKeyName(23, "textura_azul.jpg")
        Me.ImageList1.Images.SetKeyName(24, "title_bar.png")
        Me.ImageList1.Images.SetKeyName(25, "user.ico")
        Me.ImageList1.Images.SetKeyName(26, "user.png")
        Me.ImageList1.Images.SetKeyName(27, "user_adm.ico")
        Me.ImageList1.Images.SetKeyName(28, "warehouse.ico")
        Me.ImageList1.Images.SetKeyName(29, "um.png")
        Me.ImageList1.Images.SetKeyName(30, "calculator.ico")
        '
        'Button2
        '
        Me.Button2.ImageKey = "categoria.ico"
        Me.Button2.ImageList = Me.ImageList1
        Me.Button2.Location = New System.Drawing.Point(85, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 60)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Categoria"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Button2, "Ver categorias")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.ImageKey = "warehouse.ico"
        Me.Button3.ImageList = Me.ImageList1
        Me.Button3.Location = New System.Drawing.Point(166, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 60)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Grupo"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Button3, "Ver grupos")
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.ImageKey = "compras.ico"
        Me.Button4.ImageList = Me.ImageList1
        Me.Button4.Location = New System.Drawing.Point(8, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 60)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "Compras"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Button4, "Detalle de compras")
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.ImageKey = "remision.ico"
        Me.Button5.ImageList = Me.ImageList1
        Me.Button5.Location = New System.Drawing.Point(95, 5)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 60)
        Me.Button5.TabIndex = 2
        Me.Button5.Text = "Remisiones"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Button5, "Detalle de remisiones")
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.BackgroundImage = Global.Cocina.My.Resources.Resources.um
        Me.Button6.ImageKey = "um.png"
        Me.Button6.Location = New System.Drawing.Point(247, 2)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 60)
        Me.Button6.TabIndex = 3
        Me.Button6.Text = "UM"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Button6, "Ver grupos")
        Me.Button6.UseVisualStyleBackColor = True
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.tabCatalogo)
        Me.tabControl.Controls.Add(Me.tabMovimientos)
        Me.tabControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.tabControl.Location = New System.Drawing.Point(0, 24)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(786, 100)
        Me.tabControl.TabIndex = 9
        '
        'tabCatalogo
        '
        Me.tabCatalogo.Controls.Add(Me.Panel2)
        Me.tabCatalogo.Location = New System.Drawing.Point(4, 22)
        Me.tabCatalogo.Name = "tabCatalogo"
        Me.tabCatalogo.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCatalogo.Size = New System.Drawing.Size(778, 74)
        Me.tabCatalogo.TabIndex = 0
        Me.tabCatalogo.Text = "Catalogo"
        Me.tabCatalogo.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Button6)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(338, 68)
        Me.Panel2.TabIndex = 0
        '
        'tabMovimientos
        '
        Me.tabMovimientos.BackColor = System.Drawing.Color.White
        Me.tabMovimientos.Controls.Add(Me.Panel1)
        Me.tabMovimientos.Location = New System.Drawing.Point(4, 22)
        Me.tabMovimientos.Name = "tabMovimientos"
        Me.tabMovimientos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMovimientos.Size = New System.Drawing.Size(778, 74)
        Me.tabMovimientos.TabIndex = 1
        Me.tabMovimientos.Text = "Movimientos"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(267, 68)
        Me.Panel1.TabIndex = 0
        '
        'Button7
        '
        Me.Button7.ImageKey = "calculator.ico"
        Me.Button7.ImageList = Me.ImageList1
        Me.Button7.Location = New System.Drawing.Point(182, 3)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 60)
        Me.Button7.TabIndex = 3
        Me.Button7.Text = "Calculadora"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Button7, "Detalle de remisiones")
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Cocina.My.Resources.Resources.textura_azul
        Me.ClientSize = New System.Drawing.Size(786, 642)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Principal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.tabControl.ResumeLayout(False)
        Me.tabCatalogo.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.tabMovimientos.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toGrupo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toCategoria As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toProducto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SucursalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompraToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toUsuario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ReportesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetallesDeComprasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemisionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalidaDeProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabControl As System.Windows.Forms.TabControl
    Friend WithEvents tabCatalogo As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tabMovimientos As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents BodegasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComprasPorProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GeneralToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetalleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button7 As System.Windows.Forms.Button

End Class
