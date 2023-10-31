use DB_GPES
go
/*
drop table usuario_perfil_acesso
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
   dth_inicio_acesso smalldatetime not null,
   dth_inicio_fim smalldatetime not null,
   idc_ativo char(1) not null,
   constraint pk_usuario primary key (num_usuario),
   constraint uk1_usuario unique (e_mail),
   constraint ck1_usuario check(idc_ativo = 'S' or idc_ativo = 'N')
)
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
create table perfil_acesso
(
  num_perfil_acesso int not null identity,
  desc_perfil_acesso varchar(100)  not null,
  idc_ativo char(1) not null,
  constraint pk_perfil_acesso primary key(num_perfil_acesso),
  constraint ck1_perfil_acesso check(idc_ativo = 'S' or idc_ativo = 'N'))

create table usuario_perfil_acesso
(
	num_usuario int not null,
	num_perfil_acesso int not null,
	num_usuario_resp int not null,
	constraint fk1_usuario_perfil_acesso foreign key(num_usuario) references usuario(num_usuario),
	constraint fk2_usuario_perfil_acesso foreign key (num_usuario_resp) references usuario(num_usuario),
	constraint fk3_usuario_perfil_acesso foreign key(num_perfil_acesso) references perfil_acesso(num_perfil_acesso)	)