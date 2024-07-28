using Basis.CodeChallenge.Domain.Interfaces.Repository;
using Basis.CodeChallenge.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Basis.CodeChallenge.Infra.Repository;

    public class EntityBaseRepository<TEntity> : IEntityBaseRepository<TEntity> where TEntity : class
    {
        protected readonly EntityContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public EntityBaseRepository(EntityContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
            Db.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
            Db.SaveChanges();
    }

        public virtual void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
