using Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly OnlineReservationContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        protected GenericRepository(OnlineReservationContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
