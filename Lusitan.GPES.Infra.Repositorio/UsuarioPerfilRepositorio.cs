using Dapper;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using System.Reflection;

namespace Lusitan.GPES.Infra.Repositorio
{
    public class UsuarioPerfilRepositorio : BaseRepositorio, IUsuarioPerfilRepositorio
    {
        public UsuarioPerfilRepositorio(string strConexao)
            : base(strConexao) { }

        string _query = @"  SELECT	IdUsuario = num_usuario,
                                    IdPerfilAcesso = num_perfil
                            FROM usuario_perfil (NOLOCK) ";

        public string Add(UsuarioPerfilDominio obj)
        {
            try
            {
                var _query = @" INSERT INTO usuario_perfil (num_usuario, num_perfil) 
                                VALUES (@NUM_USUARIO, @NUM_PERFIL)";

                this.ConexaoBD.Execute(_query.ToString(), new { NUM_USUARIO = obj.IdUsuario, NUM_PERFIL = obj.IdPerfilAcesso });

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

        public List<UsuarioPerfilDominio> GetByPerfil(int idPerfil)
        {
            try
            {
                var _queryUsuarioPerfil = @$"{_query} WHERE num_perfil = @NUM_PERFIL";

                return this.ConexaoBD.Query<UsuarioPerfilDominio>(_queryUsuarioPerfil, new { NUM_PERFIL = idPerfil }).ToList();
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

        public List<UsuarioPerfilDominio> GetByUsuario(int idUsuario)
        {
            try
            {
                var _queryUsuarioPerfil = @$"{_query} WHERE num_usuario = @NUM_USUARIO";

                return this.ConexaoBD.Query<UsuarioPerfilDominio>(_queryUsuarioPerfil, new { NUM_USUARIO = idUsuario }).ToList();
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
