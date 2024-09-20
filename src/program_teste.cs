using System;
using System.Data;
using System.Reflection;
using System.Text;
using MySql.Data.MySqlClient;
using main.src.dbcon;
using main.src.entities;
using UMC_Nocoes_Projeto.src.services;
using UMC_Nocoes_Projeto.src.DTOs;

class program_teste
{
    public static void Main(string[] args)
    {
        //Connectiondb.CreateTableX(typeof(Livroteste));
        //Connectiondb.CreateTableX(typeof(AlunoTeste));
        
        string opcao = "";
        Singleton.getInstance().ShowAnsi();
        do
        {
            opcao = Singleton.getInstance().ShowMenu();

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
                        
                        SecretariaDTO.CriarAluno();
                        break;
                    }
                case "2":
                    {


                        Console.WriteLine("+------------------------- Aluno  --------------+    ");
                        Console.WriteLine("¦                                               ¦    ");
                        Console.WriteLine("    Forneca os dados atualizados do Aluno:      ¦    ");
                        Console.WriteLine("¦                                               ¦    ");
                        Console.WriteLine("+-----------------------------------------------+    ");
                        SecretariaDTO.UpdateAluno();
                        break;
                    }
                case "3":
                    {

                        Console.WriteLine("+------------------------- ALUNO  --------------+    ");
                        Console.WriteLine("Â¦                                              ¦    ");
                        Console.WriteLine("    Forneca O RGM do Aluno:                     ¦    ");
                        Console.WriteLine("Â¦                                              ¦    ");
                        Console.WriteLine("+-----------------------------------------------+    ");
                        SecretariaDTO.DeleteAluno();
                        break;
                    }
                case "4":
                    {

                        Console.WriteLine("+------------------------- ALUNO  --------------+    ");
                        Console.WriteLine("Â¦                                              ¦    ");
                        Console.WriteLine("    Forneca O RGM do Aluno:                     ¦    ");
                        Console.WriteLine("Â¦                                              ¦    ");
                        Console.WriteLine("+-----------------------------------------------+    ");
                        
                        SecretariaDTO.ConsultarAluno();
                        break;
                    }
                case "5":
                    {

                        Console.WriteLine("+------------------------- LIVRO  --------------+    ");
                        Console.WriteLine("¦                                               ¦    ");
                        Console.WriteLine("        Forneca os dados do Livro:              ¦    ");
                        Console.WriteLine("¦                                               ¦    ");
                        Console.WriteLine("+-----------------------------------------------+    ");


                        BibliotecaDTO.Criar_livro();

                        break;

                    }
                case "6":
                    {

                        Console.WriteLine("+------------------------- LIVRO  --------------+    ");
                        Console.WriteLine("¦                                               ¦    ");
                        Console.WriteLine("    Forneca os dados atualizados do Livro:      ¦    ");
                        Console.WriteLine("¦                                               ¦    ");
                        Console.WriteLine("+-----------------------------------------------+    ");

                        BibliotecaDTO.Atualizar_livro();

                        break;
                    }
                case "7":
                    {

                        Console.WriteLine("+------------------------- LIVRO  --------------+    ");
                        Console.WriteLine("Â¦                                               Â¦    ");
                        Console.WriteLine("    Forneca O ISBN do Livro:      Â¦    ");
                        Console.WriteLine("Â¦                                               Â¦    ");
                        Console.WriteLine("+-----------------------------------------------+    ");

                        BibliotecaDTO.Deletar_livro();
                        break;
                    }
                case "8":
                    {


                        Console.WriteLine("+------------------------- LIVRO  --------------+    ");
                        Console.WriteLine("Â¦                                               Â¦    ");
                        Console.WriteLine("    Forneca O Titulo do Livro:      Â¦    ");
                        Console.WriteLine("Â¦                                               Â¦    ");
                        Console.WriteLine("+-----------------------------------------------+    ");

                        BibliotecaDTO.Pesquisar_livro();
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
}