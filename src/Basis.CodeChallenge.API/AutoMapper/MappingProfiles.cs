using AutoMapper;
using Basis.CodeChallenge.API.ViewModels.Livro;
using Basis.CodeChallenge.Domain.Models;
using Basis.CodeChallenge.Domain.Models.Repository;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Basis.CodeChallenge.API.AutoMapper;

[ExcludeFromCodeCoverage]
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        #region BasisLivro


        CreateMap<Livro, BasisLivroViewModel>()
             .ForMember(livro => livro.PrecosOrigem, opt => opt.MapFrom(livro => livro.PrecosOrigem))
            .ReverseMap();
        CreateMap<LivroDb, BasisLivroViewModel>();
        CreateMap<PrecoOrigem, PrecoOrigemDb>().ReverseMap();
        #endregion
    }
}
