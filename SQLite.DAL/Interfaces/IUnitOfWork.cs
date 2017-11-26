using SQLite.DAL.DomainModels;

namespace SQLite.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Person> PersonRepository { get; }
        IRepository<Event> EventRepository { get; }
        IRepository<EventType> EventTypeRepository { get; }
        IRepository<Place> PlaceRepository { get; }

        void Save();
        void Dispose();
    }
}