using SQLite.Data.Database;

namespace SQLite.Data.Interfaces
{
    public interface IDbFactory
    {
        SQLiteDbContext GetSqliteDbContext();
    }
}