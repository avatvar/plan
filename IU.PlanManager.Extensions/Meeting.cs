using System.Collections.Generic;
using IU.PlanManager.ConApp.Models;

namespace IU.PlanManager.Extensions
{
    /// <summary>
    /// Встреча
    /// </summary>
    public class Meeting : Event
    {
        /// <summary>
        /// Участники
        /// </summary>
        public virtual IEnumerable<User> Participants { get; set; }
    }
}
