set nocount on

use DB_GPES
go

create table cargo
(num_cargo int identity,
 desc_cargo varchar(1000),
 idc_ativo char(1),
 constraint pk_cargo primary key (num_cargo),
 constraint ck1_cargo check (idc_ativo = 'S' or idc_ativo = 'N'))


--create table usuario_detalhe_perfil
--  (num_usuario int not null,
--   desc_cargo varchar(1000),
--   nom_empresa
--   constraint fk1_usuario_detalhe_perfil foreign key (num_usuario) usuario(num_usuario)


set nocount off