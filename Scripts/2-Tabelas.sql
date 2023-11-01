use DB_GPES
go
/*
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
