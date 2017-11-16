using SQLite.DAL.Models;

namespace SQLite.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Person> PersonRepository { get; }

        void Save();
        void Dispose();
    }
}