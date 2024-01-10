using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Entidade
{
    [ExcludeFromCodeCoverage]
    public  class CargoDominio
    {
        public int NumCargo { get; set; }

        [Required(ErrorMessage = "A aplicação requer que o campo Descrição seja preenchido!")]
        [StringLength(1000, ErrorMessage = "A Descrição deve possuir no máximo 1000 caracteres")]
        public string DescCargo { get; set; }

        public string IdcAtivo { get; set; }

        public string DescSituacao
        {
            get
            {

                var _descSituacao = string.Empty;

                switch (this.IdcAtivo)
                {
                    case "S":
                        _descSituacao = "Ativo";
                        break;

                    case "N":
                        _descSituacao = "Inativo";
                        break;
                }

                return _descSituacao;
            }
        }
    }
}
