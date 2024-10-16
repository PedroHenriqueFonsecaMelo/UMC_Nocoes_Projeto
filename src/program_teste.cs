using System;
using UMC_Nocoes_Projeto.src.services;
using UMC_Nocoes_Projeto.src.DTOs;
using UMC_Nocoes_Projeto.src.templates;
using UMC_Nocoes_Projeto.src.dbcon;




class program_teste
{
    
    static Singleton singleton = Singleton.getInstance();

    public static void Main(string[] args)
    {
        TemplateMethod templateMethod = null;
        //Repository.CreateTableX(typeof(Livroteste));
        //Repository.CreateTableX(typeof(AlunoTeste));

        string opcao = "";
        //ToUML.UML(typeof(Singleton));
        //ToUML.UmlGenerator("UMC_Nocoes_Projeto.src.DTOs");
        //ToUML.UmlGenerator("main.src.entities");
        //ToUML.UmlGenerator("UMC_Nocoes_Projeto.src.services");
        //ToUML.UmlGenerator("UMC_Nocoes_Projeto.src.repositories");
        //ToUML.UmlGenerator("UMC_Nocoes_Projeto.src.templates");
        //ToUML.UmlGenerator(typeof(program_teste).Namespace);

        opcao = MainMethod(ref templateMethod);
    }

    private static string MainMethod(ref TemplateMethod templateMethod)
    {
        string opcao;
        do
        {
            opcao = Singleton.getInstance().ShowMenu("Menu", templateMethod);

            if (opcao == "0")
                break;

            Console.Clear();

            switch (opcao)
            {
                case "1":
                    {
                        templateMethod = new SecretariaDTO();

                        opcao = singleton.ShowMenu("ConsultarAluno", templateMethod);

                        //OpcoesAluno(opcao);

                        break;
                    }

                case "2":
                    {
                        templateMethod = new BibliotecaDTO();
                        Singleton.getInstance().ShowMenu("ConsultarLivro", templateMethod);

                        //OpcoesLivro(opcao);
                        break;

                    }
                default:
                    {
                        Console.WriteLine("Digitou uma opção invalida!!");
                        break;
                    }
            }

        } while (opcao != "0");
        return opcao;
    }
}