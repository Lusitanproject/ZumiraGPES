using Dapper;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Infra.Repositorio
{
    [ExcludeFromCodeCoverage]
    public class UsuarioLogRepositorio : BaseRepositorio, IUsuarioLogRepositorio
    {
        public UsuarioLogRepositorio(string strConexao)
            : base(strConexao) { }

        public List<UsuarioLogDominio> GetByUsuario(int idUsuario)
        {
            try
            {
                var _query = $@"SELECT	num_usuario_log as Id,
		                                num_usuario as IdUsuario,
		                                desc_log as DescLog,
		                                dth_log as DthLog,
		                                num_usuario_resp as IdUsuarioResp
                                FROM usuario_log
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
                var _query = @$" INSERT INTO usuario_log (num_usuario_log, num_usuario, desc_log, dth_log, num_usuario_resp) 
                                 VALUES ((SELECT COUNT(num_usuario) + 1 FROM usuario_log WHERE num_usuario = {obj.IdUsuario}), 
                                         {obj.IdUsuario}, 
                                         '{obj.DescLog.Trim()}', 
                                         NOW(), 
                                         {obj.IdUsuarioResp})";

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
