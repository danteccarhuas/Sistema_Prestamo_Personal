use DBPRESTAMO

insert tb_menu values
('Mantenimiento','fa fa-fw fa-edit','fa fa-fw fa-caret-down'),
('Trasancciones','fa fa-fw fa-table','fa fa-fw fa-caret-down')
go

insert tb_submenu values
('Mantenimiento Trabajador','/Trabajador/mantener_trabajador',1),
('Mantenimiento Cliente','/Cliente/mantener_cliente',1),
('Solicitud Prestamo','/Prestamo/solicitud_prestamo',2)
go

insert tb_rol values
('Administrador'),
('Trabajador')
go

insert tb_permiso values
(1,1),
(2,1),
(3,1),
(2,2),
(3,2)
go

insert tb_usuario values
('admin','admin')
go

insert tb_trabajador values
('TRA0001','Dante','Ccarhuas','Bardales','10567845','Av. Santa Rosa','ccarhuas.dante@gmail.com','7856897','1997-06-16',1,1)
go

insert tb_rol_tb_usuario values
(1,1)
go