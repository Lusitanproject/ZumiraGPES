using Dapper;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Infra.Repositorio
{
    [ExcludeFromCodeCoverage]
    public class CargoRepositorio : BaseRepositorio, ICargoRepositorio
    {
        public CargoRepositorio(string strConexao)
            : base(strConexao) { }

        string _query = @"  SELECT	NumCargo = num_cargo,
                                    DescCargo = desc_cargo,
                                    IdcAtivo = idc_ativo
                            FROM cargo (NOLOCK) ";

        public List<CargoDominio> GetList()
        {
            try
            {
                return this.ConexaoBD.Query<CargoDominio>(_query).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
            finally
            {
                this.FechaConexao();
            }
        }

        public CargoDominio GetById(int id)
        {
            try
            {
                var _buscaCargo = @$"{_query} WHERE num_cargo = {id}";

                return this.ConexaoBD.QueryFirstOrDefault<CargoDominio>(_buscaCargo);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
            finally
            {
                this.FechaConexao();
            }
        }

        public string Add(CargoDominio obj)
        {
            try
            {
                var _query = $@" INSERT INTO cargo (desc_cargo, idc_ativo) 
                                 VALUES ('{obj.DescCargo.Trim()}', 'S')";

                this.ConexaoBD.Execute(_query.ToString());

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
            finally
            {
                this.FechaConexao();
            }
        }

        public string Update(CargoDominio obj)
        {
            try
            {
                var _query = $@" UPDATE cargo 
                                 SET desc_cargo = '{obj.DescCargo}', 
                                     idc_ativo = '{obj.IdcAtivo}' 
                                 WHERE num_cargo = {obj.NumCargo}";

                this.ConexaoBD.Execute(_query);

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
            finally
            {
                this.FechaConexao();
            }
        }

        public CargoDominio BuscaPelaDescricao(string descCargo)
        {
            try
            {
                var _buscaCargo = @$"{_query} WHERE LOWER(desc_cargo) = '{descCargo.Trim().ToLower()}'";

                return this.ConexaoBD.QueryFirstOrDefault<CargoDominio>(_buscaCargo);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
            finally
            {
                this.FechaConexao();
            }
        }

        public string Remove(int id)
        {
            try
            {
                var _query = $@" DELETE FROM cargo WHERE num_cargo = {id}";

                this.ConexaoBD.Execute(_query);

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
            finally
            {
                this.FechaConexao();
            }
        }
    }
}
