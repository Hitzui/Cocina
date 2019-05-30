Public Class MyMsgBoxStyle
    Dim MyMessageBox As New MsgBoxStyle
    Dim timer As New Timer
    Dim Button_id As String
    Dim disposseFormTimer As Integer
    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
    End Sub
    Public Overloads Function ShowBox(ByVal txtMessage As String) As String
        lblMessage.Text = txtMessage
        ShowDialog()
        Return Button_id
    End Function
    Public Overloads Function ShowBox(ByVal txtMessage As String, ByVal txtTitle As String)
        lblTitle.Text = txtTitle
        lblMessage.Text = txtMessage
        ShowDialog()
        Return Button_id
    End Function
    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub MyMsgBoxStyle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        disposseFormTimer = 30
        lblTimer.Text = disposseFormTimer.ToString()
        timer.Interval = 1000
        timer.Enabled = True
        timer.Start()

    End Sub
End Class