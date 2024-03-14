using Lusitan.GPES.Core.Enum;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Entidade
{
    [ExcludeFromCodeCoverage]
    public class MinhaFormacaoDominio
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A aplicação requer que o campo Usuário seja preenchido!")]
        public int IdUsuario { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A aplicação requer que o campo Formação Acadêmica seja preenchido!")]
        public int IdFormacaoAcademica { get; set; }

        [Required(ErrorMessage = "A aplicação requer que o campo Mês/Ano Início seja preenchido!")]
        public string MesAnoInicio { get; set; }

        [Required(ErrorMessage = "A aplicação requer que o campo Mês/Ano Fim seja preenchido!")]
        public string MesAnoFim { get; set; }

        public string IdcSituacao { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class MinhaFormacaoViewDominio
    {
        public int Id { get; set; }

        public UsuarioDominio Usuario { get; set; }

        public FormacaoAcademicaDominio FormacaoAcademica { get; set; }

        public string MesAnoInicio { get; set; }

        public string MesAnoFim { get; set; }

        public SituacaoMinhaFormacaoEnum IdcSituacao { get; set; }
    }
}
