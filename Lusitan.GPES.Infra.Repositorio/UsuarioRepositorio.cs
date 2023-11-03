using Dapper;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using System.Reflection;
using System.Security.Cryptography;

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

        public UsuarioDominio GetUsuarioSemSenhaPorEmail(string eMail)
        {
            try
            {
                var _buscaUsuario = @$"{_query} WHERE e_mail = '{eMail.Trim()}'";

                return this.ConexaoBD.QueryFirstOrDefault<UsuarioDominio>(_buscaUsuario);
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

        public string Add(UsuarioViewDominio obj)
        {
            try
            {
                var _query = @" INSERT INTO usuario (nom_usuario, des_senha, e_mail, idc_ativo) 
                                VALUES (@NOM_USUARIO, @DES_SENHA, @E_MAIL, 'S')";

                this.ConexaoBD.Execute(_query.ToString(),
                                        new
                                        {
                                            NOM_USUARIO = obj.NomeUsuario.Trim(),
                                            DES_SENHA = obj.DesSenha.Trim(),
                                            E_MAIL = obj.eMail.Trim()
                                        });

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

        public UsuarioDominio GetById(int id)
        {
            try
            {
                var _buscaUsuario = @$"{_query} WHERE num_usuario = '{id.ToString()}";

                return this.ConexaoBD.QueryFirstOrDefault<UsuarioDominio>(_buscaUsuario);
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
