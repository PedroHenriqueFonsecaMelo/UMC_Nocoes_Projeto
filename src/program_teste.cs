using System;
using System.Data;
using System.Reflection;
using System.Text;
using MySql.Data.MySqlClient;
using main.src.dbcon;
using main.src.entities;

class program_teste
{
    public static void Main(string[] args)
    {
       //CreateTableX(typeof(Livroteste));
       //CreateTableX(typeof(AlunoTeste));
        string opcao = "";
        do
        {
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

            opcao = Console.ReadLine();
            if (opcao == "0")
                break;

            Console.Clear();

            switch (opcao)
            {
                case "1":
                    {
                        
                        Console.WriteLine("+------------------------- Aluno  --------------+    ");
                        Console.WriteLine("¦                                               ¦    ");
                        Console.WriteLine("        Forneca os dados do Aluno:              ¦    ");
                        Console.WriteLine("¦                                               ¦    ");
                        Console.WriteLine("+-----------------------------------------------+    ");

                        AlunoTeste aluno = new AlunoTeste(true);

                        string sql = $"INSERT INTO AlunoTeste (Rgm, Nome, Senha, Gen, Email) VALUES ('{aluno.Rgm}', '{aluno.Nome}', '{aluno.Senha}', '{aluno.Gen}', '{aluno.Email}');";
                        Console.WriteLine(sql);
                        Connectiondb.executeScript(sql);
                        break;
                    }
                case "2":{

                    
                    Console.WriteLine("+------------------------- Aluno  --------------+    ");
                    Console.WriteLine("¦                                               ¦    ");
                    Console.WriteLine("    Forneca os dados atualizados do Aluno:      ¦    ");
                    Console.WriteLine("¦                                               ¦    ");
                    Console.WriteLine("+-----------------------------------------------+    ");

                    AlunoTeste aluno = new AlunoTeste(true);

                    string sql = $"UPDATE AlunoTeste SET Nome = '{aluno.Nome}', senha = '{aluno.Senha}', email = '{aluno.Email}', gen = '{aluno.Gen}' WHERE rgm =  '{aluno.Rgm}' ";
                    Console.WriteLine(sql);
                    Connectiondb.executeScript(sql);

                    break;
                }
                case "3":{
                    
                    Console.WriteLine("+------------------------- ALUNO  --------------+    ");
                    Console.WriteLine("Â¦                                              ¦    ");
                    Console.WriteLine("    Forneca O RGM do Aluno:                     ¦    ");
                    Console.WriteLine("Â¦                                              ¦    ");
                    Console.WriteLine("+-----------------------------------------------+    ");

                     Connectiondb.executeScript("SELECT * FROM AlunoTeste");
                    
                    int search_isbn = int.Parse(Console.ReadLine());
                    string sql = $"delete from AlunoTeste where rgm = {search_isbn} ";
                    Console.WriteLine(sql);
                    Connectiondb.executeScript(sql);

                    break;
                }
                case "4":{

                    Console.WriteLine("+------------------------- ALUNO  --------------+    ");
                    Console.WriteLine("Â¦                                              ¦    ");
                    Console.WriteLine("    Forneca O RGM do Aluno:                     ¦    ");
                    Console.WriteLine("Â¦                                              ¦    ");
                    Console.WriteLine("+-----------------------------------------------+    ");

                    Console.WriteLine("RGM: ");
                    int rgm = Convert.ToInt32(Console.ReadLine().ToString());


                    string sql = "";
                    sql = $"SELECT * FROM AlunoTeste WHERE rgm = {rgm};";
                     Connectiondb.executeQuery(sql);
                    
                    break;
                }
                case "5":
                    {
                        Livroteste l = new Livroteste();
                        Console.WriteLine("+------------------------- LIVRO  --------------+    ");
                        Console.WriteLine("¦                                               ¦    ");
                        Console.WriteLine("        Forneca os dados do Livro:              ¦    ");
                        Console.WriteLine("¦                                               ¦    ");
                        Console.WriteLine("+-----------------------------------------------+    ");


                        Console.WriteLine("ISBN: ");
                        l.SetISBN(Console.ReadLine().ToString());

                        Console.WriteLine("Titulo: ");
                        l.SetTitulo(Console.ReadLine().ToString());

                        Console.WriteLine("Autor: ");
                        l.SetAutor(Console.ReadLine().ToString());

                        Console.WriteLine("Ano: ");
                        l.SetAno(Convert.ToInt32(Console.ReadLine()));

                        Console.WriteLine("Genero: ");
                        l.SetGenero(Console.ReadLine().ToString());

                        Console.WriteLine("Edicao: ");
                        l.SetEdicao(Convert.ToInt32(Console.ReadLine()));

                        Console.WriteLine("Quantidade: ");
                        l.SetQuantidade(Convert.ToInt32(Console.ReadLine()));

                        string sql = $"INSERT INTO Livroteste (isbn, titulo, autor, ano, genero, edicao, quantidade) VALUES ('{l.GetISBN()}', '{l.GetTitulo()}', '{l.GetAutor()}', {l.GetAno()}, '{l.GetGenero()}', {l.GetEdicao()}, {l.GetQuantidade()});";

                        Connectiondb.executeScript(sql);

                        break;

                    }
                case "6":
                    {
                        Livroteste l = new Livroteste();
                        Console.WriteLine("+------------------------- LIVRO  --------------+    ");
                        Console.WriteLine("¦                                               ¦    ");
                        Console.WriteLine("    Forneca os dados atualizados do Livro:      ¦    ");
                        Console.WriteLine("¦                                               ¦    ");
                        Console.WriteLine("+-----------------------------------------------+    ");
                        

                        Console.WriteLine("ISBN: ");
                        l.SetISBN(Console.ReadLine().ToString());

                        Console.WriteLine("Titulo: ");
                        l.SetTitulo(Console.ReadLine().ToString());

                        Console.WriteLine("Autor: ");
                        l.SetAutor(Console.ReadLine().ToString());

                        Console.WriteLine("Ano: ");
                        l.SetAno(Convert.ToInt32(Console.ReadLine()));

                        Console.WriteLine("Genero: ");
                        l.SetGenero(Console.ReadLine().ToString());

                        Console.WriteLine("Edicao: ");
                        l.SetEdicao(Convert.ToInt32(Console.ReadLine()));

                        Console.WriteLine("Quantidade: ");
                        l.SetQuantidade(Convert.ToInt32(Console.ReadLine()));

                        string sql = $"UPDATE Livroteste SET titulo = '{l.GetTitulo()}', autor = '{l.GetAutor()}', ano = {l.GetAno()}, genero = '{l.GetGenero()}', edicao = {l.GetEdicao()}, quantidade = {l.GetQuantidade()} WHERE isbn =  '{l.GetISBN()}' ";

                         Connectiondb.executeScript(sql);

                        break;
                    }
                case "7":{
                        Livroteste l = new Livroteste();

                        Console.WriteLine("+------------------------- LIVRO  --------------+    ");
                        Console.WriteLine("Â¦                                               Â¦    ");
                        Console.WriteLine("    Forneca O ISBN do Livro:      Â¦    ");
                        Console.WriteLine("Â¦                                               Â¦    ");
                        Console.WriteLine("+-----------------------------------------------+    ");

                        Connectiondb.executeQuery("SELECT * FROM Livroteste");

                        int search_isbn = int.Parse(Console.ReadLine());
                        string sql = $"delete from Livroteste where ISBN = {search_isbn} ";
                        Connectiondb.executeScript(sql);
                        break;
                    }
                case "8":
                    {

                        Livroteste l = new Livroteste();
                        Console.WriteLine("+------------------------- LIVRO  --------------+    ");
                        Console.WriteLine("Â¦                                               Â¦    ");
                        Console.WriteLine("    Forneca O Titulo do Livro:      Â¦    ");
                        Console.WriteLine("Â¦                                               Â¦    ");
                        Console.WriteLine("+-----------------------------------------------+    ");

                        Console.WriteLine("Titulo: ");
                        l.SetTitulo(Console.ReadLine().ToString());


                        string sql = "";
                        sql = $"SELECT * FROM Livroteste WHERE titulo LIKE '%{l.GetTitulo()}%';";
                        Connectiondb.executeQuery(sql);
                        break;

                    }
                default:
                    {
                        Console.WriteLine("Digitou uma opção invalida!!");
                        break;
                    }
            }

        } while (opcao != "0");


    }



    public static void CreateTableX(Type classe) {
        Object obj = Activator.CreateInstance(classe);

        FieldInfo[] Fields = classe.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        StringBuilder table = new StringBuilder();
        String name, tipo;
        int i = 0;
        table.Append("create table " + obj.GetType().Name + " (");
        
        
        foreach (FieldInfo f in Fields) {
            
            i++;
            name = f.Name;
            tipo = f.FieldType.Name;

            if (i <= Fields.Length - 1) {
                table.Append(extracted(name, tipo) + " , ");
            } else {
                table.Append(extracted(name, tipo) + ");");
            }
        }

        Console.WriteLine(table.ToString());
        Connectiondb.executeScript(table.ToString());
        
    }

    private static String extracted(String name, String tipo) {
        switch (tipo) {
            case "String":
                return " " + name + " VARCHAR(100) ";
            case "Int32":
                return " " + name + " INT ";
            case "Date":
                return " " + name + " DATE ";
            case "float":
                return " " + name + " NUMERIC(20, 2) ";
            case "ID":
                return (" " + name + " INT PRIMARY KEY AUTO_INCREMENT ");
            default:
                return "";
        }
    }
}