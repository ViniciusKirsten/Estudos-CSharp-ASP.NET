using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Essa classe serve para criarmos uma conexão com o nosso banco de dados
namespace ScreenSound.Banco
{
    internal class Connection
    {
        //String de conexão, coletada nas propriedades do banco no campo "Cadeia de conexão"
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public SqlConnection ObterConexao()
        {
            return new SqlConnection(connectionString);
        }
    }
}
