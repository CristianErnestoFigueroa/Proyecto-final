-- Creacion de la Base de datos para Farmacia
Use master
Go
Drop database if exists FarmaciaDB
Go
Create database FarmaciaDB
Go
Use FarmaciaDB;
Go
-- Entidades Fuertes
-- Sucursal, Cliente, Laboratorio, Categoria

Create Table Cliente(
	IdCliente int primary key identity(1,1) not null,
	Nombre varchar(100),

);
insert into Cliente(nombre) values ('Sara');



Create Table Laboratorio(
	IdLaboratorio int primary key identity(1,1) not null,
	Nombre varchar(100),
	Telefono int 
);
insert into Laboratorio(nombre,telefono) values ('PHARMEDIC','23250055');



Create Table Categoria(
	IdCategoria int primary key identity(1,1) not null,
	Nombre varchar(100),

);
insert into Categoria(nombre) values ('Antibiotico');



Create Table Sucursal(
	IdSucursal int primary key identity(1,1) not null,
	Nombre varchar(100),
	
);
insert into Sucursal(nombre) values ('Farmacia I');

-- Entidades Dependientes
-- Producto, Inventario, DetallesFactura, Factura

Create Table Producto(
	IdProducto int primary key identity(1,1) not null,
	Nombre varchar(100),
	Precio money,
	FK_IdLaboratorio int not null Foreign key References Laboratorio(IdLaboratorio),
	FK_IdCategoria int not null Foreign key References Categoria(IdCategoria),
);

insert into Producto(Nombre,Precio,FK_IdLaboratorio,FK_IdCategoria) values ('CLARITROMICINA','15.75','1','1');




Create Table Inventario(
	IdInventario int primary key identity(1,1) not null,
	FK_IdSucursal int not null Foreign key References Sucursal(IdSucursal),
	FK_IdCategoria int not null Foreign key References Categoria(Idcategoria),
    FK_IdProducto int not null Foreign key References Producto(IdProducto),
	Cantidad int

	
);
insert into Inventario(FK_IdSucursal,FK_IdCategoria,FK_IdProducto,Cantidad) values ('1','1','1','15');








Create Table DetallesFactura(
	IdDetallesFactura int primary key identity(1,1) not null,
	Cantidad int,
	FK_IdInventario int not null Foreign key References Inventario(IdInventario),
	Monto char
);
insert into DetallesFactura(Cantidad,FK_IdInventario,Monto) values ('1','1','*')







Create Table Factura(
	IdFactura int primary key identity(1,1) not null,
	Fecha date,
	FK_IdCliente int not null Foreign key References Cliente(IdCliente),
	FK_IdSucursal int not null Foreign key References Sucursal(IdSucursal),
	FK_IdDetallesFactura int not null Foreign key References DetallesFactura(IdDetallesFactura)
);
insert into Factura(Fecha,FK_IdCliente,FK_IdSucursal,FK_IdDetallesFactura) values ('11/12/2020','1','1','1')



Go


--select * from  Cliente

--select * from  Sucursal

--select * from Laboratorio

--select * from Categoria

--select * from Producto

--select * from Inventario

--select * from DetallesFactura

--select * from Factura


