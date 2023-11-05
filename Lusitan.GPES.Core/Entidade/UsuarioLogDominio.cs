using System.ComponentModel.DataAnnotations;

namespace Lusitan.GPES.Core.Entidade
{
    public class UsuarioLogDominio
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A aplicação requer que o campo Usuário seja preenchido!")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "A aplicação requer que o campo E-mail seja preenchido!")]
        [StringLength(100, ErrorMessage = "O E-mail deve possuir no máximo 100 caracteres")]
        public string DescLog { get; set; }

        public DateTime DthLog { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A aplicação requer que o campo Usuário Resp seja preenchido!")]
        public int IdUsuarioResp { get; set; }
    }
}
