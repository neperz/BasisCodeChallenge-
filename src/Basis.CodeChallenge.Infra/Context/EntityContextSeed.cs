using Basis.CodeChallenge.Domain.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
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
            var assunto = new List<AssuntoDb>  { new AssuntoDb { CodAs = 1, Descricao = "Zier", DateCreated=DateTime.Now } };
            var autor = new AutorDb { CodAu = 1, Nome = "Zier", DateCreated = DateTime.Now };
            var livro = new LivroDb { CodL = 1, Titulo = "Zier", Editora = "Zuveiku", Edicao = 1, AnoPublicacao = "2024", DateCreated = DateTime.Now };
            //: balcão, self-service, internet, evento
            var precoOrigem =new List<PrecoOrigemDb> {
                new PrecoOrigemDb { CoPo = 1, Livro_CodL = 1, Origem = "balcão", Valor = 1000, DateCreated = DateTime.Now } ,
                    new PrecoOrigemDb { CoPo = 1, Livro_CodL = 1, Origem = "self-service", Valor = 500, DateCreated = DateTime.Now  }  ,
                    new PrecoOrigemDb { CoPo = 1, Livro_CodL = 1, Origem = "self-service", Valor = 500, DateCreated = DateTime.Now }
                    };

            // Entities Data
            modelBuilder.Entity<LivroDb>().HasData(precoOrigem);
            modelBuilder.Entity<AssuntoDb>().HasData(assunto);
            modelBuilder.Entity<AutorDb>().HasData(autor);            
            modelBuilder.Entity<LivroDb>().HasData(livro);

            modelBuilder.Entity<Livro_AssuntoDb>().HasData(new Livro_AssuntoDb { Assunto_CodAs = 1, Livro_CodL = 1 });
            modelBuilder.Entity<Livro_AutorDb>().HasData(new Livro_AutorDb { Autor_CodAu = 1, Livro_CodL = 1 });
            

        }
    }
}
