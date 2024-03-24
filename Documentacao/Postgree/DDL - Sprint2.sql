/*
drop table cargo;
drop table  empresa;
drop table minha_formacao;
drop table formacao_academica;
drop table meu_perfil;
 */
create table cargo
(num_cargo int GENERATED ALWAYS AS identity,
 desc_cargo varchar(1000),
 idc_ativo char(1),
 constraint pk_cargo primary key (num_cargo),
 constraint ck1_cargo check (idc_ativo = 'S' or idc_ativo = 'N'));

create table empresa
(num_empresa int GENERATED ALWAYS AS identity,
 desc_empresa varchar(1000),
 idc_ativo char(1),
 constraint pk_empresa primary key (num_empresa),
 constraint ck1_empresa check (idc_ativo = 'S' or idc_ativo = 'N'));

 create table formacao_academica
(num_formacao int GENERATED ALWAYS AS identity,
 desc_formacao varchar(1000),
 idc_nivel int,
 idc_ativo char(1),
 constraint pk_formacao primary key (num_formacao),
 constraint ck1_formacao check (idc_ativo = 'S' or idc_ativo = 'N'));

 create table minha_formacao
 (num_minha_formacao int GENERATED ALWAYS AS identity,
  num_usuario int not null,
  num_formacao int not null,
  mes_ano_inicio char(5),
  mes_ano_fim char(5),
  nom_instituicao varchar(250),
  idc_situacao char(1),
  constraint pk_minha_formacao primary key (num_minha_formacao),
  constraint fk1_minha_formacacao foreign key (num_usuario) references usuario(num_usuario),
  constraint fk2_minha_formacacao foreign key (num_formacao) references formacao_academica(num_formacao),
  constraint ck1_minha_formacacao check (idc_situacao = 'A' or idc_situacao = 'C' or idc_situacao = 'I'));


 create  table meu_perfil
 (num_usuario int not null,
  id_doc_curriculumn varchar(100),
  id_doc_foto varchar(100),
  constraint fk1_meu_perfil foreign key (num_usuario) references usuario(num_usuario));


grant select, insert, update, delete ON cargo TO usergpes;
grant select, insert, update, delete ON empresa TO usergpes;
grant select, insert, update, delete ON formacao_academica TO usergpes;
grant select, insert, update, delete ON minha_formacao TO usergpes;
grant select, insert, update, delete ON meu_perfil TO usergpes;