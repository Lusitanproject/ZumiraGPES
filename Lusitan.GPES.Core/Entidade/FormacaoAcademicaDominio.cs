using Lusitan.GPES.Core.Enum;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Entidade
{
    [ExcludeFromCodeCoverage]
    public class FormacaoAcademicaDominio : BaseDominio
    {
        [Required(ErrorMessage = "A aplicação requer que o campo Descrição seja preenchido!")]
        [StringLength(8000, ErrorMessage = "A Descrição deve possuir no máximo 8000 caracteres")]
        public string DescFormacao { get; set; }

        public NivelAcademicoEnum IdcNivel { get; set; }
    }
}
