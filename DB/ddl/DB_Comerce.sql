create database Comerce
go 
use Comerce
GO
create Table Usuarios(
    ID bigint not null primary key identity(1, 1),
    Email varchar(25) not null unique,
    Clave varchar(100) not null,
    Estado bit not null
)


go
create table DatosUsuario(
    ID bigint not null PRIMARY key foreign key references Usuarios(ID),
    Nombre varchar(100) not null,
    Apellido varchar(100) not null,
    Documento VARCHAR(8)not null,
    Domicilio varchar(150) null,
    Celular varchar(20)null,
    Estado bit not null

)

create table AdminComerce(
    ID bigint not null primary key IDENTITY(1,1),
    NombreComercio VARCHAR(100)not null,
    Email VARCHAR(50) not null,
    Clave varchar(100)not null,
    Estado bit not null
)

create table FormaPago(
    ID bigint not null PRIMARY KEY IDENTITY(1,1),
    Descripcion varchar(30) not null,
    Estado bit not null

)

create table Ventas(
    ID bigint not null PRIMARY key IDENTITY(1,1),
     Fecha date null check (Fecha <= getdate()),
     ID_Usuario bigint not null,
    ID_FormaPago bigint not null,
    DescripcionVenta varchar(300) null,
    DireccionEnvio varchar (150) null,
    EstadoEnvio bit not null,
    Estado bit not null
)
go
alter table Ventas add Total money not null ;
alter table Ventas add EstadoRetiro bit not null;

create table Categoria(
    ID bigint not null PRIMARY key IDENTITY(1,1),
    Descripcion VARCHAR(30),
    Estado bit not null,
)

create table Productos(
    ID bigint not null PRIMARY KEY IDENTITY(1,1),
    ID_Categoria bigint not null FOREIGN KEY REFERENCES Categoria(ID),
    Descripcion varchar(150) not null,
    Stock bigint not null,
    Precio money not null,
    Estado bit not null,
    UrlImagen varchar(500)not null,


)

create table DetalleVenta(
    ID_Venta bigint not null FOREIGN key REFERENCES Ventas(ID),
    ID_Producto bigint not null FOREIGN key REFERENCES Productos(ID),
    Precio money not null,
    Cantidad bigint not null,
    Estado bit not null


)

create table contacto(
    iD bigint not null PRIMARY key IDENTITY(1,1),
    Email varchar(50) not null,
    Celular varchar(20)not null,
    DescripcionProblema varchar (500) not null,
    Estado bit not null
)

CREATE TABLE Usuarios(
	idUsuario int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	estado bit not null,	
	usuario varchar(50) not null,
	clave varbinary(500) not null
)

 