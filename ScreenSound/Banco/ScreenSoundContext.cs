using Microsoft.EntityFrameworkCore;//para utilizar o Entity Framework
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ORM - Object-Relational Mapping
//Responsável por fazer o mapeamento do banco relacional com uma aplicação orientada a objetos.

//Precisamos ter essa classe devido ao Entity utilizar "Context" para o acesso
namespace ScreenSound.Banco
{
    //OBS: Não consegui instalar o Entity Framework
    internal class ScreenSoundContext: DbContext
    {
        //mapeando a nossa tabela de artistas para a nossa classe de artistas
        public DbSet<Artista> Artistas { get; set; }  //"Artistas" precisa ser o mesmo nome que a nossa tabela [nome da tabela: Artistas]

        public DbSet<Musica> Musica { get; set; }
        //String de conexão, coletada nas propriedades do banco no campo "Cadeia de conexão"
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;TrustServerCertificate=False; ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        //basicamente ele faz a mesma coisa que o obter conexão, porém utilizando o entity e o SQLServer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        /*
         * MÉTODO ANTIGO DE FAZER A CONEXÃO 
        public SqlConnection ObterConexao()
        {
            return new SqlConnection(connectionString);
        }
        */
    }
}
