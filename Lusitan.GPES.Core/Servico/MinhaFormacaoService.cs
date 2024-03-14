using Lusitan.GPES.Core.Base;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Interface.Servico;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Core.Servico
{
    [ExcludeFromCodeCoverage]
    public class MinhaFormacaoService : BaseServico, IMinhaFormacaoService
    {
        public MinhaFormacaoService(IUnitOfWork repositorio)
            : base(repositorio) { }

        public List<MinhaFormacaoDominio> BuscaPeloUsuario(int idUsuario)
           => _repositorio.MinhaFormacao.BuscaPeloUsuario(idUsuario);

        public string Add(MinhaFormacaoDominio obj)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.MinhaFormacao.Add(obj);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }

        public string Remove(int id)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.MinhaFormacao.Remove(id);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }
    }
}
