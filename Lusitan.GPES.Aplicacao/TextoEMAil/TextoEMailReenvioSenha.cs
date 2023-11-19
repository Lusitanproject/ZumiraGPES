
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Aplicacao.TextoEMAil
{
    public static class TextoEMailReenvioSenha
    {
        public static string GetTextoPtb(UsuarioViewDominio usuario)
        {
            return @$" 
                        Olá {usuario.NomeUsuario},

                        Esperamos que esteja tudo bem!

                        Conforme solicitado, aqui está a sua nova senha para acessar a nossa plataforma:

                        Senha: {CORE.CryptObj.Decripta(usuario.DesSenha)}

                        Tenha um excelente dia!

                        Atenciosamente, Equipe Zumira
                    ";
        }

        public static string GetTextoEn(UsuarioViewDominio usuario)
        {
            return @$" 
                        Hello {usuario.NomeUsuario},

                        We hope everything is fine!

                        As requested, here is your new password to access our platform:

                        Password: {CORE.CryptObj.Decripta(usuario.DesSenha)}

                        Have an excellent day!

                        Sincerely, Zumira Team
                    ";
        }

        public static string GetTextoEs(UsuarioViewDominio usuario)
        {
            return @$" 
                        Hola {usuario.NomeUsuario},

                        ¡Esperamos que todo esté bien!

                        Según lo solicitado, aquí está su nueva contraseña para acceder a nuestra plataforma:

                        Contraseña: {CORE.CryptObj.Decripta(usuario.DesSenha)}

                        ¡Ten un día excelente!

                        Atentamente, Equipo Zumira
                    ";
        }
    }
}
