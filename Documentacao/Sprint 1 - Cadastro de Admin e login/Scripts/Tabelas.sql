use DB_GPES
go
/*
drop table usuario_perfil
drop table perfil_acesso
drop table usuario_log
drop table usuario
*/
create table usuario
(
   num_usuario int not null identity,
   nom_usuario varchar(100) not null,
   des_senha varchar(200) not null,
   e_mail varchar(100) not null,
   idc_ativo char(1) not null,
   constraint pk_usuario primary key (num_usuario),
   constraint uk1_usuario unique (e_mail),
   constraint ck1_usuario check(idc_ativo = 'S' or idc_ativo = 'N')
)
go
create index ix1_usuario on usuario(e_mail)
go
create table usuario_log
(
  num_usuario int  not null,
  num_usuario_log int  not null,
  desc_log varchar(100)  not null,
  dth_log datetime default getdate(),
  num_usuario_resp int  not null,
  constraint fk1_usuario_log foreign key (num_usuario) references usuario(num_usuario),
  constraint fk2_usuario_log foreign key (num_usuario_resp) references usuario(num_usuario)
)
go
create table perfil_acesso
(
   num_perfil int not null identity,
   nom_perfil varchar(100),
   constraint pk_perfil_acesso primary key (num_perfil)
)
go
insert into perfil_acesso (nom_perfil) values ('Admin')
go
create table usuario_perfil
(
   num_usuario int,
   num_perfil int,
   constraint fk1_usuario_perfil  foreign key (num_usuario) references usuario(num_usuario),
   constraint fk2_usuario_perfil  foreign key (num_perfil) references perfil_acesso(num_perfil)
)
