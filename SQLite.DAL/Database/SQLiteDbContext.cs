using System.Data.Entity;
using SQLite.DAL.DomainModels;

namespace SQLite.DAL.Database
{
    public class SQLiteDbContext : DbContext
    {
        public SQLiteDbContext() : base("Name=SQLiteDbContext") {}

        public DbSet<Person> Persons { get; set; }
        public DbSet<ByName> ByNames { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<PersonFamily> PersonFamilies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("person", "");
            modelBuilder.Entity<ByName>().ToTable("byname", "");
            modelBuilder.Entity<Place>().ToTable("place", "");
            modelBuilder.Entity<Event>().ToTable("event", "");
            modelBuilder.Entity<EventType>().ToTable("event_type", "");
            modelBuilder.Entity<Family>().ToTable("family", "");
            modelBuilder.Entity<PersonFamily>().ToTable("person_family", "");

            System.Data.Entity.Database.SetInitializer<SQLiteDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}