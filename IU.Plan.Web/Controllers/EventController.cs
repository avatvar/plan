using System;
using System.Web.Mvc;
using IU.Plan.Web.Models;
using IU.PlanManager.ConApp;
using IU.PlanManager.ConApp.Models;

namespace IU.Plan.Web.Controllers
{
    public class EventController : Controller
    {
        private IStore<Event> store = new EventFileStore();

        // GET: Event
        public ActionResult Details(Guid uid)
        {
            var evt = store.Get(uid);

            return View(evt);
        }

        public PartialViewResult MiniDetails(Guid uid)
        {
            var evt = store.Get(uid);

            return PartialView("Details", evt);
        }

        // GET: Event
        public PartialViewResult Create()
        {
            var evt = new Event()
            {
                Uid = Guid.NewGuid()
            };

            var model = new EventEditModel(evt);

            return PartialView("EventEdit", model);
        }

        // GET: Event
        public PartialViewResult Edit(Guid uid)
        {
            var evt = store.Get(uid);

            var model = new EventEditModel(evt);

            return PartialView("EventEdit", model);
        }

        [HttpPost]
        public PartialViewResult Save(EventEditModel model)
        {
            if (ModelState.IsValid)
            {
                var evt = model.GetEvent();
                try
                {
                    store.Update(evt);
                    ViewBag.SaveResult = "Успешно сохранено";
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return PartialView("EventEdit", model);
        }
    }
}