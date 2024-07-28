using System;
using System.Collections.Generic;

namespace Basis.CodeChallenge.Domain.Models;

public class Livro
{
    protected Livro() {
        Assuntos = new HashSet<Assunto>();
        Autores = new HashSet<Autor>();
    }

    public Livro(int codL, string titulo, string editora, int edicao, string anoPublicacao) : this( titulo, editora, edicao, anoPublicacao)
    {
        CodL = codL;
    }

    public Livro(string titulo, string editora, int edicao, string anoPublicacao)
    {
        Titulo = titulo;
        Editora = editora;
        Edicao = edicao;
        AnoPublicacao = anoPublicacao;
    }

    public int CodL { get; private set; }
    public string Titulo { get; private set; }
    public string Editora { get; private set; }
    public int Edicao { get; private set; }
    public string AnoPublicacao { get; private set; }
    public virtual ICollection<Assunto> Assuntos { get; set; }
    public virtual ICollection<Autor> Autores { get; set; }
    public DateTime DateCreated { get; private set; }

}



