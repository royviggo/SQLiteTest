using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SQLite.BLL.Interfaces;
using SQLite.Data.Interfaces;
using SQLite.Data.Models;

namespace SQLite.BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly ISQLiteUnitOfWork _sqliteUnitOfWork;

        public PersonService(ISQLiteUnitOfWork sqliteUnitOfWork)
        {
            _sqliteUnitOfWork = sqliteUnitOfWork;
        }

        public Person GetById(int id)
        {
            return _sqliteUnitOfWork.PersonRepository.GetById(id);
        }

        public IEnumerable<Person> GetList(Expression<Func<Person, bool>> filter, Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null, params Expression<Func<Person, object>>[] includes)
        {
            return _sqliteUnitOfWork.PersonRepository.GetList(filter, orderBy, includes);
        }


    }
}