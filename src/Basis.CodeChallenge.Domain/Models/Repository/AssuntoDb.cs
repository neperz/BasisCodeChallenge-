using System;
using System.Collections.Generic;

namespace Basis.CodeChallenge.Domain.Models.Repository
{
    public class AssuntoDb
    {
  

        public int CodAs { get;  set; }
        public string Descricao { get;  set; } 
        public DateTime DateCreated { get;  set; }
        public List<LivroDb> Livros { get; set; }
    }
}
