<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRemisionNuevo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRemisionNuevo))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvRemision = New System.Windows.Forms.DataGridView()
        Me.colSalida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExistenciarem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodigorem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcionrem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblRemision = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnEditarCompras = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCargardatos = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSucursal = New System.Windows.Forms.ComboBox()
        Me.txtFiltrar = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvRemision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(711, 20)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Detalle de Remisiones de salida:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.dgvRemision)
        Me.Panel1.Location = New System.Drawing.Point(3, 67)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(708, 327)
        Me.Panel1.TabIndex = 24
        '
        'dgvRemision
        '
        Me.dgvRemision.AllowUserToAddRows = False
        Me.dgvRemision.AllowUserToDeleteRows = False
        Me.dgvRemision.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRemision.BackgroundColor = System.Drawing.Color.White
        Me.dgvRemision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRemision.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSalida, Me.colExistenciarem, Me.colCodigorem, Me.colDescripcionrem})
        Me.dgvRemision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRemision.Location = New System.Drawing.Point(0, 0)
        Me.dgvRemision.Name = "dgvRemision"
        Me.dgvRemision.Size = New System.Drawing.Size(708, 327)
        Me.dgvRemision.TabIndex = 0
        '
        'colSalida
        '
        Me.colSalida.FillWeight = 30.0!
        Me.colSalida.HeaderText = "Salida"
        Me.colSalida.Name = "colSalida"
        '
        'colExistenciarem
        '
        Me.colExistenciarem.FillWeight = 30.0!
        Me.colExistenciarem.HeaderText = "Existencia"
        Me.colExistenciarem.Name = "colExistenciarem"
        '
        'colCodigorem
        '
        Me.colCodigorem.FillWeight = 30.0!
        Me.colCodigorem.HeaderText = "Codigo"
        Me.colCodigorem.Name = "colCodigorem"
        '
        'colDescripcionrem
        '
        Me.colDescripcionrem.HeaderText = "Descripcion"
        Me.colDescripcionrem.Name = "colDescripcionrem"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageKey = "save.png"
        Me.btnGuardar.ImageList = Me.ImageList1
        Me.btnGuardar.Location = New System.Drawing.Point(644, 400)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(55, 42)
        Me.btnGuardar.TabIndex = 25
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Guardar datos")
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "editar.ico")
        Me.ImageList1.Images.SetKeyName(1, "save.png")
        Me.ImageList1.Images.SetKeyName(2, "48.PNG")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(12, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Núm Remisión:"
        '
        'lblRemision
        '
        Me.lblRemision.AutoSize = True
        Me.lblRemision.Location = New System.Drawing.Point(15, 44)
        Me.lblRemision.Name = "lblRemision"
        Me.lblRemision.Size = New System.Drawing.Size(54, 13)
        Me.lblRemision.TabIndex = 29
        Me.lblRemision.Text = "(Remsión)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtObservacion)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 400)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(346, 100)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Observaciones:"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(7, 20)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(333, 74)
        Me.txtObservacion.TabIndex = 0
        '
        'txtFecha
        '
        Me.txtFecha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFecha.Enabled = False
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecha.Location = New System.Drawing.Point(601, 41)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(98, 20)
        Me.txtFecha.TabIndex = 31
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(598, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 15)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Fecha:"
        '
        'btnEditarCompras
        '
        Me.btnEditarCompras.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEditarCompras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditarCompras.ImageKey = "editar.ico"
        Me.btnEditarCompras.ImageList = Me.ImageList1
        Me.btnEditarCompras.Location = New System.Drawing.Point(370, 400)
        Me.btnEditarCompras.Name = "btnEditarCompras"
        Me.btnEditarCompras.Size = New System.Drawing.Size(51, 42)
        Me.btnEditarCompras.TabIndex = 34
        Me.btnEditarCompras.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEditarCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolTip1.SetToolTip(Me.btnEditarCompras, "Editar Remisión")
        Me.btnEditarCompras.UseVisualStyleBackColor = True
        '
        'btnCargardatos
        '
        Me.btnCargardatos.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCargardatos.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargardatos.ImageKey = "48.PNG"
        Me.btnCargardatos.ImageList = Me.ImageList1
        Me.btnCargardatos.Location = New System.Drawing.Point(436, 400)
        Me.btnCargardatos.Name = "btnCargardatos"
        Me.btnCargardatos.Size = New System.Drawing.Size(55, 42)
        Me.btnCargardatos.TabIndex = 37
        Me.btnCargardatos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnCargardatos, "Volver a cargar los datos")
        Me.btnCargardatos.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(468, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Sucursal"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(471, 40)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(121, 21)
        Me.cmbSucursal.TabIndex = 36
        '
        'txtFiltrar
        '
        Me.txtFiltrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltrar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltrar.Location = New System.Drawing.Point(132, 40)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(289, 20)
        Me.txtFiltrar.TabIndex = 38
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(129, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Buscar producto"
        '
        'frmRemisionNuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(711, 512)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtFiltrar)
        Me.Controls.Add(Me.btnCargardatos)
        Me.Controls.Add(Me.cmbSucursal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnEditarCompras)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblRemision)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRemisionNuevo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Remisiones"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvRemision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvRemision As System.Windows.Forms.DataGridView
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRemision As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnEditarCompras As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents colSalida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExistenciarem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigorem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcionrem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCargardatos As System.Windows.Forms.Button
    Friend WithEvents txtFiltrar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
