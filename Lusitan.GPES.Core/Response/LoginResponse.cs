﻿using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Response
{
    [ExcludeFromCodeCoverage]
    public class LoginResponse
    {
        public bool LoginEhValido { get; set; }

        public DateTime? UltimoAcesso { get; set; }

        public string Token { get; set; }
    }
}
