<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditRemision
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditRemision))
        Me.grpDetalle = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblRemision = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbSucursal = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvRemision = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.GrEnviado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrUnidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpDetalle.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvRemision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDetalle
        '
        Me.grpDetalle.AutoSize = True
        Me.grpDetalle.Controls.Add(Me.Label4)
        Me.grpDetalle.Controls.Add(Me.txtFecha)
        Me.grpDetalle.Controls.Add(Me.lblRemision)
        Me.grpDetalle.Controls.Add(Me.Label3)
        Me.grpDetalle.Controls.Add(Me.cmbSucursal)
        Me.grpDetalle.Controls.Add(Me.Label1)
        Me.grpDetalle.Location = New System.Drawing.Point(13, 13)
        Me.grpDetalle.Name = "grpDetalle"
        Me.grpDetalle.Size = New System.Drawing.Size(759, 59)
        Me.grpDetalle.TabIndex = 0
        Me.grpDetalle.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(402, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 15)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Fecha:"
        '
        'txtFecha
        '
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecha.Location = New System.Drawing.Point(452, 16)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(98, 20)
        Me.txtFecha.TabIndex = 35
        '
        'lblRemision
        '
        Me.lblRemision.AutoSize = True
        Me.lblRemision.Location = New System.Drawing.Point(294, 20)
        Me.lblRemision.Name = "lblRemision"
        Me.lblRemision.Size = New System.Drawing.Size(54, 13)
        Me.lblRemision.TabIndex = 34
        Me.lblRemision.Text = "(Remsión)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(207, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Núm Remisión:"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(71, 16)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(121, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sucursal"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvRemision)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(759, 340)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'dgvRemision
        '
        Me.dgvRemision.AllowUserToAddRows = False
        Me.dgvRemision.AllowUserToDeleteRows = False
        Me.dgvRemision.AllowUserToOrderColumns = True
        Me.dgvRemision.BackgroundColor = System.Drawing.Color.White
        Me.dgvRemision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRemision.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GrEnviado, Me.GrDescripcion, Me.GrCodigo, Me.GrUnidad})
        Me.dgvRemision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRemision.Location = New System.Drawing.Point(3, 16)
        Me.dgvRemision.Name = "dgvRemision"
        Me.dgvRemision.Size = New System.Drawing.Size(753, 321)
        Me.dgvRemision.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(465, 424)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(292, 76)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Cocina.My.Resources.Resources.save
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Location = New System.Drawing.Point(195, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(59, 50)
        Me.Button2.TabIndex = 1
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Cocina.My.Resources.Resources.deshacer
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(23, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(58, 50)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtObservacion)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 424)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(292, 76)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'txtObservacion
        '
        Me.txtObservacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtObservacion.Location = New System.Drawing.Point(3, 16)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(286, 57)
        Me.txtObservacion.TabIndex = 0
        Me.txtObservacion.Text = "Sin observaciones"
        '
        'GrEnviado
        '
        Me.GrEnviado.HeaderText = "Enviado"
        Me.GrEnviado.Name = "GrEnviado"
        Me.GrEnviado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GrEnviado.Width = 50
        '
        'GrDescripcion
        '
        Me.GrDescripcion.HeaderText = "Descripcion"
        Me.GrDescripcion.Name = "GrDescripcion"
        Me.GrDescripcion.ReadOnly = True
        '
        'GrCodigo
        '
        Me.GrCodigo.HeaderText = "Codigo"
        Me.GrCodigo.Name = "GrCodigo"
        Me.GrCodigo.ReadOnly = True
        '
        'GrUnidad
        '
        Me.GrUnidad.HeaderText = "UM"
        Me.GrUnidad.Name = "GrUnidad"
        Me.GrUnidad.ReadOnly = True
        '
        'frmEditRemision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(784, 512)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpDetalle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmEditRemision"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Remisiones"
        Me.grpDetalle.ResumeLayout(False)
        Me.grpDetalle.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvRemision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRemision As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents dgvRemision As System.Windows.Forms.DataGridView
    Friend WithEvents GrEnviado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GrDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GrCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GrUnidad As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
