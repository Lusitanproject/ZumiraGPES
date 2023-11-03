using System.ComponentModel.DataAnnotations;

namespace Lusitan.GPES.Core.Entidade
{
    public class EMailDominio
    {
        [Range(1, int.MaxValue, ErrorMessage = "A aplicação requer que o campo Remetente seja preenchido!")]
        public int NumRemetente { get; set; }

        [Required(ErrorMessage = "A aplicação requer que o campo Destino seja preenchido!")]
        [StringLength(100, ErrorMessage = "O Destino deve possuir no máximo 100 caracteres")]
        public string NomDestino { get; set; }

        [Required(ErrorMessage = "A aplicação requer que o campo Assunto seja preenchido!")]
        [StringLength(100, ErrorMessage = "O Assunto deve possuir no máximo 100 caracteres")]
        public string DescAssunto { get; set; }

        [Required(ErrorMessage = "A aplicação requer que o campo Mensagem seja preenchido!")]
        [StringLength(8000, ErrorMessage = "A Mensagem deve possuir no máximo 8000 caracteres")]
        public string DescMensagem { get; set; }
    }
}
