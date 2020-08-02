using Jbit.Common.Models.Abstract;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jbit.Common.Data
{
    public interface IRepository<T> where T : IIdentifiable
    {
        Task<T> AddAsync(T item);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> queryCallback = null);

        Task<IQueryable<T>> QueryAsync(Expression<Func<T, bool>> predicate);

        Task<T> UpdateAsync(T item);

        Task DeleteAsync(T item);

        Task SaveChangesAsync();

        Task InitSharedTransactionAsync();
        
        Task CommitTransactionAsync();
        
        Task RollbackTransactionAsync();
    }
}
