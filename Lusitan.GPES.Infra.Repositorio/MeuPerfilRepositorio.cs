using Dapper;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using System.Reflection;

namespace Lusitan.GPES.Infra.Repositorio
{
    public class MeuPerfilRepositorio : BaseRepositorio, IMeuPerfilRepositorio
    {
        public MeuPerfilRepositorio(string strConexao)
            : base(strConexao) { }

        string _query = @"  select num_usuario as IdUsuario,
                                   id_doc_curriculumn as IdDocCurriculum,
                                   id_doc_foto as IdDoc
                            from meu_perfil ";

        public MeuPerfilDominio BuscaPeloUsuario(int idUsuario)
        {
            try
            {
                var _buscaCargo = @$"{_query} WHERE num_usuario = {idUsuario}";

                return this.ConexaoBD.QueryFirstOrDefault<MeuPerfilDominio>(_buscaCargo);
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

        public string Add(MeuPerfilDominio obj)
        {
            try
            {

                var _query = $@" INSERT INTO meu_perfil (num_usuario, id_doc_curriculumn, id_doc_foto) 
                                 VALUES ({obj.IdUsuario}, '{obj.IdDocCurriculum.Trim()}', '{obj.IdDocFoto}')";

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

        public string Remove(int id)
        {
            try
            {
                var _query = $@" DELETE FROM meu_perfil WHERE num_usuario = {id}";

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
