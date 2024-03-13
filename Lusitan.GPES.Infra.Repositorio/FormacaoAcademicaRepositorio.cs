using Dapper;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Infra.Repositorio
{
    [ExcludeFromCodeCoverage]
    public class FormacaoAcademicaRepositorio : BaseRepositorio, IFormacaoAcademicaRepositorio
    {
        public FormacaoAcademicaRepositorio(string strConexao)
            : base(strConexao) { }

        string _query = @"  SELECT	Id = num_formacao,
		                            DescFormacao = desc_formacao,
		                            IdcNivel = idc_nivel,
		                            IdcAtivo = idc_ativo
                            FROM formacao_academica (NOLOCK) ";

        public List<FormacaoAcademicaDominio> GetList()
        {
            try
            {
                return this.ConexaoBD.Query<FormacaoAcademicaDominio>(_query).ToList();
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

        public FormacaoAcademicaDominio GetById(int id)
        {
            try
            {
                var _buscaFormacao = @$"{_query} WHERE num_formacao = {id}";

                return this.ConexaoBD.QueryFirstOrDefault<FormacaoAcademicaDominio>(_buscaFormacao);
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

        public string Add(FormacaoAcademicaDominio obj)
        {
            try
            {
                var _query = $@" INSERT INTO formacao_academica (desc_formacao, idc_nivel, idc_ativo) 
                                 VALUES ('{obj.DescFormacao.Trim()}', {(int)obj.IdcNivel},'S')";

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

        public string Update(FormacaoAcademicaDominio obj)
        {
            try
            {
                var _query = $@" UPDATE formacao_academica 
                                 SET desc_formacao = '{obj.DescFormacao.Trim()}', 
                                     idc_ativo = '{obj.IdcAtivo}' 
                                 WHERE num_formacao = {obj.Id}";

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
                var _query = $@" DELETE FROM formacao_academica 
                                 WHERE num_formacao = {id}";

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
