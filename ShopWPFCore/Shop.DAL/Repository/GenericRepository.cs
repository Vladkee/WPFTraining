using Microsoft.EntityFrameworkCore;
using Shop.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.DAL.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ShopDbContext context;
        private DbSet<TEntity> dbSet;
        private bool disposed;

        public GenericRepository()
        {
            this.context = new ShopDbContext();
            this.dbSet = this.context.Set<TEntity>();
            this.disposed = false;
        }

        public IEnumerable<TEntity> Get()
        {
            return this.dbSet.ToList();
        }

        public TEntity Get(int id)
        {
            return this.dbSet.Find(id);
        }

        public void Delete(int id)
        {
            TEntity entityToDelete = this.dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entity)
        {
            if (this.context.Entry(entity).State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }
            this.dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            this.dbSet.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
