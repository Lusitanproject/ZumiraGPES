using Lusitan.GPES.Core.Interface.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Lusitan.GPES.Core.Base.Interface.CRUD;
using CORE.Validacao;
using Lusitan.GPES.Core.Config;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;

namespace Lusitan.GPES.WebApi.Controllers
{
    [Route("/api/GPES/[Controller]")]
    [ExcludeFromCodeCoverage]
    public class GPESWebApi<T> : ControllerBase where T : class
    {
        protected ConfigAmbiente _config;
        readonly IUnitOfWork _unitOfWork;

        public GPESWebApi(ConfigAmbiente config, IUnitOfWork unitOfWork)
        {
            _config = config;
            _unitOfWork = unitOfWork;

            _unitOfWork.StrConexao = config.StrConexao;
        }

        ActionResult TrataMetodo(ActionResult m)
        {
            try
            {
                return m;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected ActionResult Get(IList<T> lst)
            => this.TrataMetodo(lst.Count() == 0 ? NotFound(lst) : Ok(lst));

        protected ActionResult Get(T obj)
            => this.TrataMetodo(obj == null ? NotFound() : Ok(obj));

        protected ActionResult Add(ModelStateDictionary estado, IAdd<T> servico, T obj)
        {
            try
            {
                var _msg = ValidaPreenchimento.Validar(obj);

                if (!string.IsNullOrEmpty(_msg))
                {
                    return this.StatusCode(StatusCodes.Status422UnprocessableEntity, _msg);
                }

                _msg = servico.Add(obj);

                return string.IsNullOrEmpty(_msg) ? this.StatusCode(StatusCodes.Status201Created, _msg) : BadRequest(_msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected ActionResult Update(ModelStateDictionary estado, IUpdate<T> servico, T obj)
        {
            try
            {
                var _msg = ValidaPreenchimento.Validar(obj);

                if (!string.IsNullOrEmpty(_msg))
                {
                    return this.StatusCode(StatusCodes.Status201Created, _msg);
                }

                _msg = servico.Update(obj);

                return string.IsNullOrEmpty(_msg) ? Ok(_msg) : BadRequest(_msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected ActionResult Remove(ModelStateDictionary estado, IRemove servico, int Id)
        {
            try
            {
                var _msg = servico.Remove(Id);

                return string.IsNullOrEmpty(_msg) ? Ok(_msg) : BadRequest(_msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
