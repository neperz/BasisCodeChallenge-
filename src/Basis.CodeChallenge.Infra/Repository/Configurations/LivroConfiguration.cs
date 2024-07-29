using Basis.CodeChallenge.Domain.Models;
using Basis.CodeChallenge.Domain.Models.Repository;
using Basis.CodeChallenge.Infra.Repository.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Dapper.SqlMapper;

namespace Basis.CodeChallenge.Infra.Repository.Configurations
{
    //    /// <summary>
    /// Permission Configuration to handle the database structure for <see cref="LivroDb"/>
    /// </summary>


    public class LivroConfiguration : IEntityTypeConfiguration<LivroDb>
    {
        public void Configure(EntityTypeBuilder<LivroDb> builder)
        {
            builder.ToTable("LivroDb");


            builder.HasKey(u => u.CodL);
            builder.Property(u => u.CodL).HasColumnType("integer COLLATE BINARY")
                //.ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Titulo)
                .HasColumnType("varchar COLLATE BINARY")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.Editora)
                .HasColumnType("varchar COLLATE BINARY")
                .HasMaxLength(40);


            builder.Property(x => x.Edicao)
                .HasColumnType("integer COLLATE BINARY")
                .IsRequired();

            builder.Property(x => x.AnoPublicacao)
                .HasColumnType("varchar COLLATE BINARY")
                .HasMaxLength(4);
            builder.Property(u => u.DateCreated).HasColumnType("bigint COLLATE BINARY").HasConversion(new UnixDateTimeConverter());

            builder.HasMany(u => u.Assuntos)
                .WithMany(g => g.Livros)
                .UsingEntity<Livro_AssuntoDb>(
                    j => j.HasOne(ug => ug.CodAssuntoNavigation)
                        .WithMany()
                        .HasForeignKey(gp => gp.Assunto_CodAs)
                        .HasConstraintName("Livro_Assunto_FkINdex1")
                        ,

                    j => j.HasOne(gp => gp.CodLivroNavigation)
                        .WithMany()
                        .HasForeignKey(gp => gp.Livro_CodL)
                        .HasConstraintName("Livro_Assunto_FkINdex2")
                        ,
                    j =>
                    {
                        j.ToTable("Livro_Assunto");
                        j.HasKey(gp => new { gp.Assunto_CodAs, gp.Livro_CodL });
                    });


            builder.HasMany(u => u.Autores)
                .WithMany(g => g.Livros)
                .UsingEntity<Livro_AutorDb>(
                    j => j.HasOne(ug => ug.CodAutorNavigation)
                        .WithMany()
                        .HasForeignKey(gp => gp.Autor_CodAu)
                        .HasConstraintName("Livro_Autor_FkINdex1")
                        ,
                    j => j.HasOne(gp => gp.CodLivroNavigation)
                        .WithMany()
                        .HasForeignKey(gp => gp.Livro_CodL)
                        .HasConstraintName("Livro_Autor_FkINdex2")
                        ,
                    j =>
                    {
                        j.ToTable("Livro_AutorDb");
                        j.HasKey(gp => new { gp.Autor_CodAu, gp.Livro_CodL });
                    });


                builder.HasMany(e => e.PrecosOrigem)
                       .WithOne(p => p.CodLivroNavigationLivro)
                       .HasForeignKey(p => p.Livro_CodL)
                       .HasConstraintName("Livro_Origem_FkINdex")
                       ;


        }
    }
}
 