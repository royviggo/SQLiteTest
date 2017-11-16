using SQLite.Data.Models;

namespace SQLite.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Person> PersonRepository { get; }

        void Save();
        void Dispose();
    }
}