using System.Linq.Expressions;
using ERPAppInfrastructure.Data;
using ERPAppInfrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ERPAppInfrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected readonly ERPAppContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ERPAppContext contex)
        {
            _context = contex;
            _dbSet = contex.Set<T>();
        }

        #region Basic CRUD
        public async Task<T?> GetByIdAsync(object id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task AddRangeAsync(IEnumerable<T> entities) =>
            await _dbSet.AddRangeAsync(entities);

        public void DeleteRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);

        public void UpdateRange(IEnumerable<T> entities) => _dbSet.UpdateRange(entities);

        #endregion
        #region LINQ-powered queries
        public async Task<T?> GetByIdWithIncludesAsync(
            object id,
            params Expression<Func<T, object>>[] includes
        )
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            foreach (var include in includes)
                query = query.Include(include);

            var key = _context.Model.FindEntityType(typeof(T))!.FindPrimaryKey()!;
            var keyProperty = key.Properties.First().Name;

            return await query.FirstOrDefaultAsync(e =>
                EF.Property<object>(e, keyProperty)!.Equals(id)
            );
        }

        public async Task<IEnumerable<T>> GetAllAsync(
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool asNoTracking = true
        )
        {
            IQueryable<T> query = _dbSet;

            if (asNoTracking)
                query = query.AsNoTracking();
            if (include != null)
                query = include(query);
            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }

        public async Task<T?> FirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool asNoTracking = true
        )
        {
            IQueryable<T> query = _dbSet;

            if (asNoTracking)
                query = query.AsNoTracking();
            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> FindAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = true
        )
        {
            IQueryable<T> query = _dbSet;

            if (asNoTracking)
                query = query.AsNoTracking();
            if (predicate != null)
                query = query.Where(predicate);
            if (include != null)
                query = include(query);
            if (orderBy != null)
                query = orderBy(query);
            if (skip.HasValue)
                query = query.Skip(skip.Value);
            if (take.HasValue)
                query = query.Take(take.Value);

            return await query.ToListAsync();
        }

        public IQueryable<T> WithIncludes(params string[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var inc in includes)
                query = query.Include(inc);

            return query;
        }

        public IQueryable<T> Query(
            Expression<Func<T, bool>>? predicate = null,
            bool asNoTracking = true
        )
        {
            IQueryable<T> query = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;

            return predicate != null ? query.Where(predicate) : query;
        }
        #endregion
        #region Helpers
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate) =>
            await _dbSet.AnyAsync(predicate);

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null) =>
            predicate == null ? await _dbSet.CountAsync() : await _dbSet.CountAsync(predicate);
        #endregion
    }
}
