use DB_GPES
go
/*
drop table log_acesso_erro
drop table usuario_perfil
drop table perfil_acesso
drop table usuario_log
drop table usuario
*/

set nocount on

create table usuario
(
   num_usuario int not null identity,
   nom_usuario varchar(100) not null,
   des_senha varchar(200) not null,
   e_mail varchar(100) not null,
   idc_ativo char(1) not null,
   dth_ultimo_acesso datetime,
   idc_forca_altera_senha char(1),
   constraint pk_usuario primary key (num_usuario),
   constraint uk1_usuario unique (e_mail),
   constraint ck1_usuario check(idc_ativo = 'A' or idc_ativo = 'I' or idc_ativo = 'B'),
   constraint ck2_usuario check(idc_forca_altera_senha = 'S' or idc_forca_altera_senha = 'N')
)
go
insert into usuario (nom_usuario, des_senha, e_mail, idc_ativo, idc_forca_altera_senha)
values ('Admin Sistema', 'u6FT3UmuYHKPIssrfl+71A==', 'teste@teste.com.br', 'A', 'N')  --Senha: admin123

go
create index ix1_usuario on usuario(e_mail)
go
create index ix2_usuario on usuario(idc_ativo)
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
insert into perfil_acesso (nom_perfil) values ('Admin');
insert into perfil_acesso (nom_perfil) values ('Gestor')
go
create table usuario_perfil
(
   num_usuario int,
   num_perfil int,
   constraint fk1_usuario_perfil  foreign key (num_usuario) references usuario(num_usuario),
   constraint fk2_usuario_perfil  foreign key (num_perfil) references perfil_acesso(num_perfil)
)
go
DECLARE @NumUsuario int,
		@NumPerfil int

SELECT @NumUsuario = num_usuario
FROM usuario
WHERE e_mail = 'teste@teste.com.br'

SELECT @NumPerfil = num_perfil
FROM perfil_acesso
WHERE nom_perfil = 'Admin'

INSERT INTO usuario_perfil (num_usuario, num_perfil)
VALUES (@NumUsuario, @NumPerfil)

go
create table log_acesso_erro
(num_usuario int,
dth_log_erro datetime,
desc_log_erro varchar(500),
 constraint fk1_log_acesso_erro  foreign key (num_usuario) references usuario(num_usuario)
)



set nocount off