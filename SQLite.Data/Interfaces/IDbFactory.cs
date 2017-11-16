using SQLite.DAL.Database;

namespace SQLite.DAL.Interfaces
{
    public interface IDbFactory
    {
        SQLiteDbContext GetSqliteDbContext();
    }
}