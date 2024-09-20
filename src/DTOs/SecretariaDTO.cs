using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using main.src.dbcon;
using main.src.entities;

namespace UMC_Nocoes_Projeto.src.DTOs
{
    
    public class SecretariaDTO
    {
        public static void CriarAluno(){
            AlunoTeste aluno = new AlunoTeste(true);
            string sql = $"INSERT INTO AlunoTeste (Rgm, Nome, Senha, Gen, Email) VALUES ('{aluno.Rgm}', '{aluno.Nome}', '{aluno.Senha}', '{aluno.Gen}', '{aluno.Email}');";
            Console.WriteLine(sql);
            Connectiondb.executeScript(sql);
        }

        public static void UpdateAluno(){
            AlunoTeste aluno = new AlunoTeste(true);
            string sql = $"UPDATE AlunoTeste SET Nome = '{aluno.Nome}', senha = '{aluno.Senha}', email = '{aluno.Email}', gen = '{aluno.Gen}' WHERE rgm =  '{aluno.Rgm}' ";
            Console.WriteLine(sql);
            Connectiondb.executeScript(sql);
        }
        public static void ConsultarAluno(){
            Console.WriteLine("RGM: ");
            int rgm = Convert.ToInt32(Console.ReadLine().ToString());
            string sql = $"SELECT * FROM AlunoTeste WHERE rgm = {rgm}";
            //WHERE rgm = {rgm};
            Connectiondb.executeQuery(sql);
        }
        public static void DeleteAluno(){
            Connectiondb.executeScript("SELECT * FROM AlunoTeste");
            int search_rgm = int.Parse(Console.ReadLine());
            string sql = $"delete from AlunoTeste where rgm = {search_rgm} ";
            Console.WriteLine(sql);
            Connectiondb.executeScript(sql);
        }
        
        
    }
}