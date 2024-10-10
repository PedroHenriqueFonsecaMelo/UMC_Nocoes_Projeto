using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using main.src.dbcon;
using main.src.entities;
using Spectre.Console;
using UMC_Nocoes_Projeto.src.repositories;
using UMC_Nocoes_Projeto.src.templates;

namespace UMC_Nocoes_Projeto.src.DTOs
{

    public class SecretariaDTO : TemplateMethod
    {
        Table table = new Table();
        Panel panel;
        AlunoTeste aluno;
        Repository repo;

        public void CriarAluno()
        {
            Markup content_aluno = new Markup("Forneca os dados do Aluno para Cadastro:");
            panel = new Panel(table);

            table.AddColumn("");
            table.AddRow(new Panel(content_aluno).Border(BoxBorder.Ascii)).Centered();


            table.HideHeaders();
            table.Border(TableBorder.None);
            panel.Header = new PanelHeader("MENU DE OPÇÕES");
            panel.Border = BoxBorder.Double;
            AnsiConsole.Write(panel);

            /*
            Console.WriteLine("+------------------------- Aluno  --------------+    ");
            Console.WriteLine("¦                                               ¦    ");
            Console.WriteLine("        Forneca os dados do Aluno:              ¦    ");
            Console.WriteLine("¦                                               ¦    ");
            Console.WriteLine("+-----------------------------------------------+    ");
            */

            aluno = new AlunoTeste(true);
            string sql = $"INSERT INTO AlunoTeste (Rgm, Nome, Senha, Gen, Email) VALUES ('{aluno.Rgm}', '{aluno.Nome}', '{aluno.Senha}', '{aluno.Gen}', '{aluno.Email}');";
            Console.WriteLine(sql);
            using (Repository repository = new Repository())
            {
                repository.executeScript(sql);
            }
        }

        public void UpdateAluno()
        {
            Markup content_aluno = new Markup("Forneca os dados atualizados do Aluno:");
            panel = new Panel(table);

            table.AddColumn("");
            table.AddRow(new Panel(content_aluno).Border(BoxBorder.Ascii)).Centered();


            table.HideHeaders();
            table.Border(TableBorder.None);
            panel.Header = new PanelHeader("MENU DE OPÇÕES");
            panel.Border = BoxBorder.Double;
            AnsiConsole.Write(panel);

            /*
            Console.WriteLine("+------------------------- Aluno  --------------+    ");
            Console.WriteLine("¦                                               ¦    ");
            Console.WriteLine("    Forneca os dados atualizados do Aluno:      ¦    ");
            Console.WriteLine("¦                                               ¦    ");
            Console.WriteLine("+-----------------------------------------------+    ");
            */


            aluno = new AlunoTeste(true);
            string sql = $"UPDATE AlunoTeste SET Nome = '{aluno.Nome}', senha = '{aluno.Senha}', email = '{aluno.Email}', gen = '{aluno.Gen}' WHERE rgm =  '{aluno.Rgm}' ";
            Console.WriteLine(sql);
            using (Repository repository = new Repository())
            {
                repository.executeScript(sql);
            }
        }
        public void ConsultarAluno()
        {
            Markup content_aluno = new Markup("Forneca O RGM do Aluno para consultar:");
            panel = new Panel(table);

            table.AddColumn("");
            table.AddRow(new Panel(content_aluno).Border(BoxBorder.Ascii)).Centered();


            table.HideHeaders();
            table.Border(TableBorder.None);
            panel.Header = new PanelHeader("MENU DE OPÇÕES");
            panel.Border = BoxBorder.Double;
            AnsiConsole.Write(panel);

            /*
            Console.WriteLine("+------------------------- ALUNO  --------------+    ");
            Console.WriteLine("Â¦                                              ¦    ");
            Console.WriteLine("    Forneca O RGM do Aluno:                     ¦    ");
            Console.WriteLine("Â¦                                              ¦    ");
            Console.WriteLine("+-----------------------------------------------+    ");
            */

            Console.WriteLine("RGM: ");
            int rgm = Convert.ToInt32(Console.ReadLine().ToString());
            string sql = $"SELECT * FROM AlunoTeste WHERE rgm = {rgm}";
            //WHERE rgm = {rgm};
            using (Repository repository = new Repository())
            {
                repository.executeQuery(sql);
            }
        }
        public void DeleteAluno()
        {
            Markup content_aluno = new Markup("Forneca O RGM do Aluno para deletar:");
            panel = new Panel(table);

            table.AddColumn("");
            table.AddRow(new Panel(content_aluno).Border(BoxBorder.Ascii)).Centered();


            table.HideHeaders();
            table.Border(TableBorder.None);
            panel.Header = new PanelHeader("MENU DE OPÇÕES");
            panel.Border = BoxBorder.Double;
            AnsiConsole.Write(panel);

            /*
            Console.WriteLine("+------------------------- ALUNO  --------------+    ");
            Console.WriteLine("Â¦                                              ¦    ");
            Console.WriteLine("    Forneca O RGM do Aluno:                     ¦    ");
            Console.WriteLine("Â¦                                              ¦    ");
            Console.WriteLine("+-----------------------------------------------+    ");
            */

            using (Repository repository = new Repository())
            {
                repository.executeScript("SELECT * FROM AlunoTeste");
            }

            int search_rgm = int.Parse(Console.ReadLine());
            string sql = $"delete from AlunoTeste where rgm = {search_rgm} ";
            Console.WriteLine(sql);
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
                        CriarAluno();
                        break;
                    }
                case "2":
                    {
                        UpdateAluno();
                        break;
                    }
                case "3":
                    {
                        DeleteAluno();
                        break;
                    }
                case "4":
                    {
                        ConsultarAluno();
                        break;
                    }
            }
        }
    }
}