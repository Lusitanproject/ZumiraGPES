set nocount on

use DB_GPES
go
/*
create table cargo
(num_cargo int identity,
 desc_cargo varchar(1000),
 idc_ativo char(1),
 constraint pk_cargo primary key (num_cargo),
 constraint ck1_cargo check (idc_ativo = 'S' or idc_ativo = 'N'))
 */

 /*
create table empresa
(num_empresa int identity,
 desc_empresa varchar(1000),
 idc_ativo char(1),
 constraint pk_empresa primary key (num_empresa),
 constraint ck1_empresa check (idc_ativo = 'S' or idc_ativo = 'N'))
 */

 /*
 create table formacao_academica
(num_formacao int identity,
 desc_formacao varchar(1000),
 idc_nivel tinyint,
 idc_ativo char(1),
 constraint pk_formacao primary key (num_formacao),
 constraint ck1_formacao check (idc_ativo = 'S' or idc_ativo = 'N'))
 */


 create  table meu_perfil
 (num_usuario int not null,
  num_empresa int not null,
  dth_inicio smalldatetime,
  dth_fim smalldatetime,
  desc_resumo_experiencia varchar(8000),
  constraint fk1_meu_perfil foreign key (num_usuario) references usuario(num_usuario),
  constraint fk2_meu_perfil foreign key (num_empresa) references empresa(num_empresa))




set nocount off