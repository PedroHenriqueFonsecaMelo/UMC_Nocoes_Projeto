using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Security;
using Spectre.Console;
using UMC_Nocoes_Projeto.src.DTOs;
using UMC_Nocoes_Projeto.src.templates;

namespace UMC_Nocoes_Projeto.src.services
{
    public class Singleton
    {
        private Singleton() { }
        private static Singleton _instance;
        public static Singleton getInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        public string ShowMenu(string key, TemplateMethod templateMethod)
        {

            Markup content_aluno = new Markup("1 INCLUIR   - ALUNO\n2 ATUALIZAR - ALUNO\n3 REMOVER   - ALUNO\n4 CONSULTAR - ALUNO").Centered();
            Markup content_livro = new Markup(
            "1 INCLUIR   - LIVRO\n2 ATUALIZAR - LIVRO\n3 REMOVER   - LIVRO\n4 CONSULTAR - LIVRO").Centered();
            Markup content_sair = new Markup("[bold red] 0 SAIR [/]").Centered();
            Markup content_menu = new Markup("1 Secretaria\n2 Biblioteca").Centered();

            Table table = new Table();
            Panel panel = new Panel(table);

            switch (key)
            {
                case "ConsultarAluno":
                    {
                        AnsiConsole.Clear(); ;

                        /*
                        Console.WriteLine("║            1 INCLUIR   - ALUNO                ║    ");
                        Console.WriteLine("║            2 ATUALIZAR - ALUNO                ║    ");
                        Console.WriteLine("║            3 REMOVER   - ALUNO                ║    ");
                        Console.WriteLine("║            4 CONSULTAR - ALUNO                ║    ");
                        */
                        table.AddColumn("");
                        table.AddRow(new Panel(content_aluno).Border(BoxBorder.Ascii)).Centered();


                        table.HideHeaders();
                        table.Border(TableBorder.None);
                        panel.Header = new PanelHeader("MENU DE OPÇÕES");
                        panel.Border = BoxBorder.Double;
                        AnsiConsole.Write(panel);

                        Console.WriteLine(" ");
                        Console.Write("DIGITE UMA OPÇÃO : ");
                        string op = Console.ReadLine();

                        templateMethod.run(op);
                        //string opcao_aluno = Console.ReadLine();

                        //OpcoesAluno(opcao_aluno);
                        return op;
                    }
                case "ConsultarLivro":
                    {
                        AnsiConsole.Clear(); ;

                        /*
                        Console.WriteLine("║            1 INCLUIR   - LIVRO                ║    ");
                        Console.WriteLine("║            2 ATUALIZAR - LIVRO                ║    ");
                        Console.WriteLine("║            3 REMOVER   - LIVRO                ║    ");
                        Console.WriteLine("║            4 CONSULTAR - LIVRO                ║    ");
                        */
                        table.AddColumn("");
                        table.AddRow(new Panel(content_livro).Border(BoxBorder.Ascii)).Centered();


                        table.HideHeaders();
                        table.Border(TableBorder.None);
                        panel.Header = new PanelHeader("MENU DE OPÇÕES");
                        panel.Border = BoxBorder.Double;
                        AnsiConsole.Write(panel);


                        Console.WriteLine(" ");
                        Console.WriteLine("DIGITE UMA OPÇÃO : ");
                        string op = Console.ReadLine();

                        templateMethod.run(op);
                        //string opcao_livro = Console.ReadLine();
                        //OpcoesLivro(opcao_livro);

                        return op;
                    }
                case "Menu":
                default:
                    {
                        AnsiConsole.Clear(); ;

                        /*
                        Console.WriteLine("║            1 Secretaria                ║    ");
                        Console.WriteLine("║            2 Biblioteca                ║    ");
                        */




                        table.AddColumn("");
                        table.AddRow(new Panel(content_menu).Border(BoxBorder.Ascii).Expand()).Centered();

                        table.HideHeaders();
                        table.Border(TableBorder.None);
                        panel.Header = new PanelHeader("MENU DE OPÇÕES");
                        panel.Border = BoxBorder.Double;
                        AnsiConsole.Write(panel);

                        Console.WriteLine(" ");
                        Console.Write("DIGITE UMA OPÇÃO : ");
                        return Console.ReadLine();
                    }

            }
            /*

            Console.WriteLine("╔════════════════ MENU DE OPÇÕES ═══════════════╗    ");
            Console.WriteLine("║                                               ║    ");
            Console.WriteLine("║            1 INCLUIR   - ALUNO                ║    ");
            Console.WriteLine("║            2 ATUALIZAR - ALUNO                ║    ");
            Console.WriteLine("║            3 REMOVER   - ALUNO                ║    ");
            Console.WriteLine("║            4 CONSULTAR - ALUNO                ║    ");
            Console.WriteLine("║═══════════════════════════════════════════════║    ");
            Console.WriteLine("║            5 INCLUIR   - LIVRO                ║    ");
            Console.WriteLine("║            6 ATUALIZAR - LIVRO                ║    ");
            Console.WriteLine("║            7 REMOVER   - LIVRO                ║    ");
            Console.WriteLine("║            8 CONSULTAR - LIVRO                ║    ");
            Console.WriteLine("║═══════════════════════════════════════════════║    ");
            Console.WriteLine("║          0 SAIR                               ║    ");
            Console.WriteLine("╚═══════════════════════════════════════════════╝    ");
            */


            //string opcao = Console.ReadLine();
        }
    }
}