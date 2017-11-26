using System.Collections.Generic;
using SQLite.DAL.DomainModels;

namespace SQLite.BLL.Interfaces
{
    public interface IEventService
    {
        Event GetById(int id);
        IEnumerable<Event> GetAll();
        IEnumerable<Place> GetPlaces();
        IEnumerable<EventType> GetEventTypes();

        int Create(Event e);
        void Update(Event e);
        void Delete(Event e);
        void DeleteById(int id);
    }
}