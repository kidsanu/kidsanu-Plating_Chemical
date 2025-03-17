using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.Entity;
using WebApplication2.Models.Data;

namespace WebApplication2.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            PersonManager p = new PersonManager();
            PersonInfo model = new PersonInfo();
            model = p.GetPersonInfos();
            return View(model);
        }

}
}