using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using Ninject.Infrastructure.Language;
using SQLite.BLL.Interfaces;
using SQLite.DAL.DomainModels;
using SQLite.WEB.Extensions;
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

        public ActionResult Details(int id)
        {
            var model = EventService.GetById(id);
            var viewModel = Mapper.Map<Event, EventViewModel>(model);
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var model = EventService.GetById(id);
            var viewModel = Mapper.Map<Event, EventEditModel>(model);
            viewModel.EventTypeList = EventService.GetEventTypes().OrderBy(m => m.Name).ToDictionary(k => k.Id, v => v.Name).ToSelectList();
            viewModel.PlaceList = EventService.GetPlaces().OrderBy(m => m.Name).ToDictionary(k => k.Id, v => v.Name).ToSelectList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EventEditModel model)
        {
            var oldModel = EventService.GetById(model.Id);
            try
            {
                var updateModel = Mapper.Map<EventEditModel, Event>(model);
                updateModel.CreatedDate = oldModel.CreatedDate;
                EventService.Update(updateModel);
                return RedirectToAction("Details", "Person", new { id = model.PersonId });
            }
            catch (Exception e)
            {
                return View(model);
            }

        }
    }
}