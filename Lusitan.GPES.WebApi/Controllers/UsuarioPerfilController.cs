using CORE.Validacao;
using Lusitan.GPES.Core.Config;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lusitan.GPES.WebApi.Controllers
{
    [ExcludeFromCodeCoverage]
    public class UsuarioPerfilController : GPESWebApi<UsuarioPerfilDominio>
    {
        readonly IPerfilAcessoAppService _perfilAcesso;
        readonly IUsuarioPerfilAppService _usuarioPerfil;

        public UsuarioPerfilController(ConfigAmbiente config,
                                 IUnitOfWork unitOfWork,
                                 IPerfilAcessoAppService perfilAcesso,
                                 IUsuarioPerfilAppService usuarioPerfil)
            : base(config, unitOfWork)
        {
            _perfilAcesso = perfilAcesso;
            _usuarioPerfil = usuarioPerfil;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("perfil-acesso")]
        public IActionResult ListaPerfil()
        {
            try
            {
                var _lst = _perfilAcesso.GetList();

                return _lst.Count() == 0 ? NotFound(_lst) : Ok(_lst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("perfil-acesso/lista-por-usuario/{IdUsuario}")]
        public IActionResult ListaPerfilPorUsuario([FromRoute] int IdUsuario)
        {
            try
            {
                var _lst = _usuarioPerfil.GetByUsuario(IdUsuario);

                return _lst.Count() == 0 ? NotFound(_lst) : Ok(_lst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("usuario-perfil")]
        public ActionResult ExcluiUsuarioPErfil([FromBody] UsuarioPerfilDominio obj)
        {
            try
            {
                var _msg = ValidaPreenchimento.Validar(obj);

                if (!string.IsNullOrEmpty(_msg))
                {
                    return this.StatusCode(StatusCodes.Status422UnprocessableEntity, _msg);
                }

                _msg = _usuarioPerfil.Remove(obj);

                return string.IsNullOrEmpty(_msg) ? Ok(_msg) : BadRequest(_msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
