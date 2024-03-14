using Lusitan.GPES.Core.Config;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.WebApi.Controllers
{
    [ExcludeFromCodeCoverage]
    public class MeuPerfilController : GPESWebApi<MeuPerfilRequest>
    {
        readonly IMeuPerfilAppService _meuPerfil;

        public MeuPerfilController(ConfigAmbiente config,
                                 IUnitOfWork unitOfWork,
                                 IMeuPerfilAppService meuPerfil)
            : base(config, unitOfWork)
        {
            _meuPerfil = meuPerfil;
        }

        [HttpGet]
        [Authorize]
        [Route("{IdUsuario}")]
        public IActionResult GetList([FromRoute] int IdUsuario)
        {
            try
            {
                var _lst = _meuPerfil.BuscaPeloUsuario(IdUsuario);

                return _lst == null ? NotFound(_lst) : Ok(_lst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Insere([FromBody] MeuPerfilRequest obj)
          => Add(ModelState, _meuPerfil, obj);

        [HttpDelete]
        [Authorize]
        [Route("{Id}")]
        public IActionResult Remove([FromRoute] int Id)
          => Remove(ModelState, _meuPerfil, Id);
    }
}
