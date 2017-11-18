using System;
using System.Collections.Generic;
using SQLite.BLL.Interfaces;
using SQLite.DAL.Interfaces;
using SQLite.DAL.Models;

namespace SQLite.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _sqliteUnitOfWork;

        public EventService(IUnitOfWork sqliteUnitOfWork)
        {
            _sqliteUnitOfWork = sqliteUnitOfWork;
        }

        public Event GetById(int id)
        {
            return _sqliteUnitOfWork.EventRepository.GetById(id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _sqliteUnitOfWork.EventRepository.GetAll();
        }

        public int Create(Event e)
        {
            e.CreatedDate = DateTime.Now;
            e.ModifiedDate = DateTime.Now;

            _sqliteUnitOfWork.EventRepository.Add(e);
            _sqliteUnitOfWork.Save();

            return e.Id;
        }

        public void Update(Event e)
        {
            e.ModifiedDate = DateTime.Now;

            _sqliteUnitOfWork.EventRepository.Update(e);
            _sqliteUnitOfWork.Save();
        }

        public void Delete(Event e)
        {
            _sqliteUnitOfWork.EventRepository.Delete(e);
            _sqliteUnitOfWork.Save();
        }

        public void DeleteById(int id)
        {
            var e = GetById(id);

            _sqliteUnitOfWork.EventRepository.Delete(e);
            _sqliteUnitOfWork.Save();
        }
    }
}