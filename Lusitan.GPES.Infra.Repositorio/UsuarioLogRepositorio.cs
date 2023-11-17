using Dapper;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using System.Reflection;

namespace Lusitan.GPES.Infra.Repositorio
{
    public class UsuarioLogRepositorio : BaseRepositorio, IUsuarioLogRepositorio
    {
        public UsuarioLogRepositorio(string strConexao)
            : base(strConexao) { }

        public List<UsuarioLogDominio> GetByUsuario(int idUsuario)
        {
            try
            {
                var _query = $@"SELECT	Id = num_usuario_log,
		                                IdUsuario = num_usuario,
		                                DescLog = desc_log,
		                                DthLog = dth_log,
		                                IdUsuarioResp = num_usuario_resp
                                FROM usuario_log (NOLOCK) 
                                WHERE num_usuario = {idUsuario} ";

                return this.ConexaoBD.Query<UsuarioLogDominio>(_query).ToList();

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

        public string Add(UsuarioLogDominio obj)
        {
            try
            {
                var _query = @$" DECLARE @IdLog INT
                                 SELECT @IdLog = COUNT(num_usuario) + 1 FROM usuario_log WHERE num_usuario = {obj.IdUsuario}
                                 INSERT INTO usuario_log (num_usuario_log, num_usuario, desc_log, dth_log, num_usuario_resp) 
                                 VALUES (@IdLog, {obj.IdUsuario}, '{obj.DescLog.Trim()}', GETDATE(), {obj.IdUsuarioResp})";

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
