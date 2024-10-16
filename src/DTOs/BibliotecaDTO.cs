using System;
using main.src.entities;
using Spectre.Console;
using UMC_Nocoes_Projeto.src.repositories;
using UMC_Nocoes_Projeto.src.templates;

namespace UMC_Nocoes_Projeto.src.DTOs
{
    public class BibliotecaDTO : TemplateMethod
    {
        Livroteste livro;
        Repository repo;
        public void Criar_livro()
        {
            livro = new Livroteste();
            Console.WriteLine("ISBN: ");
            livro.SetISBN(Console.ReadLine().ToString());

            Console.WriteLine("Titulo: ");
            livro.SetTitulo(Console.ReadLine().ToString());

            Console.WriteLine("Autor: ");
            livro.SetAutor(Console.ReadLine().ToString());

            Console.WriteLine("Ano: ");
            livro.SetAno(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Genero: ");
            livro.SetGenero(Console.ReadLine().ToString());

            Console.WriteLine("Edicao: ");
            livro.SetEdicao(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Quantidade: ");
            livro.SetQuantidade(Convert.ToInt32(Console.ReadLine()));

            string sql = $"INSERT INTO Livroteste (isbn, titulo, autor, ano, genero, edicao, quantidade) VALUES ('{livro.GetISBN()}', '{livro.GetTitulo()}', '{livro.GetAutor()}', {livro.GetAno()}, '{livro.GetGenero()}', {livro.GetEdicao()}, {livro.GetQuantidade()});";

            using (Repository repository = new Repository())
            {
                repository.executeScript(sql);
            }
        }

        public void Pesquisar_livro()
        {
            Livroteste pesquisa = new Livroteste();
            Console.WriteLine("Titulo: ");
            pesquisa.SetTitulo(Console.ReadLine().ToString());


            string sql = "";
            sql = $"SELECT * FROM Livroteste WHERE titulo LIKE '%{pesquisa.GetTitulo()}%';";
            using (Repository repository = new Repository())
            {
                repository.executeQuery(sql);
            }
        }
        public void Deletar_livro()
        {
            Livroteste deletar = new Livroteste();
            using (Repository repository = new Repository())
            {
                repository.executeQuery("SELECT * FROM Livroteste");

            }

            int search_isbn = int.Parse(Console.ReadLine());
            string sql = $"delete from Livroteste where ISBN = {search_isbn} ";
            using (Repository repository = new Repository())
            {
                repository.executeScript(sql);
            }
        }
        public void Atualizar_livro()
        {
            Livroteste atualizar = new Livroteste();
            Console.WriteLine("ISBN: ");
            atualizar.SetISBN(Console.ReadLine().ToString());

            Console.WriteLine("Titulo: ");
            atualizar.SetTitulo(Console.ReadLine().ToString());

            Console.WriteLine("Autor: ");
            atualizar.SetAutor(Console.ReadLine().ToString());

            Console.WriteLine("Ano: ");
            atualizar.SetAno(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Genero: ");
            atualizar.SetGenero(Console.ReadLine().ToString());

            Console.WriteLine("Edicao: ");
            atualizar.SetEdicao(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Quantidade: ");
            atualizar.SetQuantidade(Convert.ToInt32(Console.ReadLine()));

            string sql = $"UPDATE Livroteste SET titulo = '{atualizar.GetTitulo()}', autor = '{atualizar.GetAutor()}', ano = {atualizar.GetAno()}, genero = '{atualizar.GetGenero()}', edicao = {atualizar.GetEdicao()}, quantidade = {atualizar.GetQuantidade()} WHERE isbn =  '{atualizar.GetISBN()}' ";

            using (Repository repository = new Repository())
            {
                repository.executeScript(sql);
            }
        }

        public override void executarAcao(string op)
        {
            switch (op)
            {
                case "1":
                    {
                        //AnsiConsole.Clear();

                        Criar_livro();
                        break;
                    }
                case "2":
                    {
                        //AnsiConsole.Clear();

                        Atualizar_livro();
                        break;
                    }
                case "3":
                    {
                        //AnsiConsole.Clear();

                        Deletar_livro();
                        break;
                    }
                case "4":
                    {
                        //AnsiConsole.Clear();

                        Pesquisar_livro();
                        break;
                    }
            }
        }
    }
}