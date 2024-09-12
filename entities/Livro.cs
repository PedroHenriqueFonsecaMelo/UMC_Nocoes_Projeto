using System.ComponentModel.DataAnnotations;

class Livro
{

    [Key]
    int id;
    string isbn;
    string titulo;
    string autor;
    int ano;
    string genero;
    int edicao;
    int quantidade;

    public Livro()
    {
    }

    public int Id { get => id; set => id = value; }

    [MaxLength(255)]
    public string Isbn { get => isbn; set => isbn = value; }

    [MaxLength(255)]
    public string Titulo { get => titulo; set => titulo = value; }
    public string Autor { get => autor; set => autor = value; }
    public int Ano { get => ano; set => ano = value; }
    public string Genero { get => genero; set => genero = value; }
    public int Edicao { get => edicao; set => edicao = value; }
    public int Quantidade { get => quantidade; set => quantidade = value; }
}