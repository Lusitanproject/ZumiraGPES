namespace Lusitan.GPES.Core.Base
{
    public abstract class BaseDomonio
    {
        public int Id { get; set; }

        public string IdcAtivo { get; set; }

        public string DescSituacao
        {
            get { return IdcAtivo == "S" ? "Ativo" : "Inativo"; }
        }
    }
}
