using ContactApp.Business.Abstract;
using ContactApp.Entities.Concrete;
using System;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace ContactApp.Api.Controllers
{
    public class HomeController : Controller
    {
        private IContactService _contactService;

        public HomeController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
