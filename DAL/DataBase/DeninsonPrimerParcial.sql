create database Parcial1db;

use Parcial1db

create table Materiales
(MaterialId int primary key identity(1,1),
Razon varchar(30));


create table MaterialesDetalle
(MaterialesDetalle int primary key identity(1,1),
MaterialId int foreign key references Materiales(MaterialId),
Material Varchar(20),
Cantidad int);

select * from Materiales;
select * from MaterialesDetalle
