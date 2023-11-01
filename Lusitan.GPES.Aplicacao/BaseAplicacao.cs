
namespace Lusitan.GPES.Aplicacao
{
    public abstract class BaseAplicacao
    {
        public string StrConexao { get; set; }

        protected void TrataErro(string msgErro)
        {
            NLog.LogManager.GetCurrentClassLogger().Error(msgErro);

        }
    }
}
