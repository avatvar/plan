using System;
using System.Linq;
using System.Web.Mvc;
using IU.Plan.Web.Models;
using IU.PlanManager.ConApp.Models;

namespace IU.Plan.Web.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            var store = new EventFileStore();


            var today = DateTime.Today;
            var startMonth = new DateTime(today.Year, today.Month, 1);
            var endMonth = startMonth.AddMonths(1);

            var events = store.Entities.Where(evt =>
                   evt.StartDate >= startMonth && evt.StartDate < endMonth
                );

            var model = new CalendarViewModel
            {
                Events = events,
                Limit = DateTime.DaysInMonth(today.Year, today.Month),
                ColCount = 7
            };

            return View(model);
        }
    }
}