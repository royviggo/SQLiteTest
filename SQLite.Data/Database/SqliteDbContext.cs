using System.Data.Entity;
using SQLite.Data.Models;

namespace SQLite.Data.Database
{
    public class SQLiteDbContext : DbContext
    {
        public SQLiteDbContext() : base("Name=SQLiteDbContext") {}

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person", "");
            System.Data.Entity.Database.SetInitializer<SQLiteDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}