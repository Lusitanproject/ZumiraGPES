using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Entidade
{
    [ExcludeFromCodeCoverage]
    public class EmpresaDominio : BaseDominio
    {
        [Required(ErrorMessage = "A aplicação requer que o campo Nome seja preenchido!")]
        [StringLength(1000, ErrorMessage = "O Nome deve possuir no máximo 1000 caracteres")]
        public string NomEmpresa { get; set; }
    }
}
