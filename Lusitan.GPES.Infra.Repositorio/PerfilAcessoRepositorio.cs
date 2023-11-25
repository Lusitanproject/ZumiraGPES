using Dapper;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Infra.Repositorio
{
    [ExcludeFromCodeCoverage]
    public class PerfilAcessoRepositorio : BaseRepositorio, IPerfilAcessoRepositorio
    {
        public PerfilAcessoRepositorio(string strConexao)
            : base(strConexao) { }

        public List<PerfilAcessoDominio> GetList()
        {
            try
            {
                var _query = "SELECT Id = num_perfil, NomPerfil = nom_perfil FROM perfil_acesso (NOLOCK)";

                return this.ConexaoBD.Query<PerfilAcessoDominio>(_query).AsList();
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

        public PerfilAcessoDominio GetById(int id)
        {
            try
            {
                var _query = $"SELECT Id = num_perfil, NomPerfil = nom_perfil FROM perfil_acesso (NOLOCK) WHERE num_perfil = {id}";

                return this.ConexaoBD.QueryFirstOrDefault<PerfilAcessoDominio>(_query);
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
