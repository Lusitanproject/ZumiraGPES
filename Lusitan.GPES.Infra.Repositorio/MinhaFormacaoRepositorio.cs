﻿using Dapper;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Repositorio;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Infra.Repositorio
{
    [ExcludeFromCodeCoverage]
    public class MinhaFormacaoRepositorio: BaseRepositorio, IMinhaFormacaoRepositorio
    {
        public MinhaFormacaoRepositorio(string strConexao)
            : base(strConexao) { }

        string _query = @"  select Id = num_minha_formacao,
		                                IdUsuario = num_usuario,
		                                IdFormacaoAcademica = num_formacao,
		                                MesAnoInicio = mes_ano_inicio,
		                                MesAnoFim = mes_ano_fim,
		                                IdcSituacao = idc_situacao
                            from minha_formacao (NOLOCK) ";

        public List<MinhaFormacaoDominio> BuscaPeloUsuario(int idUsuario)
        {
            try
            {
                return this.ConexaoBD.Query<MinhaFormacaoDominio>($"{_query} WHERE num_usuario = {idUsuario}").ToList();
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

        public string Add(MinhaFormacaoDominio obj)
        {
            try
            {

                var _query = $@" INSERT INTO minha_formacao (num_usuario, num_formacao, mes_ano_inicio, mes_ano_fim, idc_situacao) 
                                 VALUES ({obj.IdUsuario}, {obj.IdFormacaoAcademica}, '{obj.MesAnoInicio}', '{obj.MesAnoFim}', '{obj.IdcSituacao}')";

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
                var _query = $@" DELETE FROM minha_formacao WHERE num_minha_formacao = {id}";

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
