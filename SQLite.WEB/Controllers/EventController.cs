using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using SQLite.BLL.Extensions;
using SQLite.BLL.Interfaces;
using SQLite.BLL.Models;
using SQLite.DAL.Models;
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

        public ActionResult Test()
        {
            var events = EventService.GetAll();
            var viewModel = Mapper.Map<IEnumerable<Event>, IEnumerable<EventTestViewModel>>(events);
            foreach (var e in viewModel)
            {
                var dateParser = new DateStringParser();
                var datePart = dateParser.GetDatePartFromStringDate(e.SortDate.ToString());
                e.GenDate = new GenDate(datePart);
                e.SortDate = e.GenDate.SortDate;
                e.DateString = e.GenDate.DateString;
            }

            return View(viewModel);
        }
    }
}