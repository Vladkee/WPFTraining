using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DAL.Repository
{
    public interface IRepository <TEntity> : IDisposable where TEntity : class
    {
        public IEnumerable<TEntity> Get();

        public TEntity Get(int id);

        public void Delete(int id);

        public void Delete(TEntity entity);

        public void Update(TEntity entity);

        public void Add(TEntity entity);

        public void Save();
    }
}
