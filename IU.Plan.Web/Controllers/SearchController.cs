using System.Linq;
using System.Web.Mvc;
using IU.Plan.Web.NH;
using IU.PlanManager.ConApp;
using IU.PlanManager.ConApp.Models;

namespace IU.Plan.Web.Controllers
{
    public class SearchController : Controller
    {
        private IStore<Event> store = new EventDBStore<Event>();

        [HttpPost]
        public ActionResult Filter(string searchRequest)
        {
            var result = store.Entities.Where(ent =>

                ent.Title.Contains(searchRequest) ||

                ent.Description.Contains(searchRequest)

                );

            return PartialView("List", result);
        }
    }
}