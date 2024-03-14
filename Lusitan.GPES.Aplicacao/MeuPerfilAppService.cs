using Lusitan.GPES.Aplicacao;
using Lusitan.GPES.Core.Config;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Servico;
using RestSharp;
using System.Reflection;

namespace Lusitan.GPES.Core.Servico
{
    public class MeuPerfilAppService : BaseAplicacao, IMeuPerfilAppService
    {
        readonly IMeuPerfilService _servico;
        readonly ConfigGED _configGED;
        readonly IUsuarioAppService _usuario;

        public MeuPerfilAppService( ConfigGED configGED, 
                                    IUsuarioAppService usuario,     
                                    IMeuPerfilService servico)
        {
            _configGED = configGED;
            _usuario = usuario;
            _servico = servico;
        }

        GEDArquivoComprovanteResponse GetDocGED(string idDoc, int idUsuario)
        {

            var _reqCV = new RestRequest($"api/GED/Documento/{idDoc}", Method.Get);
            _reqCV.AddParameter("NumUsuario", idUsuario);

            var _resultCV = new RestClient(_configGED.WebApi).Execute<GEDArquivoComprovanteResponse>(_reqCV);

            return _resultCV.Data;
        }

        public MeuPerfilResponse BuscaPeloUsuario(int idUsuario)
        {
            try
            {
                var _obj = _servico.BuscaPeloUsuario(idUsuario);

                return _obj == null ? null: new MeuPerfilResponse()
                {
                    IdUsuario = idUsuario,
                    DocCurriculum = this.GetDocGED(_obj.IdDocCurriculum, idUsuario).Arquivo,
                    DocFoto = this.GetDocGED(_obj.IdDocFoto, idUsuario).Arquivo
                };
            }
            catch (Exception ex)
            {
                var _msgErro = "ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(_msgErro);

                throw new Exception(_msgErro);
            }
        }

        public string Add(MeuPerfilRequest obj)
        {
            try
            {
                var _objUsuario = _usuario.GetById(obj.IdUsuario);

                #region Uplocad do CV
                var _reqCV = new RestRequest("api/GED/Documento/Upload", Method.Post);
                _reqCV.AddBody(new
                {
                    nomArquivo = obj.DocCurriculum.NomArquivo,
                    dirArquivo = @$"documentacao\{_objUsuario.eMail}",
                    numUsuario = obj.IdUsuario,
                    arquivo = obj.DocCurriculum.ContArquivo
                });

                var _idCV = RemovePrimeiroEUltimo(new RestClient(_configGED.WebApi).Execute(_reqCV).Content);
                #endregion

                #region Uplocad da Foto
                var _reqFoto = new RestRequest("api/GED/Documento/Upload", Method.Post);
                _reqFoto.AddBody(new
                {
                    nomArquivo = obj.DocFoto.NomArquivo,
                    dirArquivo = @$"documentacao\{_objUsuario.eMail}",
                    numUsuario = obj.IdUsuario,
                    arquivo = obj.DocFoto.ContArquivo
                });

                var _idFoto = RemovePrimeiroEUltimo(new RestClient(_configGED.WebApi).Execute(_reqFoto).Content);
                #endregion

                if (_servico.BuscaPeloUsuario(obj.IdUsuario) != null)
                {
                    _servico.Remove(obj.IdUsuario);
                }

                _servico.Add(new MeuPerfilDominio()
                            {
                                IdUsuario = obj.IdUsuario,
                                IdDocCurriculum = _idCV,
                                IdDocFoto = _idFoto
                            });

                return string.Empty;
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
