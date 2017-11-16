using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using SQLite.BLL.Interfaces;
using SQLite.Data.Models;
using SQLite.WEB.Models;

namespace SQLite.WEB.Controllers
{
    public class PersonController : Controller
    {
        [Inject]
        public IPersonService PersonService { get; set; }

        // GET: Person
        public ActionResult Index()
        {
            var persons = PersonService.GetAll();
            var viewModel = Mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(persons);

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var model = PersonService.GetById(id);
            var viewModel = Mapper.Map<Person, PersonViewModel>(model);
            return View(viewModel);
        }

    }
}