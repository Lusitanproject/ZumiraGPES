using Dapper;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Infra.Repositorio
{
    [ExcludeFromCodeCoverage]
    public class LogAcessoErroRepositorio : BaseRepositorio, ILogAcessoErroRepositorio
    {
        public LogAcessoErroRepositorio(string strConexao)
            : base(strConexao) { }

        string _query = @"  SELECT	IdUsuario = num_usuario,
                                    DthLogErro = dth_log_erro,
                                    DescLogErro = desc_log_erro
                            FROM log_acesso_erro (NOLOCK) ";

        public List<LogAcessoErroDominio> GetByUsuario(int idUsuario)
        {
            try
            {
                var _buscaUsuario = @$"{_query} WHERE num_usuario = {idUsuario}";

                return this.ConexaoBD.Query<LogAcessoErroDominio>(_buscaUsuario).ToList();
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

        public string Add(LogAcessoErroDominio obj)
        {
            try
            {
                var _query = @$" INSERT INTO log_acesso_erro (num_usuario, dth_log_erro, desc_log_erro) 
                                VALUES ({obj.IdUsuario}, GETDATE(), '{obj.DescLogErro.Trim()}')";

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

        public string Delete(int idUsuario)
        {
            try
            {
                var _query = @$" DELETE FROM log_acesso_erro 
                                WHERE num_usuario = {idUsuario}";

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
    }
}
