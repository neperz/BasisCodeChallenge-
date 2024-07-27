using Basis.CodeChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Basis.CodeChallenge.API.ViewModels.Livro;

public class BasisLivroViewModel
{
  
  
  
        [JsonConstructor]
        public BasisLivroViewModel(int codL, string titulo, string editora, int edicao, string anoPublicacao, DateTime dateCreated)
        {
            CodL = codL;
            Titulo = titulo;
            Editora = editora;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;
            DateCreated = dateCreated;
        }

        public int CodL { get;  set; }
        public string Titulo { get;  set; }
        public string Editora { get;  set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }

        public DateTime DateCreated { get; set; }

}
