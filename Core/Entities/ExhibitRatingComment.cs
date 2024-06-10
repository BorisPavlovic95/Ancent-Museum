using Core.Entities.Identity;
using Core.Entities.TourAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ExhibitRatingComment : BaseEntity
    {
        public int ExhibitsId { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        // Navigation properties
        public Exhibits Exhibits { get; set; }
        public AppUser AppUser { get; set; }
        public Tour Tour { get; set; }

        public int TourId { get; set; }
    }
}
