Public Class frmRemisionNuevo

#Region "Valida columna numerica en el grid"
    '----------------------------------------------------------------------------------
    '
    '
    ' INICIO RUTINA PARA VALIDAR CAMPOS NUMÉRICOS EN DATAGRIDVIEW
    '
    '
    '----------------------------------------------------------------------------------
    Private WithEvents cellTextBox As DataGridViewTextBoxEditingControl

    Private Sub cellTextBox_KeyDown( _
        ByVal sender As Object, _
        ByVal e As System.Windows.Forms.KeyEventArgs) Handles cellTextBox.KeyDown

    End Sub

    Private Sub cellTextBox_KeyPress( _
     ByVal sender As Object, _
     ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cellTextBox.KeyPress

        ' Referenciamos el control TextBox subyacente.
        '
        Dim tb As TextBox = TryCast(sender, TextBox)

        ' Si la conversión ha fallado, abandonamos el procedimiento.
        '
        If (tb Is Nothing) Then
            e.Handled = True
            Return
        End If

        Dim isDecimal, isSign, isValidChar, isMinus As Boolean
        Dim decimalSeparator As String = Nothing

        Select Case e.KeyChar

            Case "."c, ","c
                ' Obtenemos el carácter separador decimal existente
                ' actualmente en la configuración regional de Windows. 
                ' 
                decimalSeparator = _
                    Threading.Thread.CurrentThread. _
                    CurrentCulture.NumberFormat.NumberDecimalSeparator

                ' Hacemos que el carácter tecleado coincida con el
                ' carácter separador existentente en la configuración
                ' regional.
                '
                e.KeyChar = decimalSeparator.Chars(0)

                ' Si el primer carácter que se teclea es el separador decimal,
                ' o si bien, existe un signo en el primer carácter, envío la
                ' combinación '0,'.
                '
                If (((tb.TextLength = 0) OrElse (tb.SelectionLength = tb.TextLength)) OrElse _
                    ((tb.TextLength = 1) AndAlso ((tb.Text.Contains("-")) OrElse _
                                               (Text.Contains("+"))))) Then

                    ' NOTA: Envío la combinación "0," mediante el método Send,
                    ' para que en el código cliente se desencadenen los
                    ' eventos de teclado.
                    '
                    SendKeys.Send("{0}")
                    SendKeys.Send("{" & decimalSeparator & "}")
                    e.Handled = True
                    Return
                End If

                ' Es un carácter válido.
                '
                isDecimal = True
                isValidChar = True

            Case "-"c, "+"c    ' Signos negativo y positivo
                ' Es un carácter válido.
                '
                isMinus = True
                isValidChar = True

            Case Else
                ' Sólo se admitirán números y la tecla de retroceso.
                '
                Dim isDigit As Boolean = Char.IsDigit(e.KeyChar)
                Dim isControl As Boolean = Char.IsControl(e.KeyChar)

                If ((isDigit) OrElse (isControl)) Then
                    isValidChar = True

                Else
                    e.Handled = True
                    Return

                End If

        End Select

        ' Si es un carácter válido, y el texto del control
        ' se encuentra totalmente seleccionado, elimino
        ' el valor actual del control.
        '
        If ((isValidChar) And (tb.SelectionLength = tb.TextLength)) Then
            tb.Text = String.Empty
        End If

        If (isSign) Then
            ' Admitimos los caracteres positivo y negativo, siempre y cuando
            ' sea el primer carácter del texto, y no exista ya ningún otro
            ' signo escrito en el control.
            '
            If ((tb.SelectionStart <> 0) OrElse _
                (tb.Text.IndexOf("-") >= 0) OrElse _
                (tb.Text.IndexOf("+") >= 0)) Then
                e.Handled = True
                Return
            End If
        End If

        If (isDecimal) Then
            ' Si en el control hay ya escrito un separador decimal, 
            ' deshechamos insertar otro separador más. 
            ' 
            If (tb.Text.IndexOf(decimalSeparator) >= 0) Then
                e.Handled = True
                Return
            End If
        End If

    End Sub

    Private Sub cellTextBox_KeyUp( _
        ByVal sender As Object, _
        ByVal e As System.Windows.Forms.KeyEventArgs) Handles cellTextBox.KeyUp

    End Sub

    Private Sub DataGridView1_EditingControlShowing( _
                    ByVal sender As Object, _
                    ByVal e As DataGridViewEditingControlShowingEventArgs) _
                    Handles dgvRemision.EditingControlShowing

        ' Este evento se producirá cuando la celda pasa a modo de edición.

        ' Referenciamos el control DataGridViewTextBoxEditingControl actual.
        '
        cellTextBox = TryCast(e.Control, DataGridViewTextBoxEditingControl)

        ' Obtenemos el estilo de la celda actual
        '
        Dim style As DataGridViewCellStyle = e.CellStyle

        ' Mientras se edita la celda, aumentaremos la fuente
        ' y rellenaremos el color de fondo de la celda actual.
        '
        With style
            .Font = New Font(style.Font.FontFamily, 10, FontStyle.Bold)
            .BackColor = Color.Beige
        End With

    End Sub
    '----------------------------------------------------------------------------------
    '
    '
    ' FIN RUTINA PARA VALIDAR CAMPOS NUMÉRICOS EN DATAGRIDVIEW
    '
    '
    '----------------------------------------------------------------------------------
#End Region

    Sub cargarDatos()
        Try
            Using ctx As New CocinaDataContext
                Me.lblRemision.Text = Me.codigoRemision()
                'datos de la sucursal
                Dim lisSucursal = (From s In ctx.Sucursal Select s).ToList()
                cmbSucursal.DataSource = lisSucursal
                cmbSucursal.DisplayMember = "Nombre"
                cmbSucursal.ValueMember = "IdSucursal"
                'datos de la bodega
                Dim verdatos = (From d In ctx.DetaBodega Join p In ctx.Productos
                                On d.CodProducto Equals p.CodProducto
                                Order By p.Nombre
                                Select d.Existencia, d.CodProducto, p.Nombre).ToList()
                dgvRemision.Rows.Clear()
                For Each dato In verdatos
                    dgvRemision.Rows.Add(Nothing, dato.Existencia, dato.CodProducto, dato.Nombre)
                Next
            End Using
        Catch ex As Exception
            MsgBox("Error al intentar recuperar los datos producido por: " & vbCr & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Function codigoRemision() As String
        Using ctx As New CocinaDataContext
            Dim ids As Integer = ctx.ExecuteQuery(Of Integer)("select idremision from idtablas").First()
            Return Convert.ToString(ids).PadLeft(8, "0")
        End Using
    End Function
    Private Sub actualizarIdrem()
        Using ctx As New CocinaDataContext
            ctx.ExecuteQuery(Of Integer)("update idtablas set idremision=idremision+1")
        End Using
    End Sub
    Private Sub frmRemisionNuevo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.cargarDatos()
    End Sub
    Sub limpiarGrid()
        For Each row As DataGridViewRow In dgvRemision.Rows
            row.Cells(0).Value = ""
        Next
    End Sub
    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        'Using tx As New Transactions.TransactionScope
        Dim suma As Decimal = 0
        For Each row As DataGridViewRow In dgvRemision.Rows
            Dim valor As Decimal = CDec(row.Cells(0).Value)
            suma += valor
        Next
        If suma <= 0 Then
            MsgBox("No hay datos a guardar, intente nuevamente", MsgBoxStyle.Information, "Remisión")
            Return
        End If
        Dim idsucursal As Integer = Me.cmbSucursal.SelectedValue
        Dim idremision As String = Me.codigoRemision()
        Using ctx As New CocinaDataContext
            Dim nuevaRemision As New Remision
            nuevaRemision.IdRemision = idremision
            nuevaRemision.Fecha = txtFecha.Value
            nuevaRemision.IdSucursal = idsucursal
            nuevaRemision.Observacion = txtObservacion.Text
            For Each row As DataGridViewRow In dgvRemision.Rows
                Dim cantidad As Decimal = Convert.ToDecimal(row.Cells("colSalida").Value)
                Dim codproducto As String = Convert.ToString(row.Cells("colCodigorem").Value)
                Dim existenciaBodega As Decimal = Convert.ToDecimal(row.Cells("colExistenciarem").Value)
                Dim descripcion As String = Convert.ToString(row.Cells("colDescripcionrem").Value)
                If existenciaBodega <= 0 Then
                    row.Selected = True
                    dgvRemision.CurrentCell = row.Cells(0)
                    MsgBox("El siguiente articulo no tiene existencia en bodega: " & descripcion, MsgBoxStyle.Information, "Remisión")
                    Return
                End If
                If cantidad > existenciaBodega Then
                    row.Selected = True
                    dgvRemision.CurrentCell = row.Cells(0)
                    MsgBox("No puede dar de salida al producto " & descripcion & " con la cantidad indicada, ya que es menor la existencia en bodega", MsgBoxStyle.Information, "Remisión")
                    Return
                End If
                If cantidad <> 0 Then
                    Dim detallebodega = (From db In ctx.DetaBodega
                                         Where db.CodProducto = codproducto
                                         Select db).First()
                    Dim existencia As Decimal = detallebodega.Existencia
                    detallebodega.Existencia = existencia - cantidad
                    Dim detalleRemision As New DetaRemision With
                        {
                            .Cantidad = cantidad,
                            .CodProducto = codproducto,
                            .Fecha = Now,
                            .IdRemision = Me.codigoRemision,
                            .Nombre = row.Cells("colDescripcionrem").Value
                        }
                    ctx.DetaRemision.InsertOnSubmit(detalleRemision)
                End If
            Next
            ctx.Remision.InsertOnSubmit(nuevaRemision)
            Try
                ctx.SubmitChanges()
                Me.actualizarIdrem()
                Me.cargarDatos()
                Me.txtFiltrar.Clear()
                Me.txtObservacion.Clear()
                MsgBox("Se han guardados los datos de la remisión", MsgBoxStyle.Information, "Remisión")
            Catch ex As Exception
                MsgBox("Se produjo el siguiente error: " & vbCr & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Using
        'End Using
    End Sub

    Private Sub btnEditarCompras_Click(sender As System.Object, e As System.EventArgs) Handles btnEditarCompras.Click
        MsgBox("Codigo recuperado: " & Me.codigoRemision)
    End Sub

    Private Sub btnCargardatos_Click(sender As System.Object, e As System.EventArgs) Handles btnCargardatos.Click
        Me.cargarDatos()
    End Sub

    Private Sub txtFiltrar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFiltrar.TextChanged
        Using ctx As New CocinaDataContext
            Try
                For Each row As DataGridViewRow In dgvRemision.Rows
                    Dim descripcion As String = row.Cells("colDescripcionrem").Value
                    If descripcion.Contains(Me.txtFiltrar.Text) Then
                        row.Selected = True
                        dgvRemision.CurrentCell = row.Cells(0)
                        Return
                    End If
                Next
            Catch ex As Exception
                MsgBox("Error al intentar filtrar los datos." & vbCr & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Using
    End Sub
End Class