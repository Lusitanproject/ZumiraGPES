using Lusitan.GPES.Core.Base;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Interface.Servico;
using System.Reflection;

namespace Lusitan.GPES.Core.Servico
{
    public class CargoServico : BaseServico, ICargoServico
    {
        public CargoServico(IUnitOfWork repositorio)
            : base(repositorio) { }

        public List<CargoDominio> GetList()
           => _repositorio.Cargo.GetList();

        public CargoDominio GetById(int id)
            => _repositorio.Cargo.GetById(id);

        public CargoDominio BuscaPelaDescricao(string descCargo)
        => _repositorio.Cargo.BuscaPelaDescricao(descCargo);

        public string Add(CargoDominio obj)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.Cargo.Add(obj);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }

        public string Update(CargoDominio obj)
        {
            var _resultado = string.Empty;

            try
            {
                _repositorio.Cargo.Update(obj);
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
                _repositorio.Cargo.Remove(id);
            }
            catch (Exception ex)
            {
                _resultado = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;
            }

            return _resultado;
        }
    }
}
