using AutoMapper;
using Basis.CodeChallenge.API.ViewModels.Livro;
using Basis.CodeChallenge.Domain.Models;
using Basis.CodeChallenge.Domain.Models.Repository;
using System.Diagnostics.CodeAnalysis;

namespace Basis.CodeChallenge.API.AutoMapper;

[ExcludeFromCodeCoverage]
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        #region BasisLivro


        CreateMap<Livro, BasisLivroViewModel>()
            .ConstructUsing(s => new BasisLivroViewModel(
                s.CodL,
                s.Titulo,
                s.Editora,
                s.Edicao,
                s.AnoPublicacao,                
                s.DateCreated
            )).ReverseMap();
        CreateMap<LivroDb, BasisLivroViewModel>()
        .ConstructUsing(s => new BasisLivroViewModel(
            s.CodL,
            s.Titulo,
            s.Editora,
            s.Edicao,
            s.AnoPublicacao,
            s.DateCreated
        )).ReverseMap();
        #endregion
    }
}
