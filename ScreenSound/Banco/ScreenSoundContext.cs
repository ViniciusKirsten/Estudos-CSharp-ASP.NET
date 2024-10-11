using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Precisamos ter essa classe devido ao Entity utilizar "Context" para o acesso
namespace ScreenSound.Banco
{
    //OBS: Não consegui instalar o Entity Framework
    internal class ScreenSoundContext: dbContext
    {
        //String de conexão, coletada nas propriedades do banco no campo "Cadeia de conexão"
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;TrustServerCertificate=False; ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public SqlConnection ObterConexao()
        {
            return new SqlConnection(connectionString);
        }
    }
}
