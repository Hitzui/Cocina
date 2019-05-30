Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Module Mod1Dim
    Dim con As New SqlConnection(My.Settings.cocinaConnectionString)
    Dim Parametros As ParameterFields = New ParameterFields()
    Dim parDesde As ParameterField = New ParameterField()
    Dim parHasta As ParameterField = New ParameterField()
    Dim disDesde As ParameterDiscreteValue = New ParameterDiscreteValue()
    Dim disHasta As ParameterDiscreteValue = New ParameterDiscreteValue()
    Dim cnn As New SqlConnection(My.Settings.cocinaConnectionString)
    Public Sub diseñoDgv(ByVal dgv As DataGridView)
        Try
            dgv.DefaultCellStyle.BackColor = Color.White
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(191, 201, 217)
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            'dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
            'dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            dgv.RowHeadersWidthSizeMode = _
                DataGridViewRowHeadersWidthSizeMode.DisableResizing
            dgv.ColumnHeadersHeightSizeMode = _
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            MsgBox("Error al diseñar el grid en modulos" & ex.Message)
        End Try
    End Sub
    Public Function NumeroDec(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal Text As TextBox) As Integer
        Try
            Dim dig As Integer = Len(Text.Text & e.KeyChar)
            Dim a, esDecimal, NumDecimales As Integer
            Dim esDec As Boolean
            ' se verifica si es un digito o un punto 
            If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
                Return a
            Else
                e.Handled = True
            End If
            ' se verifica que el primer digito ingresado no sea un punto al seleccionar
            If Text.SelectedText <> "" Then
                If e.KeyChar = "." Then
                    e.Handled = True
                    Return a
                End If
            End If
            If dig = 1 And e.KeyChar = "." Then
                e.Handled = True
                Return a
            End If
            'aqui se hace la verificacion cuando es seleccionado el valor del texto
            'y no sea considerado como la adicion de un digito mas al valor ya contenido en el textbox
            If Text.SelectedText = "" Then
                ' aqui se hace el for para controlar que el numero sea de dos digitos - contadose a partir del punto decimal.
                For a = 0 To dig - 1
                    Dim car As String = CStr(Text.Text & e.KeyChar)
                    If car.Substring(a, 1) = "." Then
                        esDecimal = esDecimal + 1
                        esDec = True
                    End If
                    If esDec = True Then
                        NumDecimales = NumDecimales + 1
                    End If
                    ' aqui se controla los digitos a partir del punto numdecimales = 4 si es de dos decimales 
                    If NumDecimales >= 5 Or esDecimal >= 2 Then
                        e.Handled = True
                    End If
                Next
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Sub crpParametros(ByVal desde As String, ByVal hasta As String)

        'Nombre del Parametro definido dentro de “Campos de Parametros” del Crystal..

        parDesde.ParameterFieldName = "Desde"
        parHasta.ParameterFieldName = "Hasta"
        'Paso los Datos

        disDesde.Value = desde
        disHasta.Value = hasta

        parDesde.CurrentValues.Add(disDesde)
        parHasta.CurrentValues.Add(disHasta)
        'Cargo los parametros y los envio al Crystal
        Parametros.Add(parDesde)
        Parametros.Add(parHasta)
        frmReportes.rptViewer.ParameterFieldInfo = Parametros
    End Sub
    Public Sub AbrirConexion()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception
            MsgBox("No se pudo abrir la conexion" & ex.Message)
        End Try
    End Sub
    Public Sub CerrarConexion()
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MsgBox("No se pudo cerrar la conexion" & ex.Message)
        End Try
    End Sub
End Module
