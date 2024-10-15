﻿using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL
    {
        //Esse campo e construtor vai ser extraidos pelo meus métodos que chamam o "context"
        private readonly ScreenSoundContext context;
        public ArtistaDAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        public IEnumerable<Artista> listar()
        {
            //MÉTODO UTILIZANDO ENTITY FRAMEWORK
            return context.Artistas.ToList(); //assim ele vai listar as informações dos meus artistas

            //**MÉTODO SEM ENTITY FRAMEWORK**
            //
            //var lista = new List<Artista>(); //criando uma lista para o artista
            //using var connection = new Connection().ObterConexao(); //criando uma conexao com o banco de dados
            //connection.Open(); //abrundo a conexao
            //
            //Consulta SQL
            //string sql = "SELECT * FROM Artistas";
            //
            //Para rodar a consulta que eu declarei acima.
            //SqlCommand command = new SqlCommand(sql, connection);
            //using SqlDataReader dataReader = command.ExecuteReader();
            //
            //laco de repeticao, adicionando o valor dentro da minha lista
            //while (dataReader.Read())
            //{
            //    //essse laco vai repetir toda vez que tiver uma sequencia de informacao que e preciso coletar no banco
            //    string nomeArtista = Convert.ToString(dataReader["Nome"]);
            //    string bioArtista = Convert.ToString(dataReader["Bio"]);
            //    int idArtista = Convert.ToInt32(dataReader["Id"]);
            //    Artista artista = new(nomeArtista, bioArtista) { Id = idArtista };//passando as informações para a minha lista 
            //
            //    lista.Add(artista);
            //}
            //
            //return lista;
        }
        
        public void Adicionar(Artista artista)
        {
            //MÉTODO UTILIZANDO ENTITY FRAMEWORK
            context.Artistas.Add(artista);
            context.SaveChanges();//para salvar os dados adicionados

            //**MÉTODO SEM ENTITY FRAMEWORK**
            //
            // --Adicionando os dados para o meu banco de dado utilizando essa classe
            // --Parte lógica de adicionar a informação para dentro do banco
            //using var connection = new Connection().ObterConexao();
            //connection.Open();
            //
            //string sql = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) VALUES (@nome, @perfilPadrao, @bio)";
            //SqlCommand command = new SqlCommand(sql, connection);
            //
            //command.Parameters.AddWithValue("@nome", artista.Nome);
            //command.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
            //command.Parameters.AddWithValue("@bio", artista.Bio);
            //
            //int retorno = command.ExecuteNonQuery();//para atribuir a quantidade de linhas afetadas no SQL
            //Console.WriteLine($"linhas afetadas {retorno}");
        }

        
        public void Atualizar(Artista artista)
        {
            //MÉTODO UTILIZANDO ENTITY FRAMEWORK
            context.Artistas.Update(artista);
            context.SaveChanges();//para salvar os dados atualizados

            //**MÉTODO SEM ENTITY FRAMEWORK**
            //
            //using var connection = new Connection().ObterConexao();
            //connection.Open();
            //
            //string sql = "UPDATE Artistas SET Nome = @nome, Bio = @bio WHERE Id = @id";
            //SqlCommand command = new SqlCommand(sql, connection);
            //
            //command.Parameters.AddWithValue("@nome", artista.Nome);
            //command.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);
            //command.Parameters.AddWithValue("@bio", artista.Bio);
            //command.Parameters.AddWithValue("@id", artista.Id);
            //
            //int retorno = command.ExecuteNonQuery();//para atribuir a quantidade de linhas afetadas no SQL
            //Console.WriteLine($"linhas afetadas {retorno}");
        }

        public void Deletar(Artista artista)
        {
            //MÉTODO UTILIZANDO ENTITY FRAMEWORK
            context.Artistas.Remove(artista);
            context.SaveChanges();

            //**MÉTODO SEM ENTITY FRAMEWORK**
            //
            //using var connection = new Connection().ObterConexao();
            //connection.Open();
            //
            //string sql = "DELETE FROM Artistas WHERE Id = @id";
            //SqlCommand command = new SqlCommand(sql, connection);
            //
            //command.Parameters.AddWithValue("@id", artista.Id);
            //
            //int retorno = command.ExecuteNonQuery();
            //Console.WriteLine($"Linhas afetadas {retorno}");
        }

        //Essa expressção com o sinal de interrogação é informando que caso o valor não estiver correto ele pode retornar nulo.
        //É um recurso de nullable reference types, que reforça a segurança contra nulos no código.
        public Artista? RecuperarPeloNome(string nome)
        {
            return context.Artistas.FirstOrDefault(a => a.Nome.Equals(nome)); //Expressão lambda para verificar se o nome é igual ao nome que veio na função
        }
    }
}
