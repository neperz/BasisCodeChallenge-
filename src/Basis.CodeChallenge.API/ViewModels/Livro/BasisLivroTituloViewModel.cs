using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Basis.CodeChallenge.API.ViewModels.Livro;

public class BasisLivroTituloViewModel
{
    public BasisLivroTituloViewModel()
    {

    }
    public BasisLivroTituloViewModel(string titulo)
    {
        Titulo = titulo;
    }

    [FromRoute(Name = "titulo")]
    [Required(ErrorMessage = "Titulo é obrigatório")]
    public string Titulo { get; set; }
}
