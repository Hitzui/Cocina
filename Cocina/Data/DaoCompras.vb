Imports System.Data.SqlClient

Public Class DaoCompras
    Private _error As String
    Public Property NumeroFactura As String
    Public ReadOnly Property errorMsg As String
        Get
            Return _error
        End Get
    End Property
    Public Function recuperarID() As Integer
        Using ctx As New CocinaDataContext
            Try
                Return ctx.IdTablas.First().IdCompra
            Catch ex As Exception
                _error = ex.Message
                Return 0
            End Try
        End Using
    End Function
    Public Function actualizarIdCompra() As Boolean
        Using con As New SqlConnection(Cocina.My.Settings.cocinaConnectionString)
            Try
                con.Open()
                Dim cmd As New SqlCommand("update IdTablas set idcompra = idcompra + 1", con)
                cmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                _error = ex.Message
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function
    Public Function numeroCompra() As String
        Using ctx As New CocinaDataContext
            Dim numfactura As String = String.Empty
            Try
                Dim buscarFact = (From fact In ctx.IdTablas Select fact).First
                numfactura = (buscarFact.IdCompra + 1).ToString().PadLeft(6, "0"c)
            Catch ex As Exception
                numfactura = "1".PadLeft(6, "0"c)
            End Try
            Return numfactura
        End Using
    End Function
    Public Function crearCompra(compra As Compra, detaCompra As List(Of DetalleCompra)) As Boolean
        Using con As New SqlConnection(Cocina.My.Settings.cocinaConnectionString)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim transaction As SqlTransaction = con.BeginTransaction("compra")
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandText = "select id.IdCompra+1 from IdTablas id"
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                cmd.Transaction = transaction
                Dim drIds As SqlDataReader = cmd.ExecuteReader
                While drIds.Read
                    Me.NumeroFactura = Convert.ToString(drIds.GetInt32(0)).PadLeft(6, "0"c)
                End While
                drIds.Close()
                'ingresamos la compra
                cmd.CommandText = "INSERT INTO [dbo].[Compra]([NumFac],[Fecha],[Total],[IdProveedor],[Iva],[referencia])" & _
                                  " VALUES(@NumFac,@Fecha,@Total,@IdProveedor,@Iva,@referencia)"
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.Transaction = transaction
                With cmd.Parameters
                    .AddWithValue("@NumFac", Me.NumeroFactura())
                    .Add("@Fecha", SqlDbType.Date).Value = compra.Fecha
                    .AddWithValue("@IdProveedor", compra.IdProveedor)
                    .AddWithValue("@Iva", compra.Iva)
                    .AddWithValue("@referencia", compra.Referencia)
                    .AddWithValue("@Total", compra.Total)
                End With
                cmd.ExecuteNonQuery()
                Dim linea As Integer = 0
                For Each dato In detaCompra
                    linea += 1
                    cmd.Parameters.Clear()
                    cmd.CommandText = "INSERT INTO [dbo].[DetalleCompra]([Codigo],[Nombre],[Cantidad],[UnidadM],[PrecioC],[Consecutivo],[Fecha] " & _
                                       ",[IdCategoria],[IdGrupo],[NumFactura],[IdProveedor]) " & vbCr & _
                                        "VALUES(@Codigo,@Nombre,@Cantidad,@UnidadM,@PrecioC,@Consecutivo,@Fecha,@IdCategoria," & _
                                       "@IdGrupo,@NumFact,@IdProveedor)"
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    cmd.Transaction = transaction
                    '@Codigo varchar(20),
                    '@Nombre varchar(100),
                    '@Cantidad numeric(12, 2),
                    '@UnidadM varchar(10),
                    '@PrecioC numeric(12, 2),
                    '@Consecutivo int,
                    '@Fecha date,
                    '@IdCategoria varchar(20),
                    '@IdGrupo varchar(20),
                    '@NumFact varchar(20),
                    '@IdProveedor int
                    With cmd.Parameters
                        .AddWithValue("@Codigo", dato.Codigo)
                        .AddWithValue("@Nombre", dato.Nombre)
                        .AddWithValue("@Cantidad", dato.Cantidad)
                        .AddWithValue("@UnidadM", dato.UnidadM)
                        .AddWithValue("@PrecioC", dato.PrecioC)
                        .AddWithValue("@Consecutivo", linea)
                        .AddWithValue("@Fecha", dato.Fecha)
                        .AddWithValue("@IdCategoria", dato.IdCategoria)
                        .AddWithValue("@IdGrupo", dato.IdGrupo)
                        .AddWithValue("@NumFact", Me.NumeroFactura)
                        .AddWithValue("@IdProveedor", dato.IdProveedor)
                    End With
                    cmd.ExecuteNonQuery()
                    'actualizamos el precio del producto
                    cmd.CommandText = "update Productos set UltPrecioC = @precio, Costo = 0 where CodProducto = @codprod"
                    cmd.CommandType = CommandType.Text
                    cmd.Transaction = transaction
                    With cmd.Parameters
                        .AddWithValue("@precio", dato.PrecioC)
                        .AddWithValue("@codprod", dato.Codigo)
                    End With
                    cmd.ExecuteNonQuery()
                Next
                transaction.Commit()
                Return True
            Catch ex As SqlException
                _error = "Sql Exception: " & ex.Message
                transaction.Rollback("compra")
                Return False
            Catch ex2 As Exception
                If _error.Length > 0 Then
                    _error += " " & vbCr & ex2.Message
                Else
                    _error = ex2.Message
                End If
                Return False
            Finally
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try
        End Using
    End Function
    ''' <summary>
    ''' Recuperamos el producto según su codigo
    ''' </summary>
    ''' <param name="codigo">Codigo del producto</param>
    ''' <returns>Productos</returns>
    ''' <remarks></remarks>
    Public Function recuperarProducto(codigo As String) As Productos
        Using con As New SqlConnection(My.Settings.cocinaConnectionString)
            Try
                Dim cmd As New SqlCommand("select * from Productos where codproducto = '" & codigo & "'", con)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Dim producto As New Productos
                '[CodProducto]
                '[Nombre]
                '[IdUnidad]
                '[IdGrupo]
                '[IdCategoria]
                '[UltPrecioC]
                '[Costo]
                While dr.Read
                    producto.CodProducto = dr.GetString(0)
                    producto.Nombre = dr.GetString(1)
                    producto.IdUnidad = dr.GetValue(2)
                    producto.IdGrupo = dr.GetValue(3)
                    producto.IdCategoria = dr.GetValue(4)
                    producto.UltPrecioC = dr.GetDecimal(5)
                    producto.Costo = dr.GetDecimal(6)
                End While
                Return producto
            Catch ex As Exception
                _error = ex.Message
                Return Nothing
            Finally
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try
        End Using
    End Function
    ''' <summary>
    ''' Recuperamos la unidad de medida segun el producto
    ''' </summary>
    ''' <param name="codigo">Codigo de la unidad</param>
    ''' <returns>New Unidad</returns>
    ''' <remarks></remarks>
    Public Function recupearUnidadMedida(codigo As Integer) As Unidad
        Using con As New SqlConnection(My.Settings.cocinaConnectionString)
            Try
                Dim cmd As New SqlCommand("select * from Unidad where [IdUnidad] = " & codigo, con)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Dim unidad As New Unidad
                '[IdUnidad]
                '[UdidadM]
                '[Descripcion]
                While dr.Read
                    unidad.IdUnidad = dr.GetValue(0)
                    unidad.UdidadM = dr.GetString(1)
                    unidad.Descripcion = dr.GetString(2)
                End While
                Return unidad
            Catch ex As Exception
                _error = ex.Message
                Return Nothing
            Finally
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try
        End Using
    End Function

    Public Function actualizarCompra(compra As Compra, detaCompra As List(Of DetalleCompra)) As Boolean
        Using con As New SqlConnection(Cocina.My.Settings.cocinaConnectionString)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim transaction As SqlTransaction = con.BeginTransaction("actualizarCompra")
            Try
                Dim cmd As New SqlCommand()
                Me.NumeroFactura = compra.NumFac
                'eliminamos la compra
                cmd.CommandText = "delete from compra where numfac = @numFact"
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.Transaction = transaction
                cmd.Parameters.AddWithValue("@numFact", Me.NumeroFactura)
                cmd.ExecuteNonQuery()
                'eliminamos el detalle de compra
                cmd.CommandText = "delete from DetalleCompra where NumFactura  = @numFact"
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.Transaction = transaction
                'cmd.Parameters.AddWithValue("@numFact", Me.NumeroFactura)
                cmd.ExecuteNonQuery()
                'ingresamos la compra
                cmd.CommandText = "INSERT INTO [dbo].[Compra]([NumFac],[Fecha],[Total],[IdProveedor],[Iva],[referencia])" & _
                                  " VALUES(@NumFac,@Fecha,@Total,@IdProveedor,@Iva,@referencia)"
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.Transaction = transaction
                With cmd.Parameters
                    .AddWithValue("@NumFac", Me.NumeroFactura())
                    .Add("@Fecha", SqlDbType.Date).Value = compra.Fecha
                    .AddWithValue("@IdProveedor", compra.IdProveedor)
                    .AddWithValue("@Iva", compra.Iva)
                    .AddWithValue("@referencia", compra.Referencia)
                    .AddWithValue("@Total", compra.Total)
                End With
                cmd.ExecuteNonQuery()
                Dim linea As Integer = 0
                For Each dato In detaCompra
                    linea += 1
                    cmd.Parameters.Clear()
                    cmd.CommandText = "INSERT INTO [dbo].[DetalleCompra]([Codigo],[Nombre],[Cantidad],[UnidadM],[PrecioC],[Consecutivo],[Fecha] " & _
                                       ",[IdCategoria],[IdGrupo],[NumFactura],[IdProveedor]) " & vbCr & _
                                        "VALUES(@Codigo,@Nombre,@Cantidad,@UnidadM,@PrecioC,@Consecutivo,@Fecha,@IdCategoria," & _
                                       "@IdGrupo,@NumFact,@IdProveedor)"
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    cmd.Transaction = transaction
                    '@Codigo varchar(20),
                    '@Nombre varchar(100),
                    '@Cantidad numeric(12, 2),
                    '@UnidadM varchar(10),
                    '@PrecioC numeric(12, 2),
                    '@Consecutivo int,
                    '@Fecha date,
                    '@IdCategoria varchar(20),
                    '@IdGrupo varchar(20),
                    '@NumFact varchar(20),
                    '@IdProveedor int
                    With cmd.Parameters
                        .AddWithValue("@Codigo", dato.Codigo)
                        .AddWithValue("@Nombre", dato.Nombre)
                        .AddWithValue("@Cantidad", dato.Cantidad)
                        .AddWithValue("@UnidadM", dato.UnidadM)
                        .AddWithValue("@PrecioC", dato.PrecioC)
                        .AddWithValue("@Consecutivo", linea)
                        .AddWithValue("@Fecha", dato.Fecha)
                        .AddWithValue("@IdCategoria", dato.IdCategoria)
                        .AddWithValue("@IdGrupo", dato.IdGrupo)
                        .AddWithValue("@NumFact", Me.NumeroFactura)
                        .AddWithValue("@IdProveedor", dato.IdProveedor)
                    End With
                    cmd.ExecuteNonQuery()
                    'actualizamos el precio del producto
                    cmd.CommandText = "update Productos set UltPrecioC = @precio, Costo = 0 where CodProducto = @codprod"
                    cmd.CommandType = CommandType.Text
                    cmd.Transaction = transaction
                    With cmd.Parameters
                        .AddWithValue("@precio", dato.PrecioC)
                        .AddWithValue("@codprod", dato.Codigo)
                    End With
                    cmd.ExecuteNonQuery()
                Next
                transaction.Commit()
                Return True
            Catch ex As SqlException
                _error = "Sql Exception: " & ex.Message
                transaction.Rollback("actualizarCompra")
                Return False
            Catch ex2 As Exception
                If _error.Length > 0 Then
                    _error += " " & vbCr & ex2.Message
                Else
                    _error = ex2.Message
                End If
                Return False
            Finally
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try
        End Using
    End Function
End Class
