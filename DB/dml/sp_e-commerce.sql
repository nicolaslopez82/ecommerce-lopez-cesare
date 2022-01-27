
--//////////////// EMPIEZA PRODUCTOS ///////////////////

CREATE PROCEDURE SP_AgregarProducto
(
    @idCategoria bigint,
    @descripcion VARCHAR(150),
    @stock bigint,
    @precio money,
    @urlImagen varchar(500)
)
AS 
BEGIN

INSERT INTO Productos (IdCategoria,Descripcion,Stock,Precio,UrlImagen,Estado)
VALUES(@idCategoria,@descripcion,@stock,@precio,@urlImagen,1)

END
GO

CREATE PROCEDURE SP_ListaProducto
AS 
BEGIN

SELECT 
      p.IdProducto,
      p.IdCategoria,
      p.Descripcion,
      p.Stock,
      p.Precio,
      p.UrlImagen
FROM Productos AS p WHERE Estado = 1

END
GO

CREATE PROCEDURE SP_ModificarProducto
(
    @idProducto bigint,
    @idCategoria bigint,
    @descripcion varchar(150),
    @stock bigint,
    @precio money,
    @urlImagen varchar(500)

)
AS
BEGIN

UPDATE Productos SET IdCategoria = @idCategoria,
     Descripcion = @descripcion, Stock = @stock, Precio = @precio, UrlImagen = @urlImagen
     WHERE IdProducto = @idProducto  
END

GO
CREATE PROCEDURE SP_EliminarProducto
(
 @idProducto bigint
)
AS
BEGIN
DELETE FROM Productos WHERE IdProducto = @idProducto
END

SELECT TOP 1 * FROM Productos ORDER BY IdProducto DESC
-- ///////////////// TERMINA PRODUCTOS /////////////////////////////--

--/////////////// EMPIEZA FORMA DE PAGO ////////////////////////////-
GO
CREATE PROCEDURE SP_ListaFormaPAgo
AS
BEGIN

SELECT IdFormaPago,
	   Descripcion
FROM FormaPago WHERE Estado = 1
END
GO
--//////////////// TERMINA FORMA DE PAGO/////////////////-

--///////////////////// EMPIEZA VENTA /////////////////////////
GO
ALTER PROCEDURE SP_FinalizarVenta
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
INSERT INTO Ventas (IdUsuario, IdFormaPago, DescripcionVenta,
DireccionEnvio, EstadoEnvio, Total, Fecha, Estado, EstadoRetiro)
VALUES (@idUsuario, @idPago, @descripcion, @direccion, @estadoenvio, @total,GETDATE(),1, @estadoretiro)
END

SELECT * FROM Ventas;
GO
--///////////////////// TERMINA VENTA ////////////////////////////

--//////////// EMPIEZA DETALLE VENTA ///////////////////////////
GO
CREATE PROCEDURE SP_UltimoIdVenta
AS
BEGIN

SELECT TOP 1 IdVenta FROM Ventas WHERE Estado=1 ORDER BY IdVenta DESC 
END
GO

CREATE PROCEDURE SP_RegistrarDetalle
(
    @idVenta bigint,
    @idProducto bigint,
    @precio money,
    @cantidad bigint
)
AS

BEGIN
INSERT INTO DetalleVenta (IdVenta, IdProducto, Precio, Cantidad, Estado)
VALUES (@idVenta, @idProducto, @precio, @cantidad, 1)
END
GO

SELECT * FROM DetalleVenta WHERE IdVenta = 10;

SELECT * FROM Ventas;
--///////////////// TERMINA DETALLE VENTA ////////////////////

-- TODO -> FALTA COMPLETAR Y CORREGIR WIP
/****** Object:  StoredProcedure SP_AgregarUsuario ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_AgregarUsuario
@idTipoUsuario INT,
@usuario VARCHAR(50),
@clave VARCHAR(50),
@estado BIT,
@patron VARCHAR(50)
AS
BEGIN
INSERT INTO Usuarios(Usuario, Estado, Clave) 
VALUES (@usuario, @estado, ENCRYPTBYPASSPHRASE(@patron, @clave))
END
GO
-- EXECUTE SP_AgregarUsuario 3,'john','snow','12345',1,'jsnow','winter','utnecommerce'
-- DROP PROCEDURE SP_AgregarUsuario;  
 
 
/****** Object:  StoredProcedure SP_ValidarUsuario ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_ValidarUsuario
@usuario VARCHAR(50),
@clave VARCHAR(50),
@patron VARCHAR(50)
AS
BEGIN
SELECT*FROM Usuarios WHERE Usuario = @usuario and CONVERT(VARCHAR(50),DECRYPTBYPASSPHRASE(@patron, clave)) = @clave
END
GO

-- EXECUTE SP_ValidarUsuario 'jsnow','winter','utnecommerce'

/****** Object:  StoredProcedure SP_ActualizarDatosUsuario ******/      
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_ActualizarClaveUsuario
(@prmIdUsuario bigint,
@prmClave varchar(50))
AS
	BEGIN
		UPDATE Usuarios
		SET Usuarios.Clave = @prmClave		
		WHERE Usuarios.idUsuario = @prmIdUsuario
	END
GO

/****** Object:  StoredProcedure SP_EliminarUsuario ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_EliminarUsuario
(@prmIdUsuario int)
AS
	BEGIN
		UPDATE Usuarios
		SET Estado = 0
		WHERE idUsuario = @prmIdUsuario
	END
GO

/****** Object:  StoredProcedure SP_BuscarUsuarioPorEmail ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_BuscarUsuarioPorEmail
(@prmUsuario varchar(50))
AS
	BEGIN
		SELECT U.idUsuario			
			 , U.Usuario
		FROM Usuarios U 		
		WHERE U.Usuario = @prmUsuario
	END
GO
--///////////////// TERMINA USUARIOS ////////////////////