<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalculadora
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalculadora))
        Me.UltraCalculator1 = New Infragistics.Win.UltraWinEditors.UltraWinCalc.UltraCalculator()
        CType(Me.UltraCalculator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraCalculator1
        '
        Me.UltraCalculator1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraCalculator1.Location = New System.Drawing.Point(0, 0)
        Me.UltraCalculator1.Name = "UltraCalculator1"
        Me.UltraCalculator1.Size = New System.Drawing.Size(284, 262)
        Me.UltraCalculator1.TabIndex = 0
        Me.UltraCalculator1.Text = "0."
        '
        'frmCalculadora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.UltraCalculator1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCalculadora"
        Me.Text = "Calculadora"
        CType(Me.UltraCalculator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraCalculator1 As Infragistics.Win.UltraWinEditors.UltraWinCalc.UltraCalculator
End Class
