using Basis.CodeChallenge.Domain.Interfaces.Repository;
using Basis.CodeChallenge.Domain.Models;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Basis.CodeChallenge.Domain.Validation.LivroValidation;

public class BasisLivronsertValidation : AbstractValidator<Livro>
{
    private readonly IBasisLivroRepository _BasisLivroRepository;

    public BasisLivronsertValidation(IBasisLivroRepository BasisLivroRepository)
    {
        _BasisLivroRepository = BasisLivroRepository;
         
        RuleFor(livro => livro.Titulo)
                          .NotEmpty() ; 
       
        RuleFor(x => x.Editora)
            .NotEmpty()
            .WithMessage("Editora is required.")
          
        ;

    }

}
