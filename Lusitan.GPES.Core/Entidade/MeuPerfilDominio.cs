using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Core.Entidade
{
    public class MeuPerfilDominio
    {
        [Range(1, int.MaxValue, ErrorMessage = "A aplicação requer que o campo Usuário seja preenchido!")]
        public int IdUsuario { get; set; }

        public string IdDocCurriculum { get; set; }

        public string IdDocFoto { get; set; }
    }

    public class MeuPerfilRequest
    {
        public int IdUsuario { get; set; }

        public ArquivoDominioRequest DocCurriculum { get; set; }

        public ArquivoDominioRequest DocFoto { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ArquivoDominioRequest
    {
        public string NomArquivo { get; set; }

        public byte[] ContArquivo { get; set; }

    }

    public class MeuPerfilResponse
    {
        public int IdUsuario { get; set; }

        public string DocCurriculum { get; set; }

        public string DocFoto { get; set; }
    }


}
