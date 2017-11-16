using System;
using SQLite.Data.Interfaces;
using SQLite.Data.Models;

namespace SQLite.Data.Database
{
    public class SQLiteUnitOfWork : IUnitOfWork, IDisposable
    {
        public SQLiteDbContext DbContext { get; }

        public SQLiteUnitOfWork(IDbFactory dbFactory)
        {
            DbContext = dbFactory.GetSqliteDbContext();
        }

        private IRepository<Person> _personRepository;
        public IRepository<Person> PersonRepository => _personRepository ?? (_personRepository = new GenericRepository<Person>(DbContext));

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