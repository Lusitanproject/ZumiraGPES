﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using CORE.Validacao;
using Lusitan.GPES.Core.Base;

namespace Lusitan.GPES.Core.Entidade
{
    [ExcludeFromCodeCoverage]
    public class UsuarioDominio: BaseDomonio
    {
        public string Token { get; set; }

        [Required(ErrorMessage = "A aplicação requer que o campo Nome seja preenchido!")]
        [StringLength(100, ErrorMessage = "O Nome deve possuir no máximo 100 caracteres")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "A aplicação requer que o campo E-mail seja preenchido!")]
        [StringLength(100, ErrorMessage = "O E-mail deve possuir no máximo 100 caracteres")]
        [ValidaEMail]
        public string eMail { get; set; }

        public DateTime? UltimoAcesso { get; set; }

        public string IdcForcaAlteraSenha { get; set; }

        public string DescForcaAlteraSenha
        {
            get { return this.IdcForcaAlteraSenha == "S" ? "Sim" : "Não"; }
        }

        public string DescSituacao
        {
            get {      
                
                var _descSituacao = string.Empty;

                switch (this.IdcAtivo)
                {
                    case "A":
                        _descSituacao = "Ativo";
                        break;

                    case "I":
                        _descSituacao = "Inativo";
                        break;

                    case "B":
                        _descSituacao = "Bloqueado";
                        break;
                }

                return _descSituacao; 
            }
        }
    }

    public class UsuarioViewDominio : UsuarioDominio
    {
        public string DesSenha { get; set; }
    }
}
