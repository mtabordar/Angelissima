namespace AngelissimaApi.Models.Repositories
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        private AngelContext _context;
        internal DbSet<TEntity> _dbSet;

        public BaseRepository(AngelContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual TEntity Find(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _dbSet;
            return query.ToList();
        }

        public virtual void Remove(int id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
