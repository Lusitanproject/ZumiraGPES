using CORE.Validacao;
using Lusitan.GPES.Aplicacao;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Interface.Servico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Lusitan.GPES.WebApi.Controllers
{
    public class UsuarioController : GPESWebApi<UsuarioDominio>
    {
        readonly IUsuarioAppService _appServico;

        public UsuarioController(ConfigAmbiente config,
                                 IUnitOfWork unitOfWork,
                                 IUsuarioAppService appServico)
            : base(config, unitOfWork)
        {
            _appServico = appServico;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/GPES/Login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            try
            {
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
        [Authorize(Roles = "Admin")]
        [Route("api/GPES/Admin")]
        public IActionResult ListaAdmin()
           => Get(_appServico.GetListAdmin());

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("api/GPES/Admin")]
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
