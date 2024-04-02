/*
revoke all on log_acesso_erro from usergpes;
revoke all on usuario_perfil from usergpes;
revoke all on perfil_acesso from usergpes;
revoke all on usuario_log from usergpes;
revoke all on usuario from usergpes;
revoke all on database db_gpes from usergpes;
drop USER usergpes
*/

CREATE USER usergpes PASSWORD '1231!#ASDF!a';

GRANT CONNECT ON DATABASE db_gpes TO usergpes;

