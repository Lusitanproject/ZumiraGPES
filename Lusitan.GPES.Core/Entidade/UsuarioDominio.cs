using System.ComponentModel.DataAnnotations;

namespace Lusitan.GPES.Core.Entidade
{
    public class UsuarioDominio: BaseDomonio
    {
        [Required(ErrorMessage = "A aplicação requer que o campo Nome seja preenchido!")]
        [StringLength(100, ErrorMessage = "O Nome deve possuir no máximo 100 caracteres")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "A aplicação requer que o campo E-mail seja preenchido!")]
        [StringLength(100, ErrorMessage = "O E-mail deve possuir no máximo 100 caracteres")]
        public string eMail { get; set; }
    }

    public class UsuarioViewDominio : UsuarioDominio
    {
        public string DesSenha { get; set; }
    }
}
