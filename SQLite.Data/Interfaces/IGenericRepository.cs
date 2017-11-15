using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace SQLite.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntityBase, new()
    {
        T GetById(int id);
        T GetById(string id);
        T GetByKeySelector(Expression<Func<T, bool>> keySelector, params Expression<Func<T, object>>[] includes);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        IQueryable<T> AsQueryable();
        //IQueryable<T> Filter(IEnumerable<DbFilter> filter, IEnumerable<Expression<Func<T, bool>>> moreExpressions = null, params Expression<Func<T, object>>[] includes);

        EntityState GetEntityState(T entity);
        void SetEntityState(T entity, EntityState state);
        T GetOriginal(T entity);

        IEnumerable<T> All();
        IEnumerable<T> GetList(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetPagedList(int skip, int take, Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);
        DbSqlQuery<T> SqlQuery(string q, params object[] parameters);
    }
}