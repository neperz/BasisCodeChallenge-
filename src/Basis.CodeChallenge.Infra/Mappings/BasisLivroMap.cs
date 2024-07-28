using AutoMapper;
using Basis.CodeChallenge.Domain.Models;
using Basis.CodeChallenge.Domain.Models.Repository;

namespace Basis.CodeChallenge.Infra.Mappings;

public class DbMapper : Profile
{
    /// <summary>
    /// Mapper Constructor
    /// </summary>
    public DbMapper()
    {
        // Not using ReverseMap due EF tracking issues from DTO to Entity
        CreateMap<Livro, LivroDb>()
            .ForMember(livro => livro.Autores, opt => opt.MapFrom(livro => livro.Autores))
            .ForMember(livro => livro.Assuntos, opt => opt.MapFrom(livro => livro.Assuntos));
        CreateMap<Autor, AutorDb>()
            .ForMember(autorDb => autorDb.Livros, opt => opt.MapFrom(autor => autor.Livros));
        CreateMap<Assunto, AssuntoDb>()
            .ForMember(assuntoDb => assuntoDb.Livros, opt => opt.MapFrom(assunto => assunto.Livro));

    }
}
