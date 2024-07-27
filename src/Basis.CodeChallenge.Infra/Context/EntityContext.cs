using Basis.CodeChallenge.Domain.Interfaces;
using Basis.CodeChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Basis.CodeChallenge.Infra.Context;

public class EntityContext : DbContext
{
 
    public EntityContext(DbContextOptions<EntityContext> options)
         : base(options)
    {
    
    }

    public DbSet<Livro> BasisLivros { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        //  modelBuilder.ApplyConfiguration(new BasisLivroMap());
        builder.Entity<Livro>(entity =>
        {
            entity.ToTable("Livro");

            entity.HasKey(x => x.CodL);
            entity.Property(x => x.CodL)
             .HasColumnType("INTEGER")
             .IsRequired()
             .ValueGeneratedOnAdd(); 

            entity.Property(x => x.Titulo)
            .HasColumnType("TEXT")
            .HasMaxLength(40)
            .IsRequired();

            entity.Property(x => x.Editora)
            .HasColumnType("TEXT")
            .HasMaxLength(40);


            entity.Property(x => x.Edicao)
            .HasColumnType("INTEGER")
            .IsRequired();

            entity.Property(x => x.AnoPublicacao)
            .HasColumnType("TEXT")
            .HasMaxLength(4);


            entity.Property(x => x.DateCreated)
            .HasColumnType("datetime")
            .IsRequired();
        });
        builder.Entity<Autor>(entity =>
        {
            entity.ToTable("Autor");

            entity.HasKey(x => x.CodAu);
            entity.Property(x => x.CodAu)
             .HasColumnType("INTEGER")
             .IsRequired()
             .ValueGeneratedOnAdd();

            entity.Property(x => x.Nome)
            .HasColumnType("TEXT")
            .HasMaxLength(40)
            .IsRequired();

            entity.Property(x => x.DateCreated)
            .HasColumnType("datetime")
            .IsRequired();
        });
        builder.Entity<Assunto>(entity =>
        {
            entity.ToTable("Assunto");

            entity.HasKey(x => x.CodAs);
            entity.Property(x => x.CodAs)
             .HasColumnType("INTEGER")             
             .IsRequired()
             .ValueGeneratedOnAdd();

            entity.Property(x => x.Descricao)
            .HasColumnType("TEXT")
            .HasMaxLength(20)
            .IsRequired();

            entity.Property(x => x.DateCreated)
            .HasColumnType("datetime")
            .IsRequired();
        });
        builder.Entity<Livro_Autor>(entity =>
        {
            entity.ToTable("Livro_Autor");

            
            entity.HasKey(x => x.RowID);

            entity.Property(x => x.RowID)
                .HasColumnType("INTEGER") 
                .IsRequired()
                .ValueGeneratedOnAdd();

            entity.Property(x => x.Livro_CodL)
             .HasColumnType("INTEGER")
             .IsRequired();

            entity.Property(x => x.Autor_CodAu)
            .HasColumnType("INTEGER")
        .IsRequired();

            entity.HasOne(d => d.CodLivroNavigation)
                                   .WithMany(p => p.Livro_Autores)
                                   .HasForeignKey(d => d.Livro_CodL)
                                   .IsRequired(false)
                                   .OnDelete(DeleteBehavior.ClientSetNull)
                                   .HasConstraintName("Livro_Autor_FkINdex1");


            entity.HasOne(d => d.CodAutorNavigation)
                           .WithMany(p => p.Livro_Autores)
                           .HasForeignKey(d => d.Autor_CodAu)
                           .IsRequired(false)
                           .OnDelete(DeleteBehavior.ClientSetNull)
                           .HasConstraintName("Livro_Autor_FkIndex2");
        });
        builder.Entity<Livro_Assunto>(entity =>
        {
            entity.ToTable("Livro_Assunto");
            entity.HasKey(x => x.RowID);
            entity.Property(x => x.RowID)
             .HasColumnType("INTEGER")
             .IsRequired()
             .ValueGeneratedOnAdd();

            entity.Property(x => x.Livro_CodL)
             .HasColumnType("INTEGERINT")
             .IsRequired();

            entity.Property(x => x.Assunto_CodAs)
            .HasColumnType("IINTEGERNT")
        .IsRequired();

            entity.HasOne(d => d.CodLivroNavigation)
                                   .WithMany(p => p.Livro_Assuntos)
                                   .HasForeignKey(d => d.Livro_CodL)
                                   .IsRequired(false)
                                   .OnDelete(DeleteBehavior.ClientSetNull)
                                   .HasConstraintName("Livro_Assunto_FkINdex1");


            entity.HasOne(d => d.CodAssuntoNavigation)
                           .WithMany(p => p.Livro_Assuntos)
                           .HasForeignKey(d => d.Assunto_CodAs)
                           .IsRequired(false)
                           .OnDelete(DeleteBehavior.ClientSetNull)
                           .HasConstraintName("Livro_Assunto_FkIndex2");
        });
        base.OnModelCreating(builder);
    }

    public override int SaveChanges()
    {
        int saveResult = 0;
        foreach (var entry in ChangeTracker.Entries().Where(entity => entity.Entity.GetType().GetProperty("DateCreated") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("DateCreated").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("DateCreated").IsModified = false;
            }
        }
        return saveResult;


    }
}

