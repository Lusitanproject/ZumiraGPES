﻿using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Servico
{
    public interface ICargoServico : IGetList<CargoDominio>,
                                         IGetById<CargoDominio>,
                                         IAdd<CargoDominio>,
                                         IUpdate<CargoDominio>,
                                         IRemove
    {
        CargoDominio BuscaPelaDescricao(string descCargo);
    }
}
