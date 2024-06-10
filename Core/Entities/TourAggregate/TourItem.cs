using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.TourAggregate
{
    public class TourItem : BaseEntity
    {
        public TourItem(ExhibitItemToured exhibitItemToured, int price)
        {
            ExhibitItemToured = exhibitItemToured;
            Price = price;
           
        }

        public TourItem()
        {

        }

        public ExhibitItemToured ExhibitItemToured { get; set; }
        public int Price { get; set; }

    }
}
