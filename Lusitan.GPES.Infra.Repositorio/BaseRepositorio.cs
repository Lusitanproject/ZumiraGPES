using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace Lusitan.GPES.Infra.Repositorio
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseRepositorio
    {
        protected BaseRepositorio(string strConexao)
            => _strConexao = strConexao;

        readonly string _strConexao;

        static IDbConnection _conexao;

        protected IDbConnection ConexaoBD
        {
            get
            {
                FechaConexao();

                _conexao = new SqlConnection(_strConexao);
                _conexao.Open();

                return _conexao;
            }
        }

        protected void FechaConexao()
        {
            if (_conexao != null)
            {
                _conexao.Close();
            }
        }
    }
}
