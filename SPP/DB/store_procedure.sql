if object_id('usp_RegistrarTrabajador')is not null
begin
	drop proc usp_RegistrarTrabajador
end
go
Create Proc usp_RegistrarTrabajador(
@nombres VARCHAR(45),
@ape_paterno VARCHAR(45),
@ape_materno VARCHAR(45),
@dni varchar(8),
@direccion varchar(80),
@correo varchar(45),
@telefono varchar(11),
@fecha_nacimiento DATE,
@idTrabajador varchar(10) OUTPUT)
As
Begin
declare @v_idUsuario int,@v_pass varchar(15),@v_idTrabajador varchar(10);
set @v_idUsuario=0;
set	@v_pass='';
set @v_idTrabajador='';

set @v_pass=SUBSTRING(@nombres,1,1)+@ape_paterno

insert tb_usuario values (@dni,@v_pass);

select @v_idUsuario=MAX(idUsuario) from tb_usuario;

select @v_idTrabajador=RTRIM('TRA')+RTRIM(RIGHT('000' +CONVERT(varchar,ISNULL(MAX(CONVERT(int,right([idTrabajador],4))),0)+1),4)) from dbo.tb_trabajador; 

INSERT tb_trabajador(idTrabajador,nombres,ape_paterno,ape_materno,dni,direccion,correo,telefono,fecha_nacimiento,idUsuario)
VALUES(@v_idTrabajador,@nombres,@ape_paterno,@ape_materno,@dni,@direccion,@correo,@telefono,@fecha_nacimiento,1,@v_idUsuario);

SET @idTrabajador = @v_idTrabajador
End
Go


if object_id('usp_ActualizarTrabajador')is not null
begin
	drop proc usp_ActualizarTrabajador
end
go
Create Proc usp_ActualizarTrabajador(
@nombres VARCHAR(45),
@ape_paterno VARCHAR(45),
@ape_materno VARCHAR(45),
@dni varchar(8),
@direccion varchar(80),
@correo varchar(45),
@telefono varchar(11),
@fecha_nacimiento DATE,
@idUsuario int,
@idTrabajador varchar(10))
As
Begin
declare @v_pass varchar(15);
set	@v_pass='';

set @v_pass=SUBSTRING(@nombres,1,1)+@ape_paterno

update tb_usuario 
set dni=@dni,
	v_pass=@v_pass
where idUsuario=@idUsuario;

update tb_trabajador
set nombres=@nombres,
	ape_paterno=@ape_paterno,
	ape_materno=@ape_materno,
	dni=@dni,
	direccion=@direccion,
	correo=@correo,
	telefono=@telefono,
	fecha_nacimiento=@fecha_nacimiento
where idTrabajador=@idTrabajador

End
Go


if object_id('usp_BuscarTrabajador')is not null
begin
	drop proc usp_BuscarTrabajador
end
go
Create Proc usp_BuscarTrabajador(
@idTrabajador varchar(10)
)
As
Begin

select idTrabajador,nombres,ape_paterno,ape_materno,dni,direccion,correo,telefono,fecha_nacimiento,u.idUsuario
from tb_trabajador t inner join tb_usuario u
on t.idUsuario=u.idUsuario;

End
Go


if object_id('usp_DarBajaTrabajador')is not null
begin
	drop proc usp_DarBajaTrabajador
end
go
Create Proc usp_DarBajaTrabajador(
@idTrabajador varchar(10)
)
As
Begin

update tb_trabajador
set estado=0
where idTrabajador=@idTrabajador;

End
Go


if object_id('usp_RegistrarCliente')is not null
begin
	drop proc usp_RegistrarCliente
end
go
Create Proc usp_RegistrarCliente(
@nombres VARCHAR(45),
@ape_paterno VARCHAR(45),
@ape_materno VARCHAR(45),
@dni varchar(8),
@direccion varchar(80),
@correo varchar(45),
@telefono varchar(11),
@fecha_nacimiento DATE,
@idCliente varchar(10) OUTPUT)
as	
Begin
declare @v_idCliente varchar(10);
set @v_idCliente='';

select @v_idCliente=RTRIM('CLI')+RTRIM(RIGHT('000' +CONVERT(varchar,ISNULL(MAX(CONVERT(int,right(idCliente,4))),0)+1),4)) from dbo.tb_cliente; 

Insert tb_cliente
Values(@v_idCliente,@nombres,@ape_paterno,@ape_materno,
@dni,@direccion,@correo,@telefono,@fecha_nacimiento,1)
set @idCliente=@v_idCliente
End
go

if object_id('usp_ActualizarCliente')is not null
begin
	drop proc usp_ActualizarCliente
end
go
Create Proc usp_ActualizarCliente
@idCliente char(8),
@nombres VARCHAR(45),
@ape_paterno VARCHAR(45),
@ape_materno VARCHAR(45),
@dni varchar(8),
@direccion varchar(80),
@correo varchar(45),
@telefono varchar(11),
@fecha_nacimiento DATE,
@estado int
as
Begin
Update tb_cliente Set nombres=@nombres,
ape_paterno=@ape_paterno,ape_materno=@ape_materno,dni=@dni,
direccion=@direccion,correo=@correo,telefono=@telefono,
fecha_nacimiento=@fecha_nacimiento,estado=@estado Where idCliente=@idCliente
End


if object_id('usp_BuscarCliente')is not null
begin
	drop proc usp_BuscarCliente
end
go
Create Proc usp_BuscarCliente(
@idTrabajador char(8)
)
As
Begin
select idCliente,nombres,ape_paterno,ape_materno,dni,direccion,correo,telefono,fecha_nacimiento,estado
from tb_cliente
End
Go



if object_id('usp_DarBajaCliente')is not null

begin
	drop proc usp_DarBajaCliente
end
go
Create Proc usp_DarBajaCliente(
@idCliente char(8)
)
As
Begin

update tb_cliente
set estado=0
where idCliente=@idCliente;
End
Go


if object_id('usp_ListarCliente')is not null
begin
	drop proc usp_ListarCliente
end
go
Create Proc usp_ListarCliente
As
Begin
select idCliente,(nombres+' '+ape_paterno+' '+ape_materno) 'cliente',
dni,correo,telefono
from tb_cliente
End
Go



