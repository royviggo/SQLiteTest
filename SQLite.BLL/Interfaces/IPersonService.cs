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
        IEnumerable<Person> GetAll();

        int Create(Person person);
        void Update(Person person);
        void Delete(Person personp);
        void DeleteById(int id);
    }
}