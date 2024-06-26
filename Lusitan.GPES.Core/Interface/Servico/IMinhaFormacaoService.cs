﻿using Lusitan.GPES.Core.Base.Interface.CRUD;
using Lusitan.GPES.Core.Entidade;

namespace Lusitan.GPES.Core.Interface.Servico
{
    public interface IMinhaFormacaoService : IAdd<MinhaFormacaoDominio>,
                                             IRemove
    {
        List<MinhaFormacaoDominio> BuscaPeloUsuario(int idUsuario);
    }
}
