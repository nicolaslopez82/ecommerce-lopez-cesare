
--//////////////// EMPIEZA PRODUCTOS ///////////////////

CREATE PROCEDURE SP_AgregarProducto
(
    @idCategoria bigint,
    @Descripcion VARCHAR(150),
    @stock bigint,
    @precio money,
    @urlImagen varchar(500)
)
as 
BEGIN

insert into Productos (ID_Categoria,Descripcion,Stock,Precio,UrlImagen,Estado)
values(@idCategoria,@Descripcion,@stock,@precio,@urlImagen,1)

END

go
alter PROCEDURE SP_ListaProducto
As 
BEGIN

select 
      p.ID,
      p.ID_Categoria,
      p.Descripcion,
      p.Stock,
      p.Precio,
      p.UrlImagen


from Productos as p where Estado =1

end
GO
alter PROCEDURE SP_ModificarProducto
(
    @id bigint,
    @idCategoria bigint,
    @Descripcion varchar(150),
    @stock bigint,
    @precio money,
    @urlImagen varchar(500)

)
as 
BEGIN

UPDATE Productos SET ID_Categoria=@idCategoria,
     Descripcion=@Descripcion,Stock=@stock, Precio=@precio,UrlImagen=@urlImagen
     where ID = @id

   

END

go
alter PROCEDURE SP_EliminarProducto
(
 @id bigint
)
as 
BEGIN

update Productos set Estado =0 where ID = @id


END

go
alter procedure SP_ValidarStock
(
    @idproducto bigint,
    @cantidad bigint
)
AS
BEGIN

    select count(*) as r from Productos where ID = @idproducto and Stock >= @cantidad 
     
    
END

go
alter PROCEDURE SP_BajaStock
(
    @idproducto bigint
)
as 
BEGIN

UPDATE Productos set Stock= Stock -1 where ID = @idproducto

END

go
create PROCEDURE SP_AltaStock
(
    @idproducto bigint
)
AS
BEGIN

UPDATE Productos set Stock= Stock +1 where ID = @idproducto

END

go
create PROCEDURE SP_BuscarProducto
(
    @idproducto bigint
)
AS
BEGIN
select p.ID,
        p.Descripcion,
        p.Estado,
        p.ID_Categoria,
        p.Precio,
        p.Stock,
        p.UrlImagen
from Productos as P where p.ID = @idproducto

END

-- ///////////////// TERMINA PRODUCTOS /////////////////////////////--

--/////////////// EMPIEZA FORMA DE PAGO ////////////////////////////-
go
create PROCEDURE SP_ListaFormaPAgo
As 
BEGIN

select ID,
    Descripcion



from FormaPago where Estado =1

END



--//////////////// TERMINA FORMA DE PAGO/////////////////-


--///////////////////// EMPIEZA VENTA /////////////////////////
GO
alter PROCEDURE SP_FinalizarVenta
(
 @idUsuario bigint,
 @idPago bigint,
@descripcion varchar(300),
@direccion varchar(150),
@estadoenvio bit,
@total money,
@estadoretiro bit

)
AS 
BEGIN
insert into Ventas (ID_Usuario,ID_FormaPago,DescripcionVenta,
DireccionEnvio,EstadoEnvio,Total,Fecha,Estado,EstadoRetiro)
values (@idUsuario,@idPago,@descripcion,@direccion,@estadoenvio,@total,GETDATE(),1,
@estadoretiro)

END


select * from Ventas


--///////////////////// TERMINA VENTA ////////////////////////////

--//////////// EMPIEZA DETALLE VENTA ///////////////////////////
GO
CREATE PROCEDURE SP_UltimoIdVenta
AS
BEGIN

select top 1 ID from Ventas where Estado=1 ORDER by ID desc 

END


go
create procedure SP_RegistrarDetalle
(
    @idventa bigint,
    @idproducto bigint,
    @precio money,
    @cantidad bigint
)
AS

BEGIN
insert into DetalleVenta (ID_Venta,ID_Producto,Precio,Cantidad,Estado)
values(@idventa,@idproducto,@precio,@cantidad,1)
END


select * FROM DetalleVenta where ID_Venta = 10

select * from Ventas
--///////////////// TERMINA DETALLE VENTA ////////////////////

