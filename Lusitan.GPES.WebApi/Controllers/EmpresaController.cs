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
    public class EmpresaController : GPESWebApi<EmpresaDominio>
    {
        readonly IEmpresaAppService _empresa;

        public EmpresaController(ConfigAmbiente config,
                                 IUnitOfWork unitOfWork,
                                 IEmpresaAppService empresa)
            : base(config, unitOfWork)
        {
            _empresa = empresa;
        }

        [HttpGet]
        [Authorize(Roles = "Gestor")]
        public IActionResult GetList()
          => Get(_empresa.GetList());

        [HttpGet]
        [Authorize(Roles = "Gestor")]
        [Route("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
           => Get(_empresa.GetById(Id));

        [HttpPost]
        [Authorize(Roles = "Gestor")]
        public IActionResult Insere([FromBody] EmpresaDominio obj)
          => Add(ModelState, _empresa, obj);

        [HttpPut]
        [Authorize(Roles = "Gestor")]
        public IActionResult Update([FromBody] EmpresaDominio obj)
          => Update(ModelState, _empresa, obj);

        [HttpDelete]
        [Authorize(Roles = "Gestor")]
        [Route("{Id}")]
        public IActionResult Remove([FromRoute] int Id)
          => Remove(ModelState, _empresa, Id);
    }
}
