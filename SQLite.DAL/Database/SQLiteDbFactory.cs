using System;
using SQLite.DAL.Interfaces;

namespace SQLite.DAL.Database
{
    public class SQLiteDbFactory : IDisposable, IDbFactory
    {
        private SQLiteDbContext _dbSqlite;

        public SQLiteDbContext GetSqliteDbContext()
        {
            return _dbSqlite ?? (_dbSqlite = new SQLiteDbContext());
        }

        public void Dispose()
        {
            _dbSqlite?.Dispose();
        }
    }
}