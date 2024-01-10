using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Entidade
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseDominio
    {
        public int Id { get; set; }

        public string IdcAtivo { get; set; }

        public string DescSituacao
        {
            get
            {
                return this.IdcAtivo == "S" ? "Ativo" : "Inativo";
            }
        }
    }
}
