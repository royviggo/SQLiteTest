using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
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
                var dateParser = new GenDateStringParser<DateStringParser>();
                var datePart = dateParser.GetDatePartFromStringDate(e.SortDate.ToString());
                var genDate = new GenDate(datePart);
                e.DateString = genDate.DateString;
                e.GenDate = genDate;
                e.GenDateType = genDate.DateType;
                e.FromDatePart = genDate.FromDatePart;
                e.FromDate = genDate.FromDate;
            }

            return View(viewModel);
        }
    }
}