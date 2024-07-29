using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Basis.CodeChallenge.API.ViewModels.Livro;

public class BasisLivroEditoraViewModel
{
    public BasisLivroEditoraViewModel()
    {

    }
    public BasisLivroEditoraViewModel(string editora)
    {
        Editora = editora;
    }

    [FromRoute(Name = "editora")]
    [Required(ErrorMessage = "Editora é obrigatório")]
    public string Editora { get; set; }
}