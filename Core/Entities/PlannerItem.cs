using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class PlannerItem
    {
        public int Id { get; set; }

        public string ExhibitName { get; set; }

        public decimal Price { get; set; }


        public string PictureUrl { get; set; }

        public string Type { get; set; }
    }
}
