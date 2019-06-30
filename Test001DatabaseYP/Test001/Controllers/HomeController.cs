using System.Collections.Generic;
using System.Web.Mvc;
using DataLibrary.Models;
using static DataLibrary.Logic.ServicesProcesor;

namespace Test001.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ViewServices()
        {
            ViewBag.Message = "Services List";
            
            List<ServicesModel> data = LoadServices();
            List<ServicesModel> services = new List<ServicesModel>();

            foreach (var row in data)
            {
                services.Add(new ServicesModel
                {
                    Service_id = row.Service_id,
                    Name = row.Name,
                    Active = row.Active,
                    Date_post = row.Date_post,
                    Limit = row.Limit,
                    Sum = row.Sum,
                });

                var Save = Create();
            }
            return View(services);
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Services Sign Up";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServicesModel model)
        {
                CreateService(model.Name,
                              model.Active);

            return RedirectToAction("ViewServices");
        }

        public ActionResult UpdaterLimit()
        {
            ViewBag.Message = "Services Sign Up";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdaterLimit(ServicesModel model)
        {
           UpdateLimit(model.Service_id, 
                       model.Limit);

            return RedirectToAction("ViewServices");
        }

    }
}