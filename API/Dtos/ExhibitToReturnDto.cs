using Core.Entities;
using System.Collections;

namespace API.Dtos
{
    public class ExhibitToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public string Century { get; set; }
        
        public string Period { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public int TourTime { get; set; }
        public int Price { get; set; }
        public string ExhibitCulture { get; set; }
        public string ExhibitType { get; set; }

        public ICollection<ExhibitRatingCommentDto> RatingsComments { get; set; }
    }
}
