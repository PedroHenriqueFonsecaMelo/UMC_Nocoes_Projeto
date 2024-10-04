using System;
using UMC_Nocoes_Projeto.src.services;
using UMC_Nocoes_Projeto.src.DTOs;
using UMC_Nocoes_Projeto.src.templates;




class program_teste
{


    public static void Main(string[] args)
    {
        //Repository.CreateTableX(typeof(Livroteste));
        //Repository.CreateTableX(typeof(AlunoTeste));
        TemplateMethod templateMethod = null;
        string opcao = "";
        //ToUML.UML(typeof(Singleton));
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

                        opcao = Singleton.getInstance().ShowMenu("ConsultarAluno", templateMethod);

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
    }

    private static void OpcoesLivro(string opcao)
    {
        BibliotecaDTO biblioteca = new BibliotecaDTO(); ;

        switch (opcao)
        {
            case "1":
                {
                    biblioteca.Criar_livro();
                    break;
                }
            case "2":
                {
                    biblioteca.Atualizar_livro();
                    break;
                }
            case "3":
                {
                    biblioteca.Deletar_livro();
                    break;
                }
            case "4":
                {
                    biblioteca.Pesquisar_livro();
                    break;
                }
        }
    }

    private static void OpcoesAluno(string opcao)
    {
        SecretariaDTO secretaria = new SecretariaDTO();

        switch (opcao)
        {

            case "1":
                {
                    secretaria.CriarAluno();
                    break;
                }
            case "2":
                {
                    secretaria.UpdateAluno();
                    break;
                }
            case "3":
                {
                    secretaria.DeleteAluno();
                    break;
                }
            case "4":
                {
                    secretaria.ConsultarAluno();
                    break;
                }
        }
    }
}