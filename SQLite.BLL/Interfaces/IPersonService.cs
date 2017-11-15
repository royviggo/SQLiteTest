using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SQLite.Data.Models;

namespace SQLite.BLL.Interfaces
{
    public interface IPersonService
    {
        Person GetById(int id);
        //Person GetById(int id, params Expression<Func<Person, object>>[] includes);
        //int Create(Person p);
        //void Update(Person p);
        //void Delete(Person p);

        IEnumerable<Person> GetList(Expression<Func<Person, bool>> filter, Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null, params Expression<Func<Person, object>>[] includes);
    }
}