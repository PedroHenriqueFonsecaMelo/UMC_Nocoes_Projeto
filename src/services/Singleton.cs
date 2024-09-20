using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Security;
using Spectre.Console;

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

        public string ShowMenu(){

            Panel menu = new("MENU DE OPÇÕES");
            menu.Border = BoxBorder.Ascii;
            
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
            Console.WriteLine(" ");
            Console.Write("DIGITE UMA OPÇÃO : ");

            string opcao = Console.ReadLine();
            return opcao;
        }

        public void ShowAnsi(){
            var content = new Markup(
            "[underline]I[/] heard [underline on blue]you[/] like panels\n\n\n\n" +
            "So I put a panel in a panel").Centered();

        AnsiConsole.Write(
            new Panel(
                new Panel(content)
                    .Border(BoxBorder.Rounded)));

        // Left adjusted panel with text
        AnsiConsole.Write(
            new Panel(new Text("Left adjusted\nLeft").LeftJustified())
                .Expand()
                .SquareBorder()
                .Header("[red]Left[/]"));

        // Centered ASCII panel with text
        AnsiConsole.Write(
            new Panel(new Text("Centered\nCenter").Centered())
                .Expand()
                .AsciiBorder()
                .Header("[green]Center[/]")
                .HeaderAlignment(Justify.Center));

        // Right adjusted, rounded panel with text
        AnsiConsole.Write(
            new Panel(new Text("Right adjusted\nRight").RightJustified())
                .Expand()
                .RoundedBorder()
                .Header("[blue]Right[/]")
                .HeaderAlignment(Justify.Right));
        }
    }
}