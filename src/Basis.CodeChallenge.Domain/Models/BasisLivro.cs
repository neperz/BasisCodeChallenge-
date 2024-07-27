using System;
using System.Collections.Generic;

namespace Basis.CodeChallenge.Domain.Models;

public class Livro
{
    protected Livro() {
        Livro_Assuntos = new HashSet<Livro_Assunto>();
        Livro_Autores = new HashSet<Livro_Autor>();
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
    public virtual ICollection<Livro_Assunto> Livro_Assuntos { get; set; }
    public virtual ICollection<Livro_Autor> Livro_Autores { get; set; }
    public DateTime DateCreated { get; private set; }

}

public class Autor
{
    protected Autor() {
        Livro_Autores = new HashSet<Livro_Autor>();
        
    }

    public Autor(int codAu, string nome) : this(nome)
    {
        CodAu = codAu;
    }

    public Autor(string nome)
    {
        Nome = nome;
    }

    public int CodAu { get; private set; }
    public string Nome { get; private set; }
    public virtual ICollection<Livro_Autor> Livro_Autores { get; set; }
 
    public DateTime DateCreated { get; private set; }

}

public class Assunto
{
    protected Assunto() {
        Livro_Assuntos = new HashSet<Livro_Assunto>();
    }

    public Assunto(int codAs, string descricao) : this(descricao)
    {
        CodAs = codAs;
    }

    public Assunto(string descricao)
    {
        Descricao = descricao;
    }

    public int CodAs { get; private set; }
    public string Descricao { get; private set; }
    public virtual ICollection<Livro_Assunto> Livro_Assuntos { get; set; }
    public DateTime DateCreated { get; private set; }
}

public class Livro_Autor
{
    protected Livro_Autor() { }

    public Livro_Autor(int livroCodL, int autorCodAu)  
    {
        Livro_CodL = livroCodL;
        Autor_CodAu = autorCodAu;
    }

    public int RowID { get; private set; }
    public int Livro_CodL { get; private set; }
    public virtual Livro CodLivroNavigation { get; set; }
    public int Autor_CodAu { get; private set; }
    public virtual Autor CodAutorNavigation { get; set; }
}

public class Livro_Assunto
{
    protected Livro_Assunto() { }

    public Livro_Assunto(int livroCodL, int assuntoCodAs)
    {
        Livro_CodL = livroCodL;
        Assunto_CodAs = assuntoCodAs;
    }

    public int RowID{ get; private set; }
    public int Livro_CodL { get; private set; }
    public virtual Livro CodLivroNavigation { get; set; }
    public int Assunto_CodAs { get; private set; }
    public virtual Assunto CodAssuntoNavigation { get; set; }
}



