using Basis.CodeChallenge.Domain.Models;
using System;
using System.Linq;

namespace Basis.CodeChallenge.Infra.Context;
public class EntityContextSeed
{
    private readonly EntityContext _context;

    public EntityContextSeed(EntityContext context)
    {
        this._context = context;
        this.SeedInitial();
    }

    public void SeedInitial()
    {

        if (!_context.BasisLivros.Any())
        {

            var assunto = new Assunto(descricao: "Zier");
            var autor = new Autor(nome: "Zier");
            var livro = new Livro(titulo: "Zier", editora: "Zuveiku", edicao: 1, anoPublicacao: "2024");
            _context.Add(assunto);
            _context.Add(autor);
            _context.Add(livro);
            var livroAs = new Livro_Assunto(livro.CodL, assunto.CodAs);
            var livroAt = new Livro_Autor(livro.CodL, autor.CodAu);
            _context.Add(livroAs);
            _context.Add(livroAt);


            _context.SaveChanges();
            
        }
    }
}
