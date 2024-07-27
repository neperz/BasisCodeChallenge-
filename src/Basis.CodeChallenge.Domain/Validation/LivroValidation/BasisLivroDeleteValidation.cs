using Basis.CodeChallenge.Domain.Models;
using FluentValidation;

namespace Basis.CodeChallenge.Domain.Validation.LivroValidation;

public class BasisLivroDeleteValidation : AbstractValidator<Livro>
{
    public BasisLivroDeleteValidation()
    {
        RuleFor(x => x.CodL)
            .NotNull()
            .WithMessage("Id cannot be null");
    }
}
