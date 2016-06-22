if DB_ID('DBPRESTAMO')is not null
begin
	use master;
	drop database DBPRESTAMO;
end
go
create database DBPRESTAMO;
go
use DBPRESTAMO;

if OBJECT_ID('tb_usuario') is not null
begin
drop table tb_usuario
end  
go
create table tb_usuario(
idUsuario int primary key identity(1,1) not null,
login varchar(45) not null,
password varchar(45) not null
);

if OBJECT_ID('tb_trabajador') is not null
begin
drop table tb_trabajador
end  
go
create table tb_trabajador(
idTrabajador char(8) primary key not null,
nombres varchar(45) not null,
ape_paterno varchar(45) not null,
ape_materno varchar(45) not null,
dni varchar(8) not null,
direccion varchar(80) not null,
correo varchar(45) not null,
telefono varchar(11) not null,
fecha_nacimiento date not null,
estado int not null,
idUsuario int not null
constraint fkUsuario_trabajador foreign key(idUsuario) references tb_usuario
);

if OBJECT_ID('tb_cliente') is not null
begin
drop table tb_cliente
end  
go
create table tb_cliente(
idCliente char(8) primary key not null,
nombres varchar(45) not null,
ape_paterno varchar(45) not null,
ape_materno varchar(45) not null,
dni varchar(8) not null,
direccion varchar(80) not null,
correo varchar(45) not null,
telefono varchar(11) not null,
fecha_nacimiento date not null,
estado int not null
);


if OBJECT_ID('tb_rol') is not null
begin
drop table tb_rol
end  
go
create table tb_rol(
idRol int primary key identity(1,1) not null,
descripcion_rol varchar(30) not null
);
 
if OBJECT_ID('tb_rol_tb_usuario') is not null
begin
drop table tb_rol_tb_usuario
end  
go
create table tb_rol_tb_usuario(
idRol int not null,
idUsuario int not null,
CONSTRAINT pk_rol_usuario PRIMARY KEY (idUsuario, idRol), 
CONSTRAINT fk_rol FOREIGN KEY (idRol) REFERENCES tb_rol, 
CONSTRAINT fk_usuario FOREIGN KEY (idUsuario) REFERENCES tb_usuario 
);

if OBJECT_ID('tb_menu') is not null
begin
drop table tb_menu
end  
go
create table tb_menu(
idMenu int primary key identity(1,1) not null,
descripcion_menu varchar(45) not null,
icon_left varchar(45) not null,
icon_right varchar(45) not null
);


if OBJECT_ID('tb_submenu') is not null
begin
drop table tb_submenu
end  
go
create table tb_submenu(
idSub_Menu int primary key identity(1,1) not null,
descripcion_sub_menu varchar(45) not null,
url varchar(50) not null,
idMenu int not null,
constraint fk_menu_sub_menu foreign key(idMenu)references tb_menu
);


if OBJECT_ID('tb_permiso') is not null
begin
drop table tb_permiso
end  
go
create table tb_permiso(
idSub_Menu int not null,
idRol int not null,
CONSTRAINT pk_permis PRIMARY KEY (idSub_Menu, idRol), 
CONSTRAINT fk_rol_per FOREIGN KEY (idRol) REFERENCES tb_rol, 
CONSTRAINT fk_sub_menu_per FOREIGN KEY (idSub_Menu) REFERENCES tb_submenu 
);


if OBJECT_ID('tb_solicitud_prestamo') is not null
begin
drop table tb_solicitud_prestamo
end  
go
create table tb_solicitud_prestamo(
idSolicitud_pres int primary key identity(1,1) not null,
fecha_registro date,
monto_Total decimal(5,2),
tasa decimal(5,2),
cantidad_meses int,
idCliente char(8),
idTrabajador char(8),
CONSTRAINT fk_cliente FOREIGN KEY (idCliente) REFERENCES tb_cliente, 
CONSTRAINT fk_trabajador FOREIGN KEY (idTrabajador) REFERENCES tb_trabajador 
);


if OBJECT_ID('tb_interes_por_tiempo') is not null
begin
drop table tb_interes_por_tiempo
end  
go
create table tb_interes_por_tiempo(
idTasa_por_interes int primary key identity(1,1) not null,
tiempo varchar(45) not null,
tasa decimal(5,2) not null
);


if OBJECT_ID('tb_cuotas') is not null
begin
drop table tb_cuotas
end  
go
create table tb_cuotas(
idNumCuotas int primary key identity(1,1) not null,
monto_mensual decimal(5,2) not null,
idSolicitud_pres int not null,
CONSTRAINT fk_SolPrestamo FOREIGN KEY (idSolicitud_pres) REFERENCES tb_solicitud_prestamo, 
);

