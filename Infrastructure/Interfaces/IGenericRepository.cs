using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ERPAppInfrastructure.Interfaces
{
    public interface IGenericRepository<T>
        where T : class
    {
        #region Basic CRUD
        Task<T?> GetByIdAsync(object id);
        Task<T?> GetByIdWithIncludesAsync(object id, params Expression<Func<T, object>>[] includes);

        Task<IEnumerable<T>> GetAllAsync(
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool asNoTracking = true
        );

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        public void DeleteRange(IEnumerable<T> entities);
        public void UpdateRange(IEnumerable<T> entities);
        #endregion
        #region LINQ-powered queries

        Task<T?> FirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool asNoTracking = true
        );
        Task<IEnumerable<T>> FindAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = true
        );

        IQueryable<T> WithIncludes(params string[] includes);

        IQueryable<T> Query(Expression<Func<T, bool>>? predicate = null, bool asNoTracking = true);
        #endregion
        #region Helpers
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
        #endregion
    }
}
