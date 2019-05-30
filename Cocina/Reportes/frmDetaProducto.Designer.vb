<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetaProducto
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
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.radConsolidado = New System.Windows.Forms.RadioButton()
        Me.radDetallado = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.radTodos = New System.Windows.Forms.RadioButton()
        Me.radConExistencia = New System.Windows.Forms.RadioButton()
        Me.radSinExistencia = New System.Windows.Forms.RadioButton()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.Honeydew
        Me.lblTitulo.Location = New System.Drawing.Point(0, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(424, 23)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "DETALLE DE PRODUCTOS"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'radConsolidado
        '
        Me.radConsolidado.AutoSize = True
        Me.radConsolidado.Checked = True
        Me.radConsolidado.Location = New System.Drawing.Point(28, 23)
        Me.radConsolidado.Name = "radConsolidado"
        Me.radConsolidado.Size = New System.Drawing.Size(83, 17)
        Me.radConsolidado.TabIndex = 1
        Me.radConsolidado.TabStop = True
        Me.radConsolidado.Text = "Consolidado"
        Me.radConsolidado.UseVisualStyleBackColor = True
        '
        'radDetallado
        '
        Me.radDetallado.AutoSize = True
        Me.radDetallado.Location = New System.Drawing.Point(28, 60)
        Me.radDetallado.Name = "radDetallado"
        Me.radDetallado.Size = New System.Drawing.Size(70, 17)
        Me.radDetallado.TabIndex = 2
        Me.radDetallado.TabStop = True
        Me.radDetallado.Text = "Detallado"
        Me.radDetallado.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radConsolidado)
        Me.GroupBox1.Controls.Add(Me.radDetallado)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Generar por:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.radTodos)
        Me.GroupBox2.Controls.Add(Me.radConExistencia)
        Me.GroupBox2.Controls.Add(Me.radSinExistencia)
        Me.GroupBox2.Location = New System.Drawing.Point(219, 38)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalles:"
        '
        'radTodos
        '
        Me.radTodos.AutoSize = True
        Me.radTodos.Location = New System.Drawing.Point(24, 65)
        Me.radTodos.Name = "radTodos"
        Me.radTodos.Size = New System.Drawing.Size(55, 17)
        Me.radTodos.TabIndex = 2
        Me.radTodos.Text = "Todos"
        Me.radTodos.UseVisualStyleBackColor = True
        '
        'radConExistencia
        '
        Me.radConExistencia.AutoSize = True
        Me.radConExistencia.Checked = True
        Me.radConExistencia.Location = New System.Drawing.Point(24, 19)
        Me.radConExistencia.Name = "radConExistencia"
        Me.radConExistencia.Size = New System.Drawing.Size(95, 17)
        Me.radConExistencia.TabIndex = 1
        Me.radConExistencia.TabStop = True
        Me.radConExistencia.Text = "Con Existencia"
        Me.radConExistencia.UseVisualStyleBackColor = True
        '
        'radSinExistencia
        '
        Me.radSinExistencia.AutoSize = True
        Me.radSinExistencia.Location = New System.Drawing.Point(24, 42)
        Me.radSinExistencia.Name = "radSinExistencia"
        Me.radSinExistencia.Size = New System.Drawing.Size(91, 17)
        Me.radSinExistencia.TabIndex = 0
        Me.radSinExistencia.TabStop = True
        Me.radSinExistencia.Text = "Sin Existencia"
        Me.radSinExistencia.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = Global.Cocina.My.Resources.Resources.cancel
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Location = New System.Drawing.Point(243, 144)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(63, 55)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.BackgroundImage = Global.Cocina.My.Resources.Resources.ok
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOk.Location = New System.Drawing.Point(105, 144)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(63, 55)
        Me.btnOk.TabIndex = 6
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'frmDetaProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(424, 209)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblTitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmDetaProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents radConsolidado As System.Windows.Forms.RadioButton
    Friend WithEvents radDetallado As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents radTodos As System.Windows.Forms.RadioButton
    Friend WithEvents radConExistencia As System.Windows.Forms.RadioButton
    Friend WithEvents radSinExistencia As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
