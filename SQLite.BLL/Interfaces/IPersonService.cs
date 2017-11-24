using System.Collections.Generic;
using SQLite.DAL.DomainModels;

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