using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.TourAggregate
{
    public class ExhibitItemToured
    {
        public ExhibitItemToured()
        {
        }

        public ExhibitItemToured(int exhibitItemId, string exhibitName, string pictureUrl)
        {
            ExhibitItemId = exhibitItemId;
            ExhibitName = exhibitName;
            PictureUrl = pictureUrl;
        }

        
        public int ExhibitItemId { get; set; }
        public string ExhibitName { get; set; }
        public string PictureUrl { get; set; }
    }
}
