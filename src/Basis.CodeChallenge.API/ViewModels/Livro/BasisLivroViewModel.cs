using Basis.CodeChallenge.Domain.Models;
using Basis.CodeChallenge.Domain.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Basis.CodeChallenge.API.ViewModels.Livro;

public class BasisLivroViewModel
{


    public int CodL { get; set; }
    public string Titulo { get; set; }
    public string Editora { get; set; }
    public int Edicao { get; set; }
    public string AnoPublicacao { get; set; }

    public DateTime DateCreated { get; set; }
    public List<PrecoOrigem> PrecosOrigem { get; }
}
