using System;
using System.Collections.Generic;

namespace Basis.CodeChallenge.Domain.Models.Repository
{
    public class LivroDb
    {

        public int CodL { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public DateTime DateCreated { get;  set; }
        public List<AssuntoDb> Assuntos { get; set; }
        public List<AutorDb> Autores { get; set; }
    }
}
