using Jbit.Common.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jbit.Common.Data
{
    public class Repository<T> : IRepository<T> where T : class, IIdentifiable
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<T> AddAsync(T item)
        {
            var added = await _dbContext.Set<T>().AddAsync(item);

            return added.Entity;
        }

        public Task DeleteAsync(T item)
        {
            _dbContext.Set<T>().Remove(item);

            return Task.CompletedTask;
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> queryCallback = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            
            if(queryCallback != null)
            {
                query = queryCallback(query);
            }
            
            return query.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public Task<IQueryable<T>> QueryAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if(predicate != null)
            {
                query = query.Where(predicate);
            }

            return Task.FromResult(query.AsNoTracking());
        }

        public Task<T> UpdateAsync(T item)
        {
            var entry = _dbContext.Entry(item);
            entry.State = EntityState.Modified;

            return Task.FromResult(entry.Entity);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task InitSharedTransactionAsync()
        {
            if (_dbContext.Database.CurrentTransaction is null)
            {
                return _dbContext.Database.BeginTransactionAsync();
            }

            return Task.CompletedTask;
        }

        public Task CommitTransactionAsync()
        {
            if (_dbContext.Database.CurrentTransaction != null)
            {
                return _dbContext.Database.CurrentTransaction.CommitAsync();
            }

            return Task.CompletedTask;
        }

        public Task RollbackTransactionAsync()
        {
            if (_dbContext.Database.CurrentTransaction != null)
            {
                return _dbContext.Database.CurrentTransaction.RollbackAsync();
            }

            return Task.CompletedTask;
        }
    }
}
