﻿using Dapper;
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

        string _queryBuscaUsuarioSemSenha = @"  SELECT	num_usuario as Id,
                                                        nom_usuario as NomeUsuario,
                                                        e_mail as eMail,
                                                        idc_ativo as IdcAtivo,
                                                        dth_ultimo_acesso as UltimoAcesso,
                                                        idc_forca_altera_senha as IdcForcaAlteraSenha
                                                FROM usuario ";

        string _queryBuscaUsuarioComSenha = @$"SELECT	num_usuario as Id,
                                                nom_usuario as NomeUsuario,
                                                e_mail as eMail,
                                                idc_ativo as IdcAtivo,
                                                des_senha as DesSenha,
                                                dth_ultimo_acesso as UltimoAcesso,
                                                idc_forca_altera_senha as IdcForcaAlteraSenha
                                        FROM usuario";

        public List<UsuarioDominio> GetList(string idcAtivo)
        {
            try
            {
                var _novaQuery = $"{_queryBuscaUsuarioSemSenha} WHERE idc_ativo = '{idcAtivo}'";

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
                var _buscaUsuario = @$"{_queryBuscaUsuarioSemSenha} WHERE num_usuario = {id}";

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
                var _buscaUsuario = @$"{_queryBuscaUsuarioComSenha} WHERE num_usuario = {id}";

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
                var _buscaUsuario = @$"{_queryBuscaUsuarioSemSenha} WHERE lower(e_mail) = '{eMail.Trim().ToLower()}'";

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
                var _buscaUsuario = @$"{_queryBuscaUsuarioComSenha} WHERE lower(e_mail) = '{eMail.Trim().ToLower()}'";

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
                var _query = @$" INSERT INTO usuario (nom_usuario, des_senha, e_mail, idc_ativo, dth_ultimo_acesso, idc_forca_altera_senha) 
                                VALUES ('{obj.NomeUsuario.Trim()}', '{obj.DesSenha.Trim()}', '{obj.eMail.Trim().ToLower()}', 'A', NULL, 'S')";

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
                                 SET dth_ultimo_acesso = NOW()
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
