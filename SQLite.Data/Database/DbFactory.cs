using System;
using SQLite.Data.Interfaces;

namespace SQLite.Data.Database
{
    public class DbFactory : IDisposable, IDbFactory
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