using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using SQLite.BLL.Interfaces;
using SQLite.DAL.Models;
using SQLite.DAL.DomainModels;
using SQLite.WEB.Models;

namespace SQLite.WEB.Controllers
{
    public class EventController : Controller
    {
        [Inject]
        public IEventService EventService { get; set; }

        // GET: Person
        public ActionResult Index()
        {
            var events = EventService.GetAll();
            var viewModel = Mapper.Map<IEnumerable<Event>, IEnumerable<EventViewModel>>(events);

            return View(viewModel);
        }

    }
}