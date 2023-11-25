using Dapper;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Infra.Repositorio
{
    [ExcludeFromCodeCoverage]
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        public UsuarioRepositorio(string strConexao)
            : base(strConexao) { }

        string _query = @"  SELECT	Id = num_usuario,
                                    NomeUsuario = nom_usuario,
                                    eMail = e_mail,
                                    IdcAtivo = idc_ativo,
                                    UltimoAcesso = dth_ultimo_acesso,
                                    IdcForcaAlteraSenha = idc_forca_altera_senha
                            FROM usuario (NOLOCK) ";

        public List<UsuarioDominio> GetList(string idcAtivo)
        {
            try
            {
                var _novaQuery = $"{_query} WHERE idc_ativo = '{idcAtivo}'";

                return this.ConexaoBD.Query<UsuarioDominio>(_novaQuery).ToList();
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
                var _buscaUsuario = @$"{_query} WHERE num_usuario = {id}";

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

        public UsuarioViewDominio GetByIdComSenha(int id)
        {
            try
            {
                var _buscaUsuario = @$"SELECT	Id = num_usuario,
                                                NomeUsuario = nom_usuario,
                                                eMail = e_mail,
                                                IdcAtivo = idc_ativo,
                                                DesSenha = des_senha,
                                                UltimoAcesso = dth_ultimo_acesso,
                                                IdcForcaAlteraSenha = idc_forca_altera_senha
                                        FROM usuario (NOLOCK) 
                                        WHERE num_usuario = {id}";

                return this.ConexaoBD.QueryFirstOrDefault<UsuarioViewDominio>(_buscaUsuario);
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
                var _buscaUsuario = @$"{_query} WHERE lower(e_mail) = '{eMail.Trim().ToLower()}'";

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

        public UsuarioViewDominio GetUsuarioComSenhaPorEmail(string eMail)
        {
            try
            {
                var _buscaUsuario = @$"SELECT	Id = num_usuario,
                                                NomeUsuario = nom_usuario,
                                                eMail = e_mail,
                                                IdcAtivo = idc_ativo,
                                                DesSenha = des_senha,
                                                UltimoAcesso = dth_ultimo_acesso,
                                                IdcForcaAlteraSenha = idc_forca_altera_senha
                                        FROM usuario (NOLOCK) 
                                        WHERE lower(e_mail) = '{eMail.Trim().ToLower()}'";

                return this.ConexaoBD.QueryFirstOrDefault<UsuarioViewDominio>(_buscaUsuario);
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
                var _query = @" INSERT INTO usuario (nom_usuario, des_senha, e_mail, idc_ativo, dth_ultimo_acesso, idc_forca_altera_senha) 
                                VALUES (@NOM_USUARIO, @DES_SENHA, @E_MAIL, 'A', NULL, 'S')";

                this.ConexaoBD.Execute(_query.ToString(),
                                        new
                                        {
                                            NOM_USUARIO = obj.NomeUsuario.Trim(),
                                            DES_SENHA = obj.DesSenha.Trim(),
                                            E_MAIL = obj.eMail.Trim().ToLower()
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

        public string AlteraSituacao(string idcSituacao, int idUsuario)
        {
            try
            {
                var _query = @$" UPDATE usuario 
                                 SET idc_ativo = '{idcSituacao}'
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

        public string RegistraLogAcesso(int idUsuario)
        {
            try
            {
                var _query = @$" UPDATE usuario 
                                 SET dth_ultimo_acesso = GETDATE()
                                 WHERE num_usuario = {idUsuario}";

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

        public string Update(UsuarioViewDominio obj)
        {
            try
            {
                var _query = @$" UPDATE usuario 
                                 SET nom_usuario            = '{obj.NomeUsuario.Trim()}',
                                     des_senha              = '{obj.DesSenha.Trim()}',
                                     idc_ativo              = '{obj.IdcAtivo}',
                                     idc_forca_altera_senha = '{obj.IdcForcaAlteraSenha}'
                                 WHERE num_usuario = {obj.Id}";

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
