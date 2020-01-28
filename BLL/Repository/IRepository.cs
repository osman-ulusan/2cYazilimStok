using DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public interface IGenericRepository<T>
         where T : class
    {
        T FindById(object EntityId);
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null);
        bool Insert(T Entity);
        void Update(T Entity);
        void Delete(object EntityId);
        void Delete(T Entity);
    }

    public class Repository<T> : IGenericRepository<T> where T : class
    {
        private Context2c _context;
        private DbSet<T> _dbSet;
        public Repository(Context2c Context)
        {
            _context = Context;
            _dbSet = _context.Set<T>();
        }
        public virtual T FindById(object EntityId)
        {
            return _dbSet.Find(EntityId);
        }
        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter != null)
            {
                return _dbSet.Where(Filter);
            }
            return _dbSet;
        }
        public virtual bool Insert(T entity)
        {
            _dbSet.Add(entity);
            return true;
        }
        public virtual void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public virtual void Delete(object EntityId)
        {
            T entityToDelete = _dbSet.Find(EntityId);
            Delete(entityToDelete);
        }
        public virtual void Delete(T Entity)
        {
            if (_context.Entry(Entity).State == EntityState.Detached) //Concurrency için 
            {
                _dbSet.Attach(Entity);
            }
            _dbSet.Remove(Entity);
        }
    }
}
