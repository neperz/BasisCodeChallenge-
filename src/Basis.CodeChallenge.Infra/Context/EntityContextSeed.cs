using Basis.CodeChallenge.Domain.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Basis.CodeChallenge.Infra.Context;
public class EntityContextSeed
{
    public static class SeedDataFactory
    {
        private static List<AutorDb> Autores { get; set; }
        private static List<AssuntoDb> Assuntos { get; set; }
        private static List<LivroDb> Livros { get; set; }

        /// <summary>
        /// Populate database with default values using migrations
        /// </summary>
        /// <param name="modelBuilder"><see cref="ModelBuilder"/></param>
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var assunto = new AssuntoDb { CodAs = 1, Descricao = "Zier" };
            var autor = new AutorDb { CodAu = 1, Nome = "Zier" };
            var livro = new LivroDb { CodL = 1, Titulo = "Zier", Editora = "Zuveiku", Edicao = 1, AnoPublicacao = "2024" };

            // Entities Data
            modelBuilder.Entity<AutorDb>().HasData(autor);
            modelBuilder.Entity<AssuntoDb>().HasData(assunto);
            modelBuilder.Entity<LivroDb>().HasData(livro);

            modelBuilder.Entity<Livro_AssuntoDb>().HasData(new Livro_AssuntoDb { Assunto_CodAs = 1, Livro_CodL = 1 });
            modelBuilder.Entity<Livro_AutorDb>().HasData(new Livro_AutorDb { Autor_CodAu = 1, Livro_CodL = 1 });

        }
    }
}
