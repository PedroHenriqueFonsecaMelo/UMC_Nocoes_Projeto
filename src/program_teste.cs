using System;
using UMC_Nocoes_Projeto.src.services;
using UMC_Nocoes_Projeto.src.DTOs;
using main.src.entities;

class program_teste
{
    public static void Main(string[] args)
    {
        //Connectiondb.CreateTableX(typeof(Livroteste));
        //Connectiondb.CreateTableX(typeof(AlunoTeste));

        string opcao = "";
        do
        {
            opcao = Singleton.getInstance().ShowMenu("Menu");

            if (opcao == "0")
                break;

            Console.Clear();

            switch (opcao)
            {
                case "1":
                    {
                        Singleton.getInstance().ShowMenu("ConsultarAluno");
                        break;
                    }

                case "2":
                    {
                        Singleton.getInstance().ShowMenu("ConsultarLivro");
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