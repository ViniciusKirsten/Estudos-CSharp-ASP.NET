using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Modelos;
using System.Linq.Expressions;

/*CODIGO DA PRIMEIRA CONEXAO
//Nossa conexão que busca da pasta Connection
try{
    // "using" vai gerenciar os recursos de conexao, sendo assim os recursos só vão ser executados no escopo que eles estao sendo utilizados
    using var connection = new Connection().ObterConexao();
    connection.Open();
    Console.WriteLine(connection.State); //Vai retornar o estado da nossa conexão
}
catch (Exception ex){
    Console.WriteLine(ex.Message);
}
*/

//ISSO ERA APENAS PARA TESTAR ENQUANTO NÃO ESTA TUDO CONFIGURADO
//
//try
//{
//    var context = new ScreenSoundContext();
//    var artistaDAL = new ArtistaDAL(context);
//
//    var novoArtista = new Artista("Gilberto Gil", "Teste bio") { Id = 2};
//    artistaDAL.Atualizar(novoArtista);
//
//    var listaArtistas = artistaDAL.listar();
//    foreach( var artista in listaArtistas)
//    {
//        Console.WriteLine(artista);
//    }
//}
//catch (Exception ex)
//{
//
//    Console.WriteLine(ex.Message);
//}
//
//return;

var context = new ScreenSoundContext();
var artistaDAL = new ArtistaDAL(context);

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuRegistrarArtista());
opcoes.Add(2, new MenuRegistrarMusica());
opcoes.Add(3, new MenuMostrarArtistas());
opcoes.Add(4, new MenuMostrarMusicas());
opcoes.Add(-1, new MenuSair());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 3.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um artista");
    Console.WriteLine("Digite 2 para registrar a música de um artista");
    Console.WriteLine("Digite 3 para mostrar todos os artistas");
    Console.WriteLine("Digite 4 para exibir todas as músicas de um artista");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
        menuASerExibido.Executar(artistaDAL);
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    } 
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();