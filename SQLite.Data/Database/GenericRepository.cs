using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SQLite.DAL.Interfaces;

namespace SQLite.DAL.Database
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity, new()
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

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetById(string id)
        {
            return _dbSet.Find(id);
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

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

    }
}