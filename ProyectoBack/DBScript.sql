create database DbPrueba

use DbPrueba

create table tblProductos(
id int primary key identity(1,1),
nombre varchar(100),
precio money,
fechaCreacion datetime,
fechaModificacion datetime
)

create table tblTipoDocumento(
id int primary key identity(1,1),
nombre varchar(100),
fechaCreacion datetime,
fechaModificacion datetime
)

create table tblCajera(
id int primary key identity(1,1),
nombre varchar(100),
idTipoDocumento int,
identificacion varchar(15),
fechaCreacion datetime,
fechaModificacion datetime
)

ALTER TABLE tblCajera
ADD CONSTRAINT fk_idTipoDocumento
FOREIGN KEY (idTipoDocumento) REFERENCES tblTipoDocumento(id);


create table tblCompra(
id int primary key identity(1,1),
idCajera int,
precioTotal money,
fechaCreacion datetime,
fechaModificacion datetime
)

ALTER TABLE tblCompra
ADD CONSTRAINT fk_idCajera
FOREIGN KEY (idCajera) REFERENCES tblCajera(id);


create table tblProductosCompra(
id int primary key identity(1,1),
idProducto int,
cantidad int,
idCompra int,
fechaCreacion datetime,
fechaModificacion datetime
)
ALTER TABLE tblProductosCompra
ADD CONSTRAINT fk_idProducto
FOREIGN KEY (idProducto) REFERENCES tblProductos(id);

ALTER TABLE tblProductosCompra
ADD CONSTRAINT fk_idCompra
FOREIGN KEY (idCompra) REFERENCES tblCompra(id);


insert into tblTipoDocumento(nombre, fechaCreacion)values('CC', GETDATE())
insert into tblTipoDocumento(nombre, fechaCreacion)values('TI', GETDATE())

insert into tblProductos(nombre, precio, fechaCreacion)values('Yogurt', 1500, GETDATE())
insert into tblProductos(nombre, precio, fechaCreacion)values('Galletas', 2000, GETDATE())
insert into tblProductos(nombre, precio, fechaCreacion)values('Arepas', 1000, GETDATE())
insert into tblProductos(nombre, precio, fechaCreacion)values('Quesito', 5000, GETDATE())
