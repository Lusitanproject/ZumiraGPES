set nocount on

use DB_GPES
go

create table cargo
(num_cargo int identity,
 desc_cargo varchar(1000),
 idc_ativo char(1),
 constraint pk_cargo primary key (num_cargo),
 constraint ck1_cargo check (idc_ativo = 'S' or idc_ativo = 'N'))


create table empresa
(num_empresa int identity,
 desc_empresa varchar(1000),
 idc_ativo char(1),
 constraint pk_empresa primary key (num_empresa),
 constraint ck1_empresa check (idc_ativo = 'S' or idc_ativo = 'N'))


set nocount off