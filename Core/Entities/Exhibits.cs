using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Exhibits : BaseEntity
    {
        public string Name { get; set; }
       
        public string Century { get; set; }
        public string Period { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public int TourTime { get; set; }
        public int Price { get; set; }
        public ExhibitCulture ExhibitCulture { get; set; }
        public int ExhibitCultureId { get; set; }
        public ExhibitType ExhibitType { get; set; } 
        public int ExhibitTypeId { get; set; }
        public ICollection<ExhibitRatingComment>? RatingsComments { get; set; }
    }
}

