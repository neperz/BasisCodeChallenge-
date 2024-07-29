using AutoMapper;
using Basis.CodeChallenge.Domain.Models;
using Basis.CodeChallenge.Domain.Models.Repository;
using System;

namespace Basis.CodeChallenge.Infra.Mappings;

public class DbMapper : Profile
{
    /// <summary>
    /// Mapper Constructor
    /// </summary>
    public DbMapper()
    {
        
        CreateMap<Livro, LivroDb>()
            .ForMember(livro => livro.Autores, opt => opt.MapFrom(livro => livro.Autores))
            .ForMember(livro => livro.Assuntos, opt => opt.MapFrom(livro => livro.Assuntos)) 
            ;
        //CreateMap<LivroDb, Livro>()
        //    .ForMember(livro => livro.DateCreated, opt => opt.MapFrom(livro => new DateTime( livro.DateCreated)))
        //    ;


        CreateMap<Autor, AutorDb>()
            .ForMember(autorDb => autorDb.Livros, opt => opt.MapFrom(autor => autor.Livros));

        //CreateMap<AutorDb, Autor>()
        //   .ForMember(Autor => Autor.DateCreated, opt => opt.MapFrom(Autor => new DateTime(Autor.DateCreated)))
        //   ;
        CreateMap<Assunto, AssuntoDb>()
            .ForMember(assuntoDb => assuntoDb.Livros, opt => opt.MapFrom(assunto => assunto.Livro));

        //CreateMap<AssuntoDb, Assunto>()
        //.ForMember(Autor => Autor.DateCreated, opt => opt.MapFrom(Autor => new DateTime(Autor.DateCreated)));

    }
}
