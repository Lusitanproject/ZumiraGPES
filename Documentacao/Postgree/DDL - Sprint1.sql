/*
drop table log_acesso_erro;
drop table usuario_perfil;
drop table perfil_acesso;
drop table usuario_log;
drop table usuario;
*/

create table usuario
(
   num_usuario int GENERATED ALWAYS AS identity,
   nom_usuario varchar(100) not null,
   des_senha varchar(200) not null,
   e_mail varchar(100) not null,
   idc_ativo char(1) not null,
   dth_ultimo_acesso timestamp,
   idc_forca_altera_senha char(1),
   constraint pk_usuario primary key (num_usuario),
   constraint uk1_usuario unique (e_mail),
   constraint ck1_usuario check(idc_ativo = 'A' or idc_ativo = 'I' or idc_ativo = 'B'),
   constraint ck2_usuario check(idc_forca_altera_senha = 'S' or idc_forca_altera_senha = 'N')
);

insert into usuario (nom_usuario, des_senha, e_mail, idc_ativo, idc_forca_altera_senha)
values ('Admin Sistema', 'u6FT3UmuYHKPIssrfl+71A==', 'teste@teste.com.br', 'A', 'N');  --Senha: admin123

create index ix1_usuario on usuario(e_mail);

create index ix2_usuario on usuario(idc_ativo);

create table usuario_log
(
  num_usuario int GENERATED ALWAYS AS identity,
  num_usuario_log int  not null,
  desc_log varchar(100)  not null,
  dth_log timestamp default now(),
  num_usuario_resp int  not null,
  constraint fk1_usuario_log foreign key (num_usuario) references usuario(num_usuario),
  constraint fk2_usuario_log foreign key (num_usuario_resp) references usuario(num_usuario)
);

create table perfil_acesso
(
   num_perfil int GENERATED ALWAYS AS identity,
   nom_perfil varchar(100),
   constraint pk_perfil_acesso primary key (num_perfil)
);

insert into perfil_acesso (nom_perfil) values ('Admin');
insert into perfil_acesso (nom_perfil) values ('Gestor');

create table usuario_perfil
(
   num_usuario int,
   num_perfil int,
   constraint fk1_usuario_perfil  foreign key (num_usuario) references usuario(num_usuario),
   constraint fk2_usuario_perfil  foreign key (num_perfil) references perfil_acesso(num_perfil)
);

INSERT INTO usuario_perfil (num_usuario, num_perfil)
VALUES ((SELECT num_usuario FROM usuario WHERE e_mail = 'teste@teste.com.br'), 
		(SELECT num_perfil FROM perfil_acesso WHERE nom_perfil = 'Admin'));

create table log_acesso_erro
(num_usuario int,
dth_log_erro timestamp,
desc_log_erro varchar(500),
 constraint fk1_log_acesso_erro  foreign key (num_usuario) references usuario(num_usuario)
);

grant select, insert, update, delete ON usuario TO usergpes;
grant select, insert, update, delete ON usuario_log TO usergpes;
grant select, insert, update, delete ON perfil_acesso TO usergpes;
grant select, insert, update, delete ON usuario_perfil TO usergpes;
grant select, insert, update, delete ON log_acesso_erro TO usergpes;