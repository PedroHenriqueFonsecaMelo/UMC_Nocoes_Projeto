using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using main.src.dbcon;
using main.src.entities;

namespace UMC_Nocoes_Projeto.src.DTOs
{
    public class BibliotecaDTO
    {
        public static void Criar_livro(){
            Livroteste livro = new Livroteste();
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

            Connectiondb.executeScript(sql);

        }
        public static void Pesquisar_livro(){
            Livroteste pesquisa = new Livroteste();
            Console.WriteLine("Titulo: ");
             pesquisa.SetTitulo(Console.ReadLine().ToString());
             

            string sql = "";
            sql = $"SELECT * FROM Livroteste WHERE titulo LIKE '%{pesquisa.GetTitulo()}%';";
            Connectiondb.executeQuery(sql);
        }
        public static void Deletar_livro(){
            Livroteste deletar = new Livroteste();
            Connectiondb.executeQuery("SELECT * FROM Livroteste");

            int search_isbn = int.Parse(Console.ReadLine());
            string sql = $"delete from Livroteste where ISBN = {search_isbn} ";
            Connectiondb.executeScript(sql);
        }
        public static void Atualizar_livro(){
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

            Connectiondb.executeScript(sql);
        }
    }
}