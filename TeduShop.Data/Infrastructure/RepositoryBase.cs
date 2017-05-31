using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TeduShop.Data.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Properties

        private TeduShopDbContext dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory { get; }


        protected TeduShopDbContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        #endregion

        #region Implementation

        public T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual T Delete(T entity)
        {
            return dbSet.Remove(entity);
        }

        public virtual T Delete(int id)
        {
            var entity = dbSet.Find(id);
            return dbSet.Remove(entity);
        }

        public virtual void DeleteMutli(Expression<Func<T, bool>> where)
        {
            var objects = dbSet.Where(where).AsEnumerable();
            foreach (var obj in objects)
                dbSet.Remove(obj);
        }

        public T GetSingleById(int id)
        {
            return dbSet.Find(id);
        }

        public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Any())
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault(expression);
            }
            return dataContext.Set<T>().FirstOrDefault(expression);
        }

        public IEnumerable<T> GetAll(string[] includes = null)
        {
            //HANDLE  INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Any())
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }
            return dataContext.Set<T>().AsQueryable();
        }

        public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            //HANDLE  INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Any())
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where(predicate).AsQueryable();
            }
            return dataContext.Set<T>().Where(predicate).AsQueryable();
        }

        public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0,
            int size = 50, string[] includes = null)
        {
            var skipCount = index * size;
            IQueryable<T> resetSet = null;

            //HANDLE  INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Any())
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                    resetSet = filter != null ? query.Where(filter).AsQueryable() : query.AsQueryable();
                }
            }
            else
            {
                resetSet = filter != null
                    ? dataContext.Set<T>().Where(filter).AsQueryable()
                    : dataContext.Set<T>().AsQueryable();
            }
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return dbSet.Count(where);
        }

        public bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return dataContext.Set<T>().Count(predicate) > 0;
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, string includes)
        {
            return dbSet.Where(where).ToList();
        }

        #endregion
    }
}