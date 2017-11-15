using SQLite.Data.Models;

namespace SQLite.Data.Interfaces
{
    public interface ISQLiteUnitOfWork
    {
        IGenericRepository<Person> PersonRepository { get; }
    }
}