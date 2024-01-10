using Dapper;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Infra.Repositorio
{
    [ExcludeFromCodeCoverage]
    public class EmpresaRepositorio : BaseRepositorio, IEmpresaRepositorio
    {
        public EmpresaRepositorio(string strConexao)
            : base(strConexao) { }

        string _query = @"  SELECT	Id = num_empresa,
                                    NomEmpresa = desc_empresa,
                                    IdcAtivo = idc_ativo
                            FROM empresa (NOLOCK) ";

        public List<EmpresaDominio> GetList()
        {
            try
            {
                return this.ConexaoBD.Query<EmpresaDominio>(_query).ToList();
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

        public EmpresaDominio GetById(int id)
        {
            try
            {
                var _buscaEmpresa = @$"{_query} WHERE num_empresa = {id}";

                return this.ConexaoBD.QueryFirstOrDefault<EmpresaDominio>(_buscaEmpresa);
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

        public EmpresaDominio BuscaPeloNome(string nomEmpresa)
        {
            try
            {
                var _buscaEmpresa = @$"{_query} WHERE LOWER(desc_empresa) = '{nomEmpresa.Trim().ToLower()}'";

                return this.ConexaoBD.QueryFirstOrDefault<EmpresaDominio>(_buscaEmpresa);
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

        public string Add(EmpresaDominio obj)
        {
            try
            {
                var _query = $@" INSERT INTO empresa (desc_empresa, idc_ativo) 
                                 VALUES ('{obj.NomEmpresa.Trim()}', 'S')";

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

        public string Update(EmpresaDominio obj)
        {
            try
            {
                var _query = $@" UPDATE empresa 
                                 SET desc_empresa = '{obj.NomEmpresa}', 
                                     idc_ativo = '{obj.IdcAtivo}' 
                                 WHERE num_empresa = {obj.Id}";

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

        public string Remove(int id)
        {
            try
            {
                var _query = $@" DELETE FROM empresa WHERE num_empresa = {id}";

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
