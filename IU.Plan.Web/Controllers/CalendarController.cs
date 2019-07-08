using System;
using System.Linq;
using System.Web.Mvc;
using IU.Plan.Web.Models;
using IU.PlanManager.ConApp;
using IU.PlanManager.ConApp.Models;

namespace IU.Plan.Web.Controllers
{
    public class CalendarController : Controller
    {
        private IStore<Event> store = new EventFileStore();

        // GET: Calendar
        public ActionResult Index(DateTime yearMonthDay, string browser)
        {
            ViewBag.bro = browser;

            var today = DateTime.Today;

            var startMonth = yearMonthDay;
            var endMonth = startMonth.AddMonths(1);

            var events = store.Entities.Where(evt =>
                   evt.StartDate >= startMonth && evt.StartDate < endMonth
                );

            var model = new CalendarViewModel
            {
                Events = events,
                Limit = DateTime.DaysInMonth(yearMonthDay.Year, yearMonthDay.Month),
                ColCount = 7,
                StartDay = startMonth
            };         

            return View(model);
        }
    }
}