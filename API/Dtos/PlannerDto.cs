using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PlannerDto
    {
        [Required]
        public string Id { get; set; }

        public List<PlannerItemDto> Items { get; set; }
    }
}
