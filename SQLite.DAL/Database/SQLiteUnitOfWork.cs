using System;
using SQLite.DAL.Interfaces;
using SQLite.DAL.DomainModels;

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

        private IRepository<Event> _eventRepository;
        public IRepository<Event> EventRepository => _eventRepository ?? (_eventRepository = new GenericRepository<Event>(DbContext));

        private IRepository<Place> _placeRepository;
        public IRepository<Place> PlaceRepository => _placeRepository ?? (_placeRepository = new GenericRepository<Place>(DbContext));

        private IRepository<EventType> _eventTypeRepository;
        public IRepository<EventType> EventTypeRepository => _eventTypeRepository ?? (_eventTypeRepository = new GenericRepository<EventType>(DbContext));

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