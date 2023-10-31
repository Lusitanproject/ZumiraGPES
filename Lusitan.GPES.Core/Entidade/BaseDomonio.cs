
namespace Lusitan.GPES.Core.Entidade
{
    public abstract class BaseDomonio
    {
        public int Id { get; set; }

        public string IdcAtivo { get; set; }

        public string DescSituacao
        {
            get { return this.IdcAtivo == "S"? "Ativo": "Inativo"; } 
        }
    }
}
