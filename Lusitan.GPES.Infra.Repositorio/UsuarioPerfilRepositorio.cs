using Dapper;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Infra.Repositorio
{
    [ExcludeFromCodeCoverage]
    public class UsuarioPerfilRepositorio : BaseRepositorio, IUsuarioPerfilRepositorio
    {
        public UsuarioPerfilRepositorio(string strConexao)
            : base(strConexao) { }

        string _query = @"  SELECT	num_usuario as IdUsuario,
                                    num_perfil as IdPerfilAcesso
                            FROM usuario_perfil ";

        public List<UsuarioPerfilDominio> GetByPerfil(int idPerfil)
        {
            try
            {
                var _queryUsuarioPerfil = @$"{_query} WHERE num_perfil = {idPerfil}";

                return this.ConexaoBD.Query<UsuarioPerfilDominio>(_queryUsuarioPerfil).ToList();
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
                var _queryUsuarioPerfil = @$"{_query} WHERE num_usuario = {idUsuario}";

                return this.ConexaoBD.Query<UsuarioPerfilDominio>(_queryUsuarioPerfil).ToList();
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

        public string Add(UsuarioPerfilDominio obj)
        {
            try
            {
                var _query = @$" INSERT INTO usuario_perfil (num_usuario, num_perfil) 
                                 VALUES ({obj.IdUsuario}, {obj.IdPerfilAcesso})";

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

        public string Remove(UsuarioPerfilDominio obj)
        {
            try
            {
                var _query = @$" DELETE FROM usuario_perfil 
                                 WHERE num_usuario = {obj.IdUsuario}
                                 AND num_perfil = {obj.IdPerfilAcesso}";

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
