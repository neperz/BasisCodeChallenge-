using Basis.CodeChallenge.Domain.Interfaces.Repository;
using Basis.CodeChallenge.Domain.Models;
using FluentValidation;

namespace Basis.CodeChallenge.Domain.Validation.LivroValidation;

public class BasisLivroUpdateValidation : AbstractValidator<Livro>
{
     

    public BasisLivroUpdateValidation()
    { 
        RuleFor(x => x.CodL)
            .NotNull()
            .WithMessage("Id cannot be null");
         

    }

}
