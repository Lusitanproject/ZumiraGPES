using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Entidade
{
    [ExcludeFromCodeCoverage]
    public  class CargoDominio: BaseDominio
    {       
        [Required(ErrorMessage = "A aplicação requer que o campo Descrição seja preenchido!")]
        [StringLength(1000, ErrorMessage = "A Descrição deve possuir no máximo 1000 caracteres")]
        public string DescCargo { get; set; }

    }
}
