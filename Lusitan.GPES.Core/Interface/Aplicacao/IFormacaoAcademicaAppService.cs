﻿using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Aplicacao
{
    public interface IFormacaoAcademicaAppService : IGetList<FormacaoAcademicaDominio>,
                                                    IGetById<FormacaoAcademicaDominio>,
                                                    IAdd<FormacaoAcademicaDominio>,
                                                    IUpdate<FormacaoAcademicaDominio>,
                                                    IRemove
    {
    }
}
