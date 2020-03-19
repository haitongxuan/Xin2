using Xin.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Net;
using Z.BulkOperations;
using System.Data.SqlClient;

namespace Xin.Repository
{
    public abstract class EntityRepositoryBase<TContext, TEntity> : RepositoryBase<TContext>,
        IRepository<TEntity> where TContext : DbContext where TEntity : class, new()
    {
        private readonly OrderBy<TEntity> DefaultOrderBy = null;// new OrderBy<TEntity>(qry => qry.OrderBy(e => e.Id));

        protected EntityRepositoryBase(TContext context) : base(context)
        { }
        protected EntityRepositoryBase(ILogger<DataAccess> logger, TContext context) : base(logger, context)
        { }
        #region GetAll
        public virtual IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            var result = QueryDb(null, orderBy, includes);
            return result.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            var result = QueryDb(null, orderBy, includes);
            return await result.ToListAsync();
        }


        public IEnumerable<TEntity> NGetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string[] navigationPropertyPaths = null)
        {
            var result = QueryDb(null, orderBy, navigationPropertyPaths);
            return result.ToList();
        }

        public async Task<IEnumerable<TEntity>> NGetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string[] navigationPropertyPaths = null)
        {
            var result = QueryDb(null, orderBy, navigationPropertyPaths);
            return await result.ToListAsync();
        }
        #endregion

        #region Load
        public virtual void Load(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            var result = QueryDb(null, orderBy, includes);
            result.Load();
        }

        public virtual async Task LoadAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            var result = QueryDb(null, orderBy, includes);
            await result.LoadAsync();
        }

        public virtual void Load(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            var result = QueryDb(filter, orderBy, includes);
            result.Load();
        }

        public virtual async Task LoadAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            var result = QueryDb(filter, orderBy, includes);
            await result.LoadAsync();
        }
        #endregion

        #region GetPage
        public virtual IEnumerable<TEntity> GetPage(int startRow, int pageLength, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            if (orderBy == null) orderBy = DefaultOrderBy?.Expression;

            var result = QueryDb(null, orderBy, includes);
            return result.Skip(startRow).Take(pageLength).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetPageAsync(int startRow, int pageLength, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            if (orderBy == null) orderBy = DefaultOrderBy?.Expression;

            var result = QueryDb(null, orderBy, includes);
            return await result.Skip(startRow).Take(pageLength).ToListAsync();
        }

        public IEnumerable<TEntity> NGetPage(int startRow, int pageLength, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string[] navigationPropertyPaths = null)
        {

            if (orderBy == null) orderBy = DefaultOrderBy?.Expression;

            var result = QueryDb(null, orderBy, navigationPropertyPaths);
            return result.Skip(startRow).Take(pageLength).ToList();
        }

        public async Task<IEnumerable<TEntity>> NGetPageAsync(int startRow, int pageLength, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string[] navigationPropertyPaths = null)
        {
            if (orderBy == null) orderBy = DefaultOrderBy?.Expression;

            var result = QueryDb(null, orderBy, navigationPropertyPaths);
            return await result.Skip(startRow).Take(pageLength).ToListAsync();
        }
        #endregion

        #region Get
        public virtual TEntity Get(object id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (includes != null)
            {
                query = includes(query);
            }
            var properties = GetKeyProperties();
            if (properties.Count() != 1 || !(properties.First().PropertyType == id.GetType()))
                throw new Exception(string.Format("Invalid key type {0}.", id == null ? null : id.GetType().Name));
            return query.Where(PropertyEquals<TEntity, object>(typeof(TEntity).GetProperty(properties.First().Name), id)).SingleOrDefault();
        }
        public virtual TEntity Get(params object[] key)
        {
            return Find(key);
        }

        public virtual async Task<TEntity> GetAsync(object id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (includes != null)
            {
                query = includes(query);
            }

            var properties = GetKeyProperties();
            if (properties.Count() != 1 || !(properties.First().PropertyType == id.GetType()))
                throw new Exception(string.Format("Invalid key type {0}.", id == null ? null : id.GetType().Name));
            return await query.Where(PropertyEquals<TEntity, object>(typeof(TEntity).GetProperty(properties.First().Name), id)).SingleOrDefaultAsync();

        }
        public virtual async Task<TEntity> GetAsync(params object[] key)
        {
            return await FindAsync(key);
        }

        public TEntity NGet(object id, string[] navigationPropertyPaths = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            string[] realList = GetUpperIncludePath(navigationPropertyPaths);
            foreach (var realstr in realList)
            {
                query = query.Include(realstr);
            }
            var properties = GetKeyProperties();
            if (properties.Count() != 1 || !(properties.First().PropertyType == id.GetType()))
                throw new Exception(string.Format("Invalid key type {0}.", id == null ? null : id.GetType().Name));
            return query.Where(PropertyEquals<TEntity, object>(typeof(TEntity).GetProperty(properties.First().Name), id)).SingleOrDefault();

        }

        public async Task<TEntity> NGetAsync(object id, string[] navigationPropertyPaths = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (navigationPropertyPaths != null)
            {
                string[] realList = GetUpperIncludePath(navigationPropertyPaths);
                foreach (var realstr in realList)
                {
                    query = query.Include(realstr);
                }
            }

            var properties = GetKeyProperties();
            if (properties.Count() != 1 || !(properties.First().PropertyType == id.GetType()))
                throw new Exception(string.Format("Invalid key type {0}.", id == null ? null : id.GetType().Name));
            return await query.Where(PropertyEquals<TEntity, object>(typeof(TEntity).GetProperty(properties.First().Name), id)).SingleOrDefaultAsync();

        }
        #endregion

        #region Query
        public virtual IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            var result = QueryDb(filter, orderBy, includes);
            return result.ToList();
        }
        public virtual async Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            try
            {
                var result = QueryDb(filter, orderBy, includes);
                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<TEntity> NQuery(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string[] navigationPropertyPaths = null)
        {
            var result = QueryDb(filter, orderBy, navigationPropertyPaths);
            return result.ToList();
        }

        public async Task<IEnumerable<TEntity>> NQueryAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string[] navigationPropertyPaths = null)
        {
            try
            {
                var result = QueryDb(filter, orderBy, navigationPropertyPaths);
                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region QueryPage

        public virtual IEnumerable<TEntity> QueryPage(int startRow, int pageLength, Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            if (orderBy == null) orderBy = DefaultOrderBy?.Expression;

            var result = QueryDb(filter, orderBy, includes);
            return result.Skip(startRow).Take(pageLength).ToList();
        }

        public IEnumerable<TEntity> NQueryPage(int startRow, int pageLength, Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string[] navigationPropertyPaths = null)
        {
            if (orderBy == null) orderBy = DefaultOrderBy?.Expression;

            var result = QueryDb(filter, orderBy, navigationPropertyPaths);
            return result.Skip(startRow).Take(pageLength).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> QueryPageAsync(int startRow, int pageLength, Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            if (orderBy == null) orderBy = DefaultOrderBy?.Expression;

            var result = QueryDb(filter, orderBy, includes);
            return await result.Skip(startRow).Take(pageLength).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> NQueryPageAsync(int startRow, int pageLength, Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string[] navigationPropertyPaths = null)
        {
            if (orderBy == null) orderBy = DefaultOrderBy?.Expression;

            var result = QueryDb(filter, orderBy, navigationPropertyPaths);
            return await result.Skip(startRow).Take(pageLength).ToListAsync();
        }
        #endregion
        public virtual void Add(TEntity entity)
        {
            if (entity == null) throw new InvalidOperationException("Unable to add a null entity to the repository.");
            Context.Set<TEntity>().Add(entity);
        }


        public virtual TEntity Update(object entity)
        {
            List<object> keyValues = new List<object>();
            var properties = GetKeyProperties();
            if (properties.Count() == 0)
                throw new Exception(string.Format("No Key for entity {0}.", typeof(TEntity).Name));
            foreach (var key in properties)
            {
                keyValues.Add(entity.GetType().GetProperty(key.Name).GetValue(entity));
            }

            var existing = Context.Set<TEntity>().Find(keyValues.ToArray());
            if (existing == null) throw new Exception(string.Format("Cannot find entity type {0} with key {1}", typeof(TEntity).Name, string.Join(",", keyValues.ToArray())));
            Context.Entry(existing).CurrentValues.SetValues(entity);
            return existing;
        }
        public virtual TEntity UpdateWithNavigationProperties(TEntity entity)
        {
            Context.Update(entity);
            return entity;
        }
        public virtual void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            Context.Set<TEntity>().Remove(entity);
        }

        public virtual void Remove(params object[] keyValues)
        {
            var entity = new TEntity();
            var properties = GetKeyProperties();
            //if (properties.Count() != 1 || !(properties.First().PropertyType == id.GetType()))
            //    throw new Exception(string.Format("Invalid key type {0}.", id == null ? null : id.GetType().Name));
            if (properties.Count() != keyValues.Count())
                throw new Exception("Wrong number of key values.");
            for (int i = 0; i < properties.Count(); i++)
            {
                var key = properties.ElementAt(i);
                entity.GetType().GetProperty(key.Name).SetValue(entity, keyValues[i]);
            }

            this.Remove(entity);
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.Any();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.AnyAsync();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.Count();
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.CountAsync();
        }
        public void Attach(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
        }
        protected IQueryable<TEntity> QueryDb(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includes)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        protected string[] GetUpperIncludePath(string[] includes)
        {
            List<string> realList = new List<string>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    string[] arr = include.Split(".");
                    string realstr = include;
                    if (arr.Count() > 0)
                    {
                        foreach (string s in arr)
                        {
                            realstr = realstr.Replace(s, s.Substring(0, 1).ToUpper() + s.Substring(1));
                        }
                    }
                    else
                    {
                        realstr = realstr.Substring(0, 1).ToUpper() + realstr.Substring(1);
                    }
                    realList.Add(realstr);
                }
            }
            return realList.ToArray();
        }

        protected IQueryable<TEntity> QueryDb(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string[] includes)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null)
            {
                var realList = GetUpperIncludePath(includes);
                foreach (var realstr in realList)
                {
                    query = query.Include(realstr);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        public void SetUnchanged(TEntity entity)
        {
            base.Context.Entry<TEntity>(entity).State = EntityState.Unchanged;
        }
        private TEntity Find(params object[] key)
        {
            var properties = GetKeyProperties();
            if (properties.Count() == 0)
                throw new Exception(string.Format("No Key for entity {0}.", typeof(TEntity).Name));
            if (properties.Count() != key.Count())
                throw new Exception("Key propertyies number mismatches.");
            return Context.Set<TEntity>().Find(key);
        }
        private async Task<TEntity> FindAsync(params object[] key)
        {
            var properties = GetKeyProperties();
            if (properties.Count() == 0)
                throw new Exception(string.Format("No Key for entity {0}.", typeof(TEntity).Name));
            if (properties.Count() != key.Count())
                throw new Exception("Key propertyies number mismatches.");
            return await Context.Set<TEntity>().FindAsync(key);
        }
        protected virtual IEnumerable<PropertyInfo> GetKeyProperties()
        {
            var properties = Context.FindPrimaryKeys<TEntity>();
            if (properties == null || properties.Count() == 0)
                properties = typeof(TEntity).GetProperties().Where(prop => prop.IsDefined(typeof(KeyAttribute), true)).ToList();
            return properties;
        }
        private Expression<Func<TItem, bool>> PropertyEquals<TItem, TValue>(PropertyInfo property, TValue value)
        {
            var param = Expression.Parameter(typeof(TItem));
            var body = Expression.Equal(Expression.Property(param, property),
                Expression.Constant(value));
            return Expression.Lambda<Func<TItem, bool>>(body, param);
        }
        #region BulkOpertion

        public virtual async Task BulkDelete(IEnumerable<TEntity> entities)
        {
            var set = Context.Set<TEntity>();
            await set.BulkDeleteAsync(entities);
        }
        public virtual void BulkInsert(IEnumerable<TEntity> entities)
        {
            var set = Context.Set<TEntity>();
            set.BulkInsert(entities);
        }

        public virtual void BulkInsert(IEnumerable<TEntity> entities,
            Action<BulkOperation<TEntity>> bulkOperationFactory)
        {
            var set = Context.Set<TEntity>();
            set.BulkInsert(entities, bulkOperationFactory);
        }


        public virtual async Task BulkInsertAsync(IEnumerable<TEntity> entities)
        {
            var set = Context.Set<TEntity>();
            await set.BulkInsertAsync(entities);
        }

        public virtual async Task BulkInsertAsync(IEnumerable<TEntity> entities
            , Action<BulkOperation<TEntity>> bulkOperationFactory)
        {
            var set = Context.Set<TEntity>();
            await set.BulkInsertAsync(entities, bulkOperationFactory);
        }

        public virtual void BulkUpdate(IEnumerable<TEntity> entities)
        {
            var set = Context.Set<TEntity>();
            set.BulkUpdate(entities);
        }

        public virtual void BulkUpdate(IEnumerable<TEntity> entities,
            Action<BulkOperation<TEntity>> bulkOperationFactory)
        {
            var set = Context.Set<TEntity>();
            set.BulkUpdate(entities, bulkOperationFactory);
        }

        public virtual async Task BulkUpdateAsync(IEnumerable<TEntity> entities)
        {
            var set = Context.Set<TEntity>();
            await set.BulkUpdateAsync(entities);
        }

        public virtual async Task BulkUpdateAsync(IEnumerable<TEntity> entities,
            Action<BulkOperation<TEntity>> bulkOperationFactory)
        {
            var set = Context.Set<TEntity>();
            await set.BulkUpdateAsync(entities, bulkOperationFactory);
        }

        public virtual void BulkRemvoe(IEnumerable<TEntity> entities)
        {
            var set = Context.Set<TEntity>();
            set.BulkDelete(entities);
        }

        public virtual void BulkRemvoe(IEnumerable<TEntity> entities,
            Action<BulkOperation<TEntity>> bulkOperationFactory)
        {
            var set = Context.Set<TEntity>();
            set.BulkDelete(entities, bulkOperationFactory);
        }

        public virtual async Task BulkRemveoAsync(IEnumerable<TEntity> entities)
        {
            var set = Context.Set<TEntity>();
            await set.BulkDeleteAsync(entities);
        }

        public virtual async Task BulkRemveoAsync(IEnumerable<TEntity> entities,
            Action<BulkOperation<TEntity>> bulkOperationFactory)
        {
            var set = Context.Set<TEntity>();
            await set.BulkDeleteAsync(entities, bulkOperationFactory);
        }

        public virtual async Task<int> DeleteAll()
        {
            var set = Context.Set<TEntity>();
            int reslut = await set.DeleteFromQueryAsync();
            return reslut;
        }
        #endregion

        #region FromSql
        public IEnumerable<TEntity> ListFromSql(string sql, string filterStr = "", string orderStr = "")
        {
            string queryStr = $"select * from ({sql}) tab where {filterStr} order by {orderStr}";
            IQueryable<TEntity> query = Context.Set<TEntity>();
            return query.FromSql(queryStr).AsEnumerable();
        }

        public int CountFromSql(string sql, string filterStr = "", string orderStr = "")
        {
            string queryStr = $"select count(1) from ({sql}) tab where {filterStr} order by {orderStr}";
            IQueryable<TEntity> query = Context.Set<TEntity>();
            return query.FromSql(queryStr).Count();
        }

        public IEnumerable<TEntity> PageFromSql(string sql, string orderStr, int pageIndex = 1, int pageSize = 50)
        {
            int startrow = (pageIndex - 1) * pageSize + 1;
            int endrow = pageIndex * pageSize;
            string queryStr = $"select row_number over({orderStr}) as rownum,* from ({sql}) tab" +
                $" where rownum between {startrow} and {endrow}";
            IQueryable<TEntity> query = Context.Set<TEntity>();
            return query.FromSql(queryStr).AsEnumerable();
        }

        public IQueryable<TEntity> FromSql(string sql)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            return query.FromSql(sql);
        }
        #endregion
    }
}