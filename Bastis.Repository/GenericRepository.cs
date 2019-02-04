using Bastis.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Bastis.Repository
{
    //public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    public class GenericRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext _applicationDbContext;
        protected DbSet<TEntity> _DbSet;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            this._DbSet = applicationDbContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TEntity GetByID(long? Id)
        {
            return _DbSet.Find(Id);
        }

        public virtual void Insert(TEntity entity)
        {
            try
            {
                _DbSet.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public virtual void Insert(List<TEntity> entityList)
        {
            try
            {
                _applicationDbContext.Set<TEntity>().AddRange(entityList);
                _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(long Id)
        {
            TEntity entityToDelete = _DbSet.Find(Id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(TEntity entity)
        {
            if (_applicationDbContext.Entry(entity).State == EntityState.Detached)
            {
                _DbSet.Attach(entity);
            }

            _DbSet.Remove(entity);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity)
        {
            try
            {
                _DbSet.Attach(entity);
                _applicationDbContext.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //public IEnumerable<TEntity> GetAll()
        //{
        //    try
        //    {
        //        var query = _applicationDbContext.Set<TEntity>().ToList();
        //        return query;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}       
    }
}
