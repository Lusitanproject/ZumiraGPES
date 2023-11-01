using Dapper;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using System.Reflection;

namespace Lusitan.GPES.Infra.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        public UsuarioRepositorio(string strConexao)
            : base(strConexao) { }

        string _query = @"  SELECT	Id = num_usuario,
                                    NomeUsuario = nom_usuario,
                                    eMail = e_mail,
                                    IdcAtivo = idc_ativo
                            FROM usuario (NOLOCK) ";

        public List<UsuarioDominio> GetList()
        {
            try
            {
                return this.ConexaoBD.Query<UsuarioDominio>(_query).ToList();
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
