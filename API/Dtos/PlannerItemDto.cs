using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PlannerItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ExhibitName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
