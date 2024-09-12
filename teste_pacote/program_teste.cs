using System;
using System.Data;
using System.Reflection;
using System.Text;
using MySql.Data.MySqlClient;
using Npgsql;



public class Livro_teste
{
    private string isbn;
    private string titulo;
    private string autor;
    private int ano;
    private string genero;
    private int edicao;
    private int quantidade;

    public Livro_teste(string _titulo, string _autor, int _ano, string _genero, int _edicao, int _quantidade, string _isbn)
    {
        isbn = _isbn;
        titulo = _titulo;
        autor = _autor;
        ano = _ano;
        genero = _genero;
        edicao = _edicao;
        quantidade = _quantidade;
    }

    public Livro_teste()
    {
        titulo = "";
        autor = "";
        ano = 0;
        genero = "";
        edicao = 0;
        quantidade = 0;
        isbn = "";
    }

    public string GetISBN()
    {
        return isbn;
    }

    public void SetISBN(string valor)
    {
        isbn = valor;
    }

    public string GetTitulo()
    {
        return titulo;
    }

    public void SetTitulo(string valor)
    {
        titulo = valor;
    }

    public string GetAutor()
    {
        return autor;
    }

    public void SetAutor(string valor)
    {
        autor = valor;
    }

    public int GetAno()
    {
        return ano;
    }

    public void SetAno(int valor)
    {
        ano = valor;
    }

    public string GetGenero()
    {
        return genero;
    }

    public void SetGenero(string valor)
    {
        genero = valor;
    }

    public int GetEdicao()
    {
        return edicao;
    }

    public void SetEdicao(int valor)
    {
        edicao = valor;
    }

    public int GetQuantidade()
    {
        return quantidade;
    }

    public void SetQuantidade(int valor)
    {
        quantidade = valor;
    }
}

public class AlunoTeste
{

    private int rgm;
    private String senha;
    private String nome;
    private String gen;
    private String email;

    public AlunoTeste()
    {
        rgm = 0;
        senha = null; 
        nome = null;
        gen = null;
        email = null;
    }

    public AlunoTeste(int rgm, string senha, string nome, string gen, string email)
    {
        this.rgm = rgm;
        this.senha = senha;
        this.nome = nome;
        this.gen = gen;
        this.email = email;
    }

    public int Rgm { get => rgm; set => rgm = value; }
    public string Senha { get => senha; set => senha = value; }
    public string Nome { get => nome; set => nome = value; }
    public string Gen { get => gen; set => gen = value; }
    public string Email { get => email; set => email = value; }
}
class program_teste
{
    public static void executeScript(string sql)
    {
        NpgsqlConnection con;
        con = new NpgsqlConnection("Persist Security Info=False;" +
        "server=127.0.0.1;username=postgres;");
        try
        {
            con.Open();
            //Console.WriteLine($"MySQL version : {con.ServerVersion}");
        }
        catch (System.Exception e)
        {
            Console.WriteLine (e.Message.ToString());
            //MessageBox.Show(e.Message.ToString());
        }

        //verificva se a conexão esta aberta
        if (con.State == ConnectionState.Open)
        {
            Console.WriteLine("connection Open!");
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }
    }

