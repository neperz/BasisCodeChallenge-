using System;
using System.Collections.Generic;

namespace Basis.CodeChallenge.Domain.Models.Repository
{
    public class AutorDb
    {
        
        public int CodAu { get; set; }
        public string Nome { get; set; }
        public List<LivroDb> Livros { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
