use master;
go
Drop DATABASE if exists Farmacia
go
create database Farmacia
go
Use Farmacia
go

Create table Usuarios(
	Id_Usuarios int not null primary key identity,
	Nombre varchar(50),
	Pass varchar(50)
);

create table Categorias(
	Id_Categoria int primary key identity,
	Nombre_Categoria varchar(100)
);

create table Productos (
	Id_Producto int primary key identity,
	Nombre_Producto varchar(100),
	Precio_Producto money,
	Id_CategoriaFK int foreign key references Categorias(Id_Categoria)
);

create table Proveedores(
	Id_Proveedores int primary key identity,
	Nombre_Proveedores varchar(100),
	Tipo_Proveedores varchar(50)
);

CREATE TABLE Venta(
	Id_Venta int not null IDENTITY PRIMARY KEY,
	Id_UsuariosFK int REFERENCES Usuarios(Id_Usuarios),
	Id_ProductoFK int REFERENCES Productos(Id_Producto),
	Cantidad int,
	totalVenta money,
	fechaVenta date not null
);

--insert into Venta values(1, 1, 4, 0.50*4, getdate())
--Buscar Id dado un nombre
--SELECT Id_Usuarios FROM Usuarios WHERE Nombre = @Nombre
--SELECT Id_Producto FROM Usuarios WHERE Nombre_Producto = @Nombre_Producto

/*
Select a.Nombre as [Nombre Usuario], c.Nombre_Producto, c.Precio_Producto, b.Cantidad, 
b.totalVenta as [Total], b.fechaVenta
from Usuarios as a
inner join Venta as b on b.Id_UsuariosFK = a.Id_Usuarios
inner join Productos as c on b.Id_ProductoFK = c.Id_Producto
*/

select * from Productos
select * from Proveedores
select * from Categorias
select * from Usuarios
select * from Venta

insert into Usuarios values('Prueba', 123)

insert into Categorias values ('Higiene'),
							  ('Dermocosmetica'),
							  ('Medicamento')

insert into Productos values ('Mascarilla KN-95',0.50, 2)
insert into Productos values ('Acetaminofen',0.50, 3)
insert into Productos values ('Foskrol','5', 3)
insert into Productos values ('Alcohol gel',1, 1)
insert into Productos values ('Caja Preservativo',1.50, 1)
insert into Productos values ('Viro Grip Dia',0.50, 3)
insert into Productos values ('Viro Grip Noche',0.50, 3)
insert into Productos values ('Amoxicilina',0.30, 3)

insert into Proveedores values ('Fac','Fiabilidad')

insert into Venta values(1, 2, 10, 20, GETDATE())

/*
create table Registro(
	Id_Registro int primary key identity,
	Nombre_Registro varchar(100),
	Apellidos_Registro varchar(100),
	Correo_Registro varchar(100)
);
*/
