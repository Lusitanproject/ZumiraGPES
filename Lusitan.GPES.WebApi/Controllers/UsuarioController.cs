using CORE.Validacao;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;

namespace Lusitan.GPES.WebApi.Controllers
{
    [ApiController]
    public class UsuarioController : GPESWebApi<UsuarioDominio>
    {
        readonly IUsuarioAppService _appServico;
        readonly IStringLocalizer<UsuarioController> _local;

        public UsuarioController(ConfigAmbiente config,
                                 IUnitOfWork unitOfWork,
                                 IUsuarioAppService appServico,
                                 IStringLocalizer<UsuarioController> local)
            : base(config, unitOfWork)
        {
            _appServico = appServico;
            _local = local;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            try
            {
                var _xpto = _local["msg"];


                var _msg = ValidaPreenchimento.Validar(login);

                if (!string.IsNullOrEmpty(_msg))
                {
                    return BadRequest(_msg);
                }

                var _response = _appServico.Login(login);

                return _response.LoginEhValido ? Ok(_response) : BadRequest(_response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("busca-por-email/{eMail}")]
        public IActionResult BuscaPorEMail(string eMail)
           => Get(_appServico.GetUsuarioSemSenhaPorEmail(eMail.Trim()));

        [HttpGet]
        [AllowAnonymous]
        [Route("busca-por-id/{id}")]
        public IActionResult BuscaPorId(int id)
           => Get(_appServico.GetById(id));

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Admin")]
        public IActionResult ListaAdmin()
           => Get(_appServico.GetListAdmin());

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("Admin")]
        public ActionResult InsereAdmin([FromBody] UsuarioDominio obj)
        {
            try
            {
                var _msg = ValidaPreenchimento.Validar(obj);

                if (!string.IsNullOrEmpty(_msg))
                {
                    return BadRequest(_msg);
                }

                _msg = _appServico.AddAdmin(obj);

                return string.IsNullOrEmpty(_msg) ? Ok(_msg) : BadRequest(_msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
