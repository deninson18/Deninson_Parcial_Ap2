create database ParcialDeninson1db;

use ParcialDeninson1db

Create table Solicitudes(
SolicitudId int primary key identity(1,1),
Fecha varchar(20),
Razon varchar(50),
Total float);

create table Materiales(
MaterialId int primary key identity(1,1),
Descripcion varchar(100),
Precio float);


create table SolicitudDetalle(
SolicitudDetalleId int primary key identity(1,1),
MaterialId int references Materiales(MaterialId),
Material Varchar(20),
Cantidad int,
Precio float);

drop table MaterialesDetalle
drop table Materiales
drop table Solicitud

select * from Materiales;
select * from SolicitudDetalle
select * from Solicitudes;