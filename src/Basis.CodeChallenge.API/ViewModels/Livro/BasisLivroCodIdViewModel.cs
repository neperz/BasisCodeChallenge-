using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Basis.CodeChallenge.API.ViewModels.Livro;

public class BasisLivroCodIdViewModel
{
    public BasisLivroCodIdViewModel()
    {

    }
    public BasisLivroCodIdViewModel(int codL)
    {
        CodL = codL;
    }

    [FromRoute(Name = "CodL")]
    [Required(ErrorMessage = "Cod Livro é obrigatório")]
    public int CodL { get; set; }
}
