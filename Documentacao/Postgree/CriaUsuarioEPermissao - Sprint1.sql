/*
revoke all on canal_envio from userxms;
revoke all on controle_mensagem from userxms;
revoke all on controle_mensagem_log from userxms;
revoke all on parametro_sistema from userxms;
revoke all on remetente_mensagem from userxms;
revoke all on database db_xms from userxms;
drop USER usergpes
*/

CREATE USER usergpes PASSWORD '1231!#ASDF!a';

GRANT CONNECT ON DATABASE db_gpes TO usergpes;

