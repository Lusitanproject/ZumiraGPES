using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Aplicacao.TextoEMAil
{
    public static class TextoEMailNovoUsuario
    {
        public static string GetTextoPtb(UsuarioDominio usu, string senhaPadrao)
        {
            return @$" Olá {usu.NomeUsuario},
                        Ficamos felizes por se cadastrar. Juntos, faremos coisas incríveis!
                        Aqui estão os seus dados para acessar a plataforma e começar a sua jornada de sucesso!
                        Login: {usu.eMail}
                        Senha:  {senhaPadrao}
                        Para entrar  agora e encontrar novas oportunidades, clique no link abaixo:
                        
                        Login
                          só  usar as credenciais informadas acima. Anote-as para não esquecer, ok? :)

                        Que  comece  ma jornada de facilidades e descobertas.
                        Com 🧡 
                        Equipe Zumira 
                    ";
        }

        public static string GetTextoEn(UsuarioDominio usu, string senhaPadrao)
        {
            return @$" Hello {usu.NomeUsuario},
                        We are happy to register. Together, we will do incredible things!
                        Here are your details to access the platform and start your successful journey!
                        Login: {usu.eMail}
                        Password:  {senhaPadrao}
                        To join now and find new opportunities, click the link below:

                        Login
                          Just use the credentials provided above. Write them down so you don't forget, ok? :)

                        Let a journey of ease and discovery begin.
                        With 🧡 
                        Zumira Team
                    ";
        }

        public static string GetTextoEs(UsuarioDominio usu, string senhaPadrao)
        {
            return @$" Hola {usu.NomeUsuario},
                        Estamos felices de registrarnos. ¡Juntos haremos cosas increíbles!
                        ¡Aquí están tus datos para acceder a la plataforma y comenzar tu viaje exitoso!
                        Login: {usu.eMail}
                        Contraseña:  {senhaPadrao}
                        Para unirse ahora y encontrar nuevas oportunidades, haga clic en el siguiente enlace:

                        Login
                          simplemente use las credenciales proporcionadas anteriormente. Escríbelas para no olvidarlas., ok? :)

                        Que comience un viaje de tranquilidad y descubrimiento.
                        Con 🧡 
                        Equipo Zumira 
                    ";
        }
    }
}

