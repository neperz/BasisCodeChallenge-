using System;
using System.Collections.Generic;

namespace Basis.CodeChallenge.Domain.Models;

public class Autor
{

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
    public List<Livro> Livros { get; set; }

    public DateTime DateCreated { get; private set; }

}



