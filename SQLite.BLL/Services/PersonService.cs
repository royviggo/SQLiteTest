using System;
using System.Collections.Generic;
using SQLite.DAL.Interfaces;
using SQLite.BLL.Interfaces;
using SQLite.DAL.DomainModels;

namespace SQLite.BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _sqliteUnitOfWork;

        public PersonService(IUnitOfWork sqliteUnitOfWork)
        {
            _sqliteUnitOfWork = sqliteUnitOfWork;
        }

        public Person GetById(int id)
        {
            return _sqliteUnitOfWork.PersonRepository.GetById(id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _sqliteUnitOfWork.PersonRepository.GetAll();
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

    }
}