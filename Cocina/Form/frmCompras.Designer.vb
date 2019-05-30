<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompras))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.lblCodprod = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvCompras = New System.Windows.Forms.DataGridView()
        Me.CodProductos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.txtNoFacturaR = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblFactura = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Img = New System.Windows.Forms.ImageList(Me.components)
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblIva = New System.Windows.Forms.Label()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tool = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnEditarCompras = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnProductos = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lblcosto = New System.Windows.Forms.Label()
        Me.lblBal = New System.Windows.Forms.Label()
        Me.lblInicial = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Teal
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Georgia", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(794, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Detalle de compras"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtImporte)
        Me.GroupBox1.Controls.Add(Me.txtPrecio)
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Controls.Add(Me.cmbProducto)
        Me.GroupBox1.Controls.Add(Me.lblCodprod)
        Me.GroupBox1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 93)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(783, 60)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle:"
        '
        'btnAgregar
        '
        Me.btnAgregar.BackgroundImage = CType(resources.GetObject("btnAgregar.BackgroundImage"), System.Drawing.Image)
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAgregar.Location = New System.Drawing.Point(714, 12)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(45, 41)
        Me.btnAgregar.TabIndex = 9
        Me.tool.SetToolTip(Me.btnAgregar, "Agregar a la lista")
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(597, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 14)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Importe"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(492, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 14)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Precio"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(382, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cantidad:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(113, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Descripción del producto:"
        '
        'txtImporte
        '
        Me.txtImporte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtImporte.Enabled = False
        Me.txtImporte.Location = New System.Drawing.Point(593, 30)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(94, 20)
        Me.txtImporte.TabIndex = 4
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(489, 29)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(88, 20)
        Me.txtPrecio.TabIndex = 3
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(380, 29)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(93, 20)
        Me.txtCantidad.TabIndex = 2
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbProducto
        '
        Me.cmbProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(104, 29)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(260, 22)
        Me.cmbProducto.Sorted = True
        Me.cmbProducto.TabIndex = 1
        '
        'lblCodprod
        '
        Me.lblCodprod.AutoSize = True
        Me.lblCodprod.Location = New System.Drawing.Point(16, 33)
        Me.lblCodprod.Name = "lblCodprod"
        Me.lblCodprod.Size = New System.Drawing.Size(87, 14)
        Me.lblCodprod.TabIndex = 0
        Me.lblCodprod.Text = "(Cod Producto)"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvCompras)
        Me.Panel1.Location = New System.Drawing.Point(3, 159)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(783, 250)
        Me.Panel1.TabIndex = 2
        '
        'dgvCompras
        '
        Me.dgvCompras.AllowUserToAddRows = False
        Me.dgvCompras.AllowUserToDeleteRows = False
        Me.dgvCompras.BackgroundColor = System.Drawing.Color.White
        Me.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCompras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodProductos, Me.Descripcion, Me.Cantidad, Me.Precio, Me.Importe})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCompras.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCompras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCompras.Location = New System.Drawing.Point(0, 0)
        Me.dgvCompras.Name = "dgvCompras"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCompras.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCompras.Size = New System.Drawing.Size(783, 250)
        Me.dgvCompras.TabIndex = 0
        '
        'CodProductos
        '
        Me.CodProductos.HeaderText = "Cod Productos"
        Me.CodProductos.Name = "CodProductos"
        Me.CodProductos.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 80
        '
        'Precio
        '
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        '
        'Importe
        '
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblProveedor)
        Me.GroupBox2.Controls.Add(Me.txtNoFacturaR)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.cmbProveedor)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.lblFactura)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtFecha)
        Me.GroupBox2.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 23)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(783, 64)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(289, 14)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(72, 15)
        Me.lblProveedor.TabIndex = 10
        Me.lblProveedor.Text = "(Proveedor)"
        '
        'txtNoFacturaR
        '
        Me.txtNoFacturaR.Location = New System.Drawing.Point(631, 30)
        Me.txtNoFacturaR.Name = "txtNoFacturaR"
        Me.txtNoFacturaR.Size = New System.Drawing.Size(115, 22)
        Me.txtNoFacturaR.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(630, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 15)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Factura No.:"
        '
        'cmbProveedor
        '
        Me.cmbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(216, 29)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(233, 23)
        Me.cmbProveedor.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(213, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 15)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Proveedor:"
        '
        'lblFactura
        '
        Me.lblFactura.AutoSize = True
        Me.lblFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactura.Location = New System.Drawing.Point(539, 35)
        Me.lblFactura.Name = "lblFactura"
        Me.lblFactura.Size = New System.Drawing.Size(72, 15)
        Me.lblFactura.TabIndex = 2
        Me.lblFactura.Text = "(Nº Factura)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(460, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Compra No:"
        '
        'txtFecha
        '
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecha.Location = New System.Drawing.Point(19, 30)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(163, 22)
        Me.txtFecha.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnGuardar)
        Me.GroupBox3.Controls.Add(Me.btnQuitar)
        Me.GroupBox3.Location = New System.Drawing.Point(276, 415)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(293, 82)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Controles"
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageKey = "save_as.png"
        Me.btnGuardar.ImageList = Me.Img
        Me.btnGuardar.Location = New System.Drawing.Point(153, 26)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(132, 42)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "Guardar Lista"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.tool.SetToolTip(Me.btnGuardar, "Guardar Compra")
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Img
        '
        Me.Img.ImageStream = CType(resources.GetObject("Img.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Img.TransparentColor = System.Drawing.Color.Transparent
        Me.Img.Images.SetKeyName(0, "qutiar.png")
        Me.Img.Images.SetKeyName(1, "save_as.png")
        Me.Img.Images.SetKeyName(2, "nuevo.png")
        Me.Img.Images.SetKeyName(3, "proveedor.png")
        Me.Img.Images.SetKeyName(4, "inventory.ico")
        Me.Img.Images.SetKeyName(5, "editar.ico")
        '
        'btnQuitar
        '
        Me.btnQuitar.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitar.ImageKey = "qutiar.png"
        Me.btnQuitar.ImageList = Me.Img
        Me.btnQuitar.Location = New System.Drawing.Point(12, 26)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(132, 42)
        Me.btnQuitar.TabIndex = 5
        Me.btnQuitar.Text = "Quitar de la lista"
        Me.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.tool.SetToolTip(Me.btnQuitar, "Quitar item de la tabla")
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.lblTotal)
        Me.Panel2.Controls.Add(Me.lblIva)
        Me.Panel2.Controls.Add(Me.lblSubTotal)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(586, 415)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 81)
        Me.Panel2.TabIndex = 4
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(88, 58)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(37, 13)
        Me.lblTotal.TabIndex = 5
        Me.lblTotal.Text = "(Total)"
        '
        'lblIva
        '
        Me.lblIva.AutoSize = True
        Me.lblIva.Location = New System.Drawing.Point(88, 33)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(28, 13)
        Me.lblIva.TabIndex = 4
        Me.lblIva.Text = "(Iva)"
        '
        'lblSubTotal
        '
        Me.lblSubTotal.AutoSize = True
        Me.lblSubTotal.Location = New System.Drawing.Point(88, 11)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(59, 13)
        Me.lblSubTotal.TabIndex = 3
        Me.lblSubTotal.Text = "(Sub Total)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Total:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "IVA:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Sub-Total"
        '
        'btnEditarCompras
        '
        Me.btnEditarCompras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditarCompras.ImageKey = "editar.ico"
        Me.btnEditarCompras.ImageList = Me.Img
        Me.btnEditarCompras.Location = New System.Drawing.Point(171, 16)
        Me.btnEditarCompras.Name = "btnEditarCompras"
        Me.btnEditarCompras.Size = New System.Drawing.Size(75, 60)
        Me.btnEditarCompras.TabIndex = 2
        Me.btnEditarCompras.Text = "Ver Compra"
        Me.btnEditarCompras.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEditarCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tool.SetToolTip(Me.btnEditarCompras, "Agregar Proveedor")
        Me.btnEditarCompras.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageKey = "proveedor.png"
        Me.Button1.ImageList = Me.Img
        Me.Button1.Location = New System.Drawing.Point(90, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 60)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Proveedor"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tool.SetToolTip(Me.Button1, "Agregar Proveedor")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnProductos
        '
        Me.btnProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProductos.ImageKey = "nuevo.png"
        Me.btnProductos.ImageList = Me.Img
        Me.btnProductos.Location = New System.Drawing.Point(6, 16)
        Me.btnProductos.Name = "btnProductos"
        Me.btnProductos.Size = New System.Drawing.Size(75, 60)
        Me.btnProductos.TabIndex = 0
        Me.btnProductos.Text = "Productos"
        Me.btnProductos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tool.SetToolTip(Me.btnProductos, "Agregar Producto")
        Me.btnProductos.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnEditarCompras)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.btnProductos)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 415)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(253, 82)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(153, 500)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'lblcosto
        '
        Me.lblcosto.AutoSize = True
        Me.lblcosto.Location = New System.Drawing.Point(234, 505)
        Me.lblcosto.Name = "lblcosto"
        Me.lblcosto.Size = New System.Drawing.Size(45, 13)
        Me.lblcosto.TabIndex = 10
        Me.lblcosto.Text = "Label12"
        Me.lblcosto.Visible = False
        '
        'lblBal
        '
        Me.lblBal.AutoSize = True
        Me.lblBal.Location = New System.Drawing.Point(82, 505)
        Me.lblBal.Name = "lblBal"
        Me.lblBal.Size = New System.Drawing.Size(45, 13)
        Me.lblBal.TabIndex = 7
        Me.lblBal.Text = "Label12"
        Me.lblBal.Visible = False
        '
        'lblInicial
        '
        Me.lblInicial.AutoSize = True
        Me.lblInicial.Location = New System.Drawing.Point(31, 505)
        Me.lblInicial.Name = "lblInicial"
        Me.lblInicial.Size = New System.Drawing.Size(45, 13)
        Me.lblInicial.TabIndex = 8
        Me.lblInicial.Text = "Label12"
        Me.lblInicial.Visible = False
        '
        'frmCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(794, 522)
        Me.Controls.Add(Me.lblcosto)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.lblInicial)
        Me.Controls.Add(Me.lblBal)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de compras"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodprod As System.Windows.Forms.Label
    Friend WithEvents txtImporte As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvCompras As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFactura As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tool As System.Windows.Forms.ToolTip
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblIva As System.Windows.Forms.Label
    Friend WithEvents lblSubTotal As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents Img As System.Windows.Forms.ImageList
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnProductos As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents lblcosto As System.Windows.Forms.Label
    Friend WithEvents lblBal As System.Windows.Forms.Label
    Friend WithEvents lblInicial As System.Windows.Forms.Label
    Friend WithEvents cmbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents txtNoFacturaR As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents CodProductos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnEditarCompras As System.Windows.Forms.Button
End Class
