Public Class PanelMovible
    Dim pos As Point = Point.Empty
    Dim mover As Boolean = False
    Dim _form As Form
    Public ReadOnly Property form As Form
        Get
            Return _form
        End Get
    End Property
    Public Sub New()
        'constructor por default
        Me._form = New Form()
    End Sub
    Public Sub New(form As Form)
        Me._form = form
    End Sub

    Public Sub MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        pos = New Point(e.X, e.Y)
        mover = True
    End Sub

    Public Sub MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If mover Then
            Me._form.Refresh()
            Me._form.Location = New Point((Me._form.Left + e.X - pos.X), (Me._form.Top + e.Y - pos.Y))
        End If
    End Sub

    Public Sub MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        mover = False
    End Sub

    Public Sub Click(sender As Object, e As EventArgs)
        Me._form.Refresh()
        Me._form.BringToFront()
    End Sub
End Class
