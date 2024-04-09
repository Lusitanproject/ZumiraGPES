using Lusitan.GPES.Core.Config;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Enum;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Servico;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Lusitan.GPES.Aplicacao
{
    public class MinhaFormacaoAppService : BaseAplicacao, IMinhaFormacaoAppService
    {
        readonly IUsuarioServico _usuario;
        readonly IFormacaoAcademicaService _formacacaoAcademica;
        readonly IMinhaFormacaoService _servico;

        public MinhaFormacaoAppService( ConfigXMS configXMS,
                                        IMinhaFormacaoService servico,
                                        IUsuarioServico usuario,
                                        IFormacaoAcademicaService formacacaoAcademica)
            : base(configXMS)
        {
            _usuario = usuario;
            _servico = servico;
            _formacacaoAcademica = formacacaoAcademica;
        }

        MinhaFormacaoViewDominio GetMinhaFormacao(MinhaFormacaoDominio obj)
        {
            SituacaoMinhaFormacaoEnum _idcSituacao = SituacaoMinhaFormacaoEnum.Inacabado;

            switch (obj.IdcSituacao)
            {
                case "A":
                    _idcSituacao = SituacaoMinhaFormacaoEnum.EmAndamento;
                    break;

                case "C":
                    _idcSituacao = SituacaoMinhaFormacaoEnum.Concluido;
                    break;
            }

            return new MinhaFormacaoViewDominio()
            {
                Id = obj.Id,
                Usuario = _usuario.GetById(obj.IdUsuario),
                FormacaoAcademica = _formacacaoAcademica.GetById(obj.IdFormacaoAcademica),
                MesAnoInicio = obj.MesAnoInicio,
                MesAnoFim = obj.MesAnoFim,
                IdcSituacao = _idcSituacao
            };
        }

        public List<MinhaFormacaoViewDominio> BuscaPeloUsuario(int idUsuario)
        {
            try
            {
                return (from lst in _servico.BuscaPeloUsuario(idUsuario)
                       select this.GetMinhaFormacao(lst)).ToList();
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public string Add(MinhaFormacaoDominio obj)
        {
            try
            {
                if (this.BuscaPeloUsuario(obj.IdUsuario).Where(x => x.FormacaoAcademica.Id == obj.IdFormacaoAcademica).Count() != 0)
                {
                    return "Formação Acadêmica já cadastrada!";
                }

                return _servico.Add(obj);
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public string Remove(int id)
        {
            try
            {
                return _servico.Remove(id);
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }
    }
}
