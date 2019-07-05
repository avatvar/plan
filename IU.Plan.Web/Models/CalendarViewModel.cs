using System;
using System.Collections.Generic;
using IU.PlanManager.ConApp.Models;

namespace IU.Plan.Web.Models
{
    public class CalendarViewModel
    {
        public CalendarViewModel()
        {
            Events = new List<Event>();
        }

        /// <summary>
        /// События
        /// </summary>
        public IEnumerable<Event> Events { get; set; }

        /// <summary>
        /// Количество ячеек
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Количество колонок
        /// </summary>
        public int ColCount { get; set; }

        /// <summary>
        /// Количество строк
        /// </summary>
        public int RowCount => (int)Math.Ceiling(Limit * 1d / ColCount);
    }
}