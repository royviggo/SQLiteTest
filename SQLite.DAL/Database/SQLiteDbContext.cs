using System.Data.Entity;
using SQLite.DAL.DomainModels;

namespace SQLite.DAL.Database
{
    public class SQLiteDbContext : DbContext
    {
        public SQLiteDbContext() : base("Name=SQLiteDbContext") {}

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("person", "");
            modelBuilder.Entity<ByName>().ToTable("byname", "");
            modelBuilder.Entity<Place>().ToTable("place", "");
            modelBuilder.Entity<Event>().ToTable("event", "");
            modelBuilder.Entity<EventType>().ToTable("event_type", "");

            System.Data.Entity.Database.SetInitializer<SQLiteDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}