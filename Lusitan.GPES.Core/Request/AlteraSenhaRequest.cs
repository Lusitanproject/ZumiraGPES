using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Request
{
    [ExcludeFromCodeCoverage]
    public class AlteraSenhaRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "Informe o Usuário!")]
        public int NumUsuario { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Informe o Usuário Resp!")]
        public int NumUsuarioResp { get; set; }

        [Required(ErrorMessage = "Informe a Senha Antiga!")]
        [StringLength(8, ErrorMessage = "A Senha Antiga deve possuir no máximo 8 caracteres")]
        public string SenhaAntiga { get; set; }

        [Required(ErrorMessage = "Informe a Senha Nova!")]
        [StringLength(8, ErrorMessage = "A Senha Nova deve possuir no máximo 8 caracteres")]
        public string SenhaNova { get; set; }
    }
}