    public static void executeQuery(string sql)
    {
        try
        {
            NpgsqlConnection con;
            con = new NpgsqlConnection("Persist Security Info=False;server=127.0.0.1;username=postgres;");
            con.Open();
            //verificva se a conexão esta aberta
            if (con.State == ConnectionState.Open)
            {
                //Console.WriteLine("connection Open!");
                using var cmd = new NpgsqlCommand(sql, con);
                using NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        Console.Write(rdr[i].ToString() + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
        catch (System.Exception e)
        {
            string msg = "ERROR: When Tried to execute [" + sql + "]";
            msg += " | execption Error: " + e.Message.ToString();
            Console.WriteLine(msg);
        }
    }

    public static void Main(string[] args)
    {
        Livro_teste livro_ = new Livro_teste();
        CreateTableX(typeof(Livro_teste));
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
                        AlunoTeste aluno = new AlunoTeste();
                        Console.WriteLine("+------------------------- Aluno  --------------+    ");
                        Console.WriteLine("¦                                               ¦    ");
                        Console.WriteLine("        Forneca os dados do Aluno:              ¦    ");
                        Console.WriteLine("¦                                               ¦    ");
                        Console.WriteLine("+-----------------------------------------------+    ");

                        AlunoMod(aluno);

                        string sql = $"INSERT INTO AlunoTeste (Rgm, Nome, Senha, Gen, Email) VALUES ('{aluno.Rgm}', '{aluno.Nome}', '{aluno.Senha}', '{aluno.Gen}', '{aluno.Email}');";
                        Console.WriteLine(sql);
                        //executeScript(sql);
                        break;
                    }
                case "2":{
                    AlunoTeste aluno = new AlunoTeste();
                    Console.WriteLine("+------------------------- Aluno  --------------+    ");
                    Console.WriteLine("¦                                               ¦    ");
                    Console.WriteLine("    Forneca os dados atualizados do Aluno:      ¦    ");
                    Console.WriteLine("¦                                               ¦    ");
                    Console.WriteLine("+-----------------------------------------------+    ");
                    AlunoMod(aluno);

                    string sql = $"UPDATE AlunoTeste SET Nome = '{aluno.Nome}', senha = '{aluno.Senha}', email = {aluno.Email}, gen = '{aluno.Gen}' WHERE rgm =  '{aluno.Rgm}' ";
                    Console.WriteLine(sql);
                    //executeScript(sql);

                    break;
                }
                case "3":{
                    AlunoTeste aluno = new AlunoTeste();
                    Console.WriteLine("+------------------------- LIVRO  --------------+    ");
                    Console.WriteLine("Â¦                                              ¦    ");
                    Console.WriteLine("    Forneca O RGM do Aluno:                     ¦    ");
                    Console.WriteLine("Â¦                                              ¦    ");
                    Console.WriteLine("+-----------------------------------------------+    ");

                    //executeQuery("SELECT * FROM AlunoTeste");

                    int search_isbn = int.Parse(Console.ReadLine());
                    string sql = $"delete from Livro where rgm = '{search_isbn} ";
                    Console.WriteLine(sql);
                    //executeScript(sql);

                    break;
                }
                case "4":{break;}
                case "5":
                    {
                        Livro_teste l = new Livro_teste();
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

                        string sql = $"INSERT INTO Livro (isbn, titulo, autor, ano, genero, edicao, quantidade) VALUES ('{l.GetISBN()}', '{l.GetTitulo()}', '{l.GetAutor()}', {l.GetAno()}, '{l.GetGenero()}', {l.GetEdicao()}, {l.GetQuantidade()});";

                        executeScript(sql);

                        break;

                    }
                case "6":
                    {
                        Livro_teste l = new Livro_teste();
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

                        string sql = $"UPDATE Livro SET titulo = '{l.GetTitulo()}', autor = '{l.GetAutor()}', ano = {l.GetAno()}, genero = '{l.GetGenero()}', edicao = {l.GetEdicao()}, quantidade = {l.GetQuantidade()} WHERE isbn =  '{l.GetISBN()}' ";

                        executeScript(sql);

                        break;
                    }
                case "7":
                    {
                        Livro_teste l = new Livro_teste();

                        Console.WriteLine("+------------------------- LIVRO  --------------+    ");
                        Console.WriteLine("Â¦                                               Â¦    ");
                        Console.WriteLine("    Forneca O ISBN do Livro:      Â¦    ");
                        Console.WriteLine("Â¦                                               Â¦    ");
                        Console.WriteLine("+-----------------------------------------------+    ");

                        executeQuery("SELECT * FROM Livro");

                        int search_isbn = int.Parse(Console.ReadLine());
                        string sql = $"delete from Livro where ISBN = '{search_isbn} ";
                        executeScript(sql);
                        break;
                    }
                case "8":
                    {

                        Livro_teste l = new Livro_teste();
                        Console.WriteLine("+------------------------- LIVRO  --------------+    ");
                        Console.WriteLine("Â¦                                               Â¦    ");
                        Console.WriteLine("    Forneca O Titulo do Livro:      Â¦    ");
                        Console.WriteLine("Â¦                                               Â¦    ");
                        Console.WriteLine("+-----------------------------------------------+    ");

                        Console.WriteLine("Titulo: ");
                        l.SetTitulo(Console.ReadLine().ToString());


                        string sql = "";
                        sql = $"SELECT * FROM Livro WHERE titulo LIKE '%{l.GetTitulo()}%';";
                        executeQuery(sql);
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

    private static void AlunoMod(AlunoTeste aluno)
    {
        FieldInfo[] Fields = typeof(AlunoTeste).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (var item in Fields)
        {

            Console.WriteLine($"{item.Name}:");

            if (item.FieldType.Name == "Int32")
            {

                int value = Convert.ToInt32(Console.ReadLine());
                aluno.GetType().GetField(item.Name, BindingFlags.Instance | BindingFlags.NonPublic).SetValue(aluno, value);

            }
            else
            {

                String value = Console.ReadLine();
                aluno.GetType().GetField(item.Name, BindingFlags.Instance | BindingFlags.NonPublic).SetValue(aluno, value);
            }
        }
    }

    public static void CreateTableX(Type classe) {
        Object obj = Activator.CreateInstance(classe);

        FieldInfo[] Fields = classe.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        StringBuilder table = new StringBuilder();
        String name, tipo;
        int i = 0;
        table.Append("create table " + obj.GetType().FullName + " ("); // + "(" + "id" + x.getSimpleName() + " INT PRIMARY
                                                                  // KEY
        // AUTO_INCREMENT ,");
        
        
        foreach (FieldInfo f in Fields) {
            // f.setAccessible(true);
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