using CORE.Validacao;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Request
{
    [ExcludeFromCodeCoverage]
    public class LoginRequest
    {
        [Required(ErrorMessage = "A aplicação requer que o campo E-mail seja preenchido!")]
        [StringLength(100, ErrorMessage = "O E-mail deve possuir no máximo 100 caracteres")]
        [ValidaEMail]
        public string EMail { get; set; }

        [Required(ErrorMessage = "A aplicação requer que o campo Senha seja preenchido!")]
        [StringLength(8, ErrorMessage = "A Senha deve possuir no máximo 8 caracteres")]
        public string Pwd { get; set; }
    }
}
