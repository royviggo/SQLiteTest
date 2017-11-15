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

        public int Create(Person person)
        {
            person.CreatedDate = DateTime.Now;
            person.ModifiedDate = DateTime.Now;

            _sqliteUnitOfWork.PersonRepository.Add(person);
            _sqliteUnitOfWork.Save();

            return person.Id;
        }

        public void Update(Person person)
        {
            person.ModifiedDate = DateTime.Now;

            _sqliteUnitOfWork.PersonRepository.Update(person);
            _sqliteUnitOfWork.Save();
        }

        public void Delete(Person person)
        {
            _sqliteUnitOfWork.PersonRepository.Delete(person);
            _sqliteUnitOfWork.Save();
        }

        public void DeleteById(int id)
        {
            var person = GetById(id);

            _sqliteUnitOfWork.PersonRepository.Delete(person);
            _sqliteUnitOfWork.Save();
        }

        public IQueryable<Person> AsQueryable()
        {
            return _sqliteUnitOfWork.PersonRepository.AsQueryable();
        }

    }
}