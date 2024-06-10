using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Planner
    {
        public Planner(string id)
        {
            Id = id;
        }

        public Planner()
        {

        }

        public string Id { get; set; }
        public List<PlannerItem> Items { get; set; } = new List<PlannerItem>();
    }
}
