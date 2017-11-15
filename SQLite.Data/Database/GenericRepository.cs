using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using SQLite.Data.Interfaces;

namespace SQLite.Data.Database
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext db)
        {
            _dbContext = db;
            _dbSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            var state = GetEntityState(entity);
            if (state == EntityState.Detached)
            {
                try
                {
                    // Try attach first
                    _dbSet.Attach(entity);
                    SetEntityState(entity, EntityState.Modified);
                }
                catch (InvalidOperationException)
                {
                    // Find already attached object
                    var keyNames = ((IObjectContextAdapter)_dbContext).ObjectContext.CreateObjectSet<T>().EntitySet.ElementType.KeyMembers.Select(k => k.Name);
                    var keyValues = keyNames.Select(keyName => entity.GetType().GetProperty(keyName)?.GetValue(entity)).ToArray();
                    var attachedEntity = _dbSet.Find(keyValues);
                    _dbContext.Entry(attachedEntity).CurrentValues.SetValues(entity);
                    SetEntityState(attachedEntity, EntityState.Modified);
                }
            }
            else if (state == EntityState.Unchanged)
                SetEntityState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Find by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetById(string id)
        {
            return _dbSet.Find(id);
        }

        // Find by custom key with optional includes
        public T GetByKeySelector(Expression<Func<T, bool>> keySelector, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.Where(keySelector);
            if (includes != null)
                query = includes.Aggregate(query, (current, inc) => current.Include(inc));

            return query.SingleOrDefault();
        }

        public EntityState GetEntityState(T entity)
        {
            return _dbContext.Entry(entity).State;
        }

        public void SetEntityState(T entity, EntityState state)
        {
            _dbContext.Entry(entity).State = state;
        }

        public T GetOriginal(T entity)
        {
            var original = (T)Activator.CreateInstance(typeof(T));
            var type = typeof(T);

            var values = _dbContext.Entry(entity).OriginalValues;

            foreach (var name in values.PropertyNames)
            {
                var property = type.GetProperty(name);
                property?.SetValue(original, values.GetValue<object>(name));
            }

            return original;
        }

        public IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            return RunQuery(null, null, filter, orderBy, includes);
        }

        public IEnumerable<T> GetPagedList(int skip, int take, Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            return RunQuery(skip, take, filter, orderBy, includes);
        }

        public DbSqlQuery<T> SqlQuery(string q, params object[] parameters)
        {
            return _dbSet.SqlQuery(q, parameters);
        }

        private IEnumerable<T> RunQuery(int? skip, int? take, Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            if (includes != null)
                query = includes.Aggregate(query, (current, inc) => current.Include(inc));

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            return query.ToList();
        }

    }
}