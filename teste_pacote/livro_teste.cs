using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class livro_teste{
    
    private string isbn;
    private string titulo;
    private string autor;
    private int ano;
    private string genero;
    private int edicao;
    private int quantidade;

    public livro_teste(string _titulo, string _autor, int _ano, string _genero, int _edicao, int _quantidade, string _isbn)
    {
        isbn = _isbn;
        titulo = _titulo;
        autor = _autor;
        ano = _ano;
        genero = _genero;
        edicao = _edicao;
        quantidade = _quantidade;
    }

    public livro_teste()
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