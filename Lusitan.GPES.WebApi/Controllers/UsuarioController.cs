using CORE.Validacao;
using Lusitan.GPES.Core.Config;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Repositorio;
using Lusitan.GPES.Core.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lusitan.GPES.WebApi.Controllers
{
    public class UsuarioController : GPESWebApi<UsuarioDominio>
    {
        readonly IUsuarioAppService _appServico;
        readonly IUsuarioLogAppService _log;

        public UsuarioController(ConfigAmbiente config,
                                 IUnitOfWork unitOfWork,
                                 IUsuarioAppService appServico,
                                 IUsuarioLogAppService log)
            : base(config, unitOfWork)
        {
            _appServico = appServico;
            _log = log;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
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
        [Route("admin")]
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

        [HttpPut]
        [Authorize]
        [Route("admin")]
        public ActionResult Update(int idUsuario, string nomUsuario, string idcAtivo, string idcForcaAlteraSenha, int idUsuarioResp)
        {
            try
            {
                var _msg = _appServico.Update(idUsuario, nomUsuario, idcAtivo, idcForcaAlteraSenha, idUsuarioResp);

                return string.IsNullOrEmpty(_msg) ? Ok(_msg) : BadRequest(_msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("altera-senha")]
        public ActionResult AlteraSenha([FromBody] AlteraSenhaRequest obj)
        {
            try
            {
                var _msg = ValidaPreenchimento.Validar(obj);

                if (!string.IsNullOrEmpty(_msg))
                {
                    return BadRequest(_msg);
                }

                _msg = _appServico.AlteraSenha(obj);

                return string.IsNullOrEmpty(_msg) ? Ok(_msg) : BadRequest(_msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("reenvia-senha-email")]
        public ActionResult ReenviaSenha(int idUsuario, int idUsuarioResp)
        {
            try
            {
                var _msg = _appServico.ReenviaSenha(idUsuario, idUsuarioResp);

                return string.IsNullOrEmpty(_msg) ? Ok(_msg) : BadRequest(_msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("log/{id}")]
        public IActionResult BuscaLogUsuario(int id)
        {
            try
            {
                var _lstLog = _log.GetByUsuario(id);

                return _lstLog.Count() == 0 ? NotFound(_lstLog) : Ok(_lstLog);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
