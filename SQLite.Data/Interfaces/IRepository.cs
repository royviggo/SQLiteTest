using System.Collections.Generic;
using System.Data.Entity;

namespace SQLite.DAL.Interfaces
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        T GetById(int id);
        T GetById(string id);

        EntityState GetEntityState(T entity);
        void SetEntityState(T entity, EntityState state);
        T GetOriginal(T entity);

        IEnumerable<T> GetAll();
    }
}