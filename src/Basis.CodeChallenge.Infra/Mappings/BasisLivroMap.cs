using Basis.CodeChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Dapper.SqlMapper;

namespace Basis.CodeChallenge.Infra.Mappings;

    public class BasisLivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");

            builder.HasKey(x => x.CodL);
            builder.Property(x => x.CodL)
                 .HasColumnType("INT") 
                 .IsRequired();

            builder.Property(x => x.Titulo)
                .HasColumnType("TEXT")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.Editora)
                .HasColumnType("TEXT")
                .HasMaxLength(40);


            builder.Property(x => x.Edicao)
                .HasColumnType("INT")                
                .IsRequired();

            builder.Property(x => x.AnoPublicacao)
                .HasColumnType("TEXT")
                .HasMaxLength(4);


            builder.Property(x => x.DateCreated)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }

public class BasisAutorMap : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> builder)
    {
        builder.ToTable("Autor");

        builder.HasKey(x => x.CodAu);
        builder.Property(x => x.CodAu)
             .HasColumnType("INT")
             .IsRequired();

        builder.Property(x => x.Nome)
            .HasColumnType("TEXT")
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(x => x.DateCreated)
            .HasColumnType("datetime")
            .IsRequired();
    }
}

public class BasisAssuntoMap : IEntityTypeConfiguration<Assunto>
{
    public void Configure(EntityTypeBuilder<Assunto> builder)
    {
        builder.ToTable("Assunto");

        builder.HasKey(x => x.CodAs);
        builder.Property(x => x.CodAs)
             .HasColumnType("INT")
             .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnType("TEXT")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.DateCreated)
            .HasColumnType("datetime")
            .IsRequired();
    }
}

public class BasisLivroAutorMap : IEntityTypeConfiguration<Livro_Autor>
{
    public void Configure(EntityTypeBuilder<Livro_Autor> builder)
    {
        builder.ToTable("Livro_Autor");
       
        builder.Property(x => x.Livro_CodL)
             .HasColumnType("INT")
             .IsRequired();

        builder.Property(x => x.Autor_CodAu)
            .HasColumnType("INT")
        .IsRequired();

        builder.HasOne(d => d.CodLivroNavigation)
                                   .WithMany(p => p.Livro_Autores)
                                   .HasForeignKey(d => d.Livro_CodL)
                                   .IsRequired(false)
                                   .OnDelete(DeleteBehavior.ClientSetNull)
                                   .HasConstraintName("Livro_Autor_FkINdex1");


        builder.HasOne(d => d.CodAutorNavigation)
                           .WithMany(p => p.Livro_Autores)
                           .HasForeignKey(d => d.Autor_CodAu)
                           .IsRequired(false)
                           .OnDelete(DeleteBehavior.ClientSetNull)
                           .HasConstraintName("Livro_Autor_FkIndex2");

    }
}

public class BasisLivroAssuntoMap : IEntityTypeConfiguration<Livro_Assunto>
{
    public void Configure(EntityTypeBuilder<Livro_Assunto> builder)
    {
        builder.ToTable("Livro_Assunto");

        builder.Property(x => x.Livro_CodL)
             .HasColumnType("INT")
             .IsRequired();

        builder.Property(x => x.Assunto_CodAs)
            .HasColumnType("INT")
        .IsRequired();

        builder.HasOne(d => d.CodLivroNavigation)
                                   .WithMany(p => p.Livro_Assuntos)
                                   .HasForeignKey(d => d.Livro_CodL)
                                   .IsRequired(false)
                                   .OnDelete(DeleteBehavior.ClientSetNull)
                                   .HasConstraintName("Livro_Assunto_FkINdex1");


        builder.HasOne(d => d.CodAssuntoNavigation)
                           .WithMany(p => p.Livro_Assuntos)
                           .HasForeignKey(d => d.Assunto_CodAs)
                           .IsRequired(false)
                           .OnDelete(DeleteBehavior.ClientSetNull)
                           .HasConstraintName("Livro_Assunto_FkIndex2");

    }
}
