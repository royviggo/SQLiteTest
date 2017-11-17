using System;
using SQLite.DAL.Interfaces;
using SQLite.DAL.Models;

namespace SQLite.DAL.Database
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

        private IRepository<SuffixName> _suffixNameRepository;
        public IRepository<SuffixName> SuffixNameRepository => _suffixNameRepository ?? (_suffixNameRepository = new GenericRepository<SuffixName>(DbContext));

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