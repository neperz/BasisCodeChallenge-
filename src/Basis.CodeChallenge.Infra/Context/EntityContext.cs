using Basis.CodeChallenge.Domain.Interfaces;
using Basis.CodeChallenge.Domain.Models;
using Basis.CodeChallenge.Infra.Repository.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection.Emit;
using static Basis.CodeChallenge.Infra.Context.EntityContextSeed;

namespace Basis.CodeChallenge.Infra.Context;

public class EntityContext : DbContext
{
 
    public EntityContext(DbContextOptions<EntityContext> options)
         : base(options)
    {
    
    }

    public DbSet<Livro> BasisLivros { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AutorConfiguration());
        modelBuilder.ApplyConfiguration(new AssuntoConfiguration());
        modelBuilder.ApplyConfiguration(new LivroConfiguration());
        SeedDataFactory.SeedData(modelBuilder);
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

