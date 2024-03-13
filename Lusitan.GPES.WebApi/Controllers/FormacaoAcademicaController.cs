using Lusitan.GPES.Core.Config;
using Lusitan.GPES.Core.Entidade;
using Lusitan.GPES.Core.Interface.Aplicacao;
using Lusitan.GPES.Core.Interface.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.WebApi.Controllers
{
    [ExcludeFromCodeCoverage]
    public class FormacaoAcademicaController : GPESWebApi<FormacaoAcademicaDominio>
    {
        readonly IFormacaoAcademicaAppService _formacao;

        public FormacaoAcademicaController(ConfigAmbiente config,
                                 IUnitOfWork unitOfWork,
                                 IFormacaoAcademicaAppService formacao)
            : base(config, unitOfWork)
        {
            _formacao = formacao;
        }

        [HttpGet]
        [Authorize(Roles = "Gestor")]
        public IActionResult GetList()
          => Get(_formacao.GetList());

        [HttpGet]
        [Authorize(Roles = "Gestor")]
        [Route("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
           => Get(_formacao.GetById(Id));

        [HttpPost]
        [Authorize(Roles = "Gestor")]
        public IActionResult Insere([FromBody] FormacaoAcademicaDominio obj)
          => Add(ModelState, _formacao, obj);

        [HttpPut]
        [Authorize(Roles = "Gestor")]
        public IActionResult Update([FromBody] FormacaoAcademicaDominio obj)
          => Update(ModelState, _formacao, obj);

        [HttpDelete]
        [Authorize(Roles = "Gestor")]
        [Route("{Id}")]
        public IActionResult Remove([FromRoute] int Id)
          => Remove(ModelState, _formacao, Id);
    }
}
