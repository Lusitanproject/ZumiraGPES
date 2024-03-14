using Lusitan.GPES.Core.Config;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lusitan.GPES.WebApi.Controllers
{
    [ExcludeFromCodeCoverage]
    public class MinhaFormacaoController : GPESWebApi<MinhaFormacaoDominio>
    {
        readonly IMinhaFormacaoAppService _minhaFormacao;

        public MinhaFormacaoController(ConfigAmbiente config,
                                 IUnitOfWork unitOfWork,
                                 IMinhaFormacaoAppService minhaFormacao)
            : base(config, unitOfWork)
        {
            _minhaFormacao = minhaFormacao;
        }

        [HttpGet]
        [Authorize]
        [Route("{IdUsuario}")]
        public IActionResult GetList([FromRoute] int IdUsuario)
        {
            try
            {
                var _lst = _minhaFormacao.BuscaPeloUsuario(IdUsuario);

                return _lst.Count() == 0 ? NotFound(_lst) : Ok(_lst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Insere([FromBody] MinhaFormacaoDominio obj)
          => Add(ModelState, _minhaFormacao, obj);

        [HttpDelete]
        [Authorize]
        [Route("{Id}")]
        public IActionResult Remove([FromRoute] int Id)
          => Remove(ModelState, _minhaFormacao, Id);
    }
}
