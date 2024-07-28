using System;
using System.Collections.Generic;

namespace Basis.CodeChallenge.Domain.Models;

public class Assunto
{
    

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
    public virtual ICollection<Livro> Livro  { get; set; }
    public DateTime DateCreated { get; private set; }
}



