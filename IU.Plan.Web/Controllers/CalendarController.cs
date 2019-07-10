using System;
using System.Linq;
using System.Web.Mvc;
using IU.Plan.Web.Models;
using IU.PlanManager.ConApp;
using IU.PlanManager.ConApp.Models;
using IU.PlanManager.Extensions;

namespace IU.Plan.Web.Controllers
{
    public class CalendarController : Controller
    {
        private IStore<Event> eventStore = new EventFileStore();

        private IStore<Activity> activityStore = new BaseFileStore<Activity>();
        
        // GET: Calendar
        public ActionResult Index(DateTime yearMonthDay)
        {
            var today = DateTime.Today;

            var startMonth = yearMonthDay;
            var endMonth = startMonth.AddMonths(1);

            var events = eventStore.Entities.Where(evt =>
                   evt.StartDate >= startMonth && evt.StartDate < endMonth
                ).ToList();

            events.AddRange(activityStore.Entities.Where(evt =>
                 evt.StartDate >= startMonth && evt.StartDate < endMonth
                )
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