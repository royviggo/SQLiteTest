using System;
using SQLite.Data.Interfaces;
using SQLite.Data.Models;

namespace SQLite.Data.Database
{
    public class SQLiteUnitOfWork : ISQLiteUnitOfWork, IDisposable
    {
        public SQLiteDbContext DbContext { get; }

        public SQLiteUnitOfWork(IDbFactory dbFactory)
        {
            DbContext = dbFactory.GetSqliteDbContext();
        }

        private IGenericRepository<Person> _personRepository;
        public IGenericRepository<Person> PersonRepository => _personRepository ?? (_personRepository = new GenericRepository<Person>(DbContext));

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}