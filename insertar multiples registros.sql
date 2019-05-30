declare producto_cursor cursor for
select d.Codigo,sum(d.Cantidad) as existencia from DetalleCompra d
where d.Fecha >= CAST('01/03/2015' AS date) and d.Fecha<=CAST('30/03/2015' AS date)
group by d.Codigo
order by d.Codigo asc
declare @codigo as varchar(20), @existencia as numeric(12,3);

open producto_cursor;
fetch next from producto_cursor;
while @@FETCH_STATUS = 0
	begin
		fetch next from producto_cursor into @codigo,@existencia
		insert into DetaBodega(CodProducto,IdBodega,Existencia) 
		values(@codigo,1,@existencia);
		print @codigo
	end
close producto_cursor;
deallocate producto_cursor;
go