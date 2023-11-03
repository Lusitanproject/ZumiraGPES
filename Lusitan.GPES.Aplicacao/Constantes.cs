
namespace Lusitan.GPES.Aplicacao
{
    public static class Constantes
    {
        public static string GetTextoEMailNovoUsuario = @"
                                                            Olá [USUARIO],

                                                            Ficamos felizes por se cadastrar. Juntos, faremos coisas incríveis!
                                                            Aqui estão os seus dados para acessar a plataforma e começar a sua jornada de sucesso!
                                                            Login: [LOGIN]
                                                            Senha: [SENHA]
                                                            Para entrar agora e encontrar novas oportunidades, clique no link abaixo:
                                                            Login
                                                            É só usar as credenciais informadas acima. Anote-as para não esquecer, ok? :)

                                                            Que comece uma jornada de facilidades e descobertas.
                                                            Com 🧡,
                                                            Equipe Zumira
                                                        ";

        public static string GetTextoReenvioSenha = @"
                                                        Olá [Nome do Usuário],

                                                        Esperamos que esteja tudo bem!
                                                        Conforme solicitado, aqui está a sua nova senha para acessar a nossa plataforma:

                                                        Senha: [Senha temporária gerada]
                                                        Tenha um excelente dia!

                                                        Atenciosamente, Equipe Zumira
                                                    ";
    }
}
