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
    public class CargoController : GPESWebApi<CargoDominio>
    {
        readonly ICargoAppService _cargo;

        public CargoController(ConfigAmbiente config,
                                 IUnitOfWork unitOfWork,
                                 ICargoAppService cargo)
            : base(config, unitOfWork)
        {
            _cargo = cargo;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetList()
          => Get(_cargo.GetList());

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        [Route("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
           => Get(_cargo.GetById(Id));

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IActionResult Insere([FromBody] CargoDominio obj)
          => Add(ModelState, _cargo, obj);

        [HttpPut]
        //[Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody] CargoDominio obj)
          => Update(ModelState, _cargo, obj);

    }
}
