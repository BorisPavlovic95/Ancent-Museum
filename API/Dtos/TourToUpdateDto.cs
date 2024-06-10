using Core.Entities.TourAggregate;

namespace API.Dtos
{
    public class TourToUpdateDto
    {
        public string UserEmail { get; set; }
        public DateTime TourDate { get; set; }
        public Address UserData { get; set; }
        public IReadOnlyList<TourItemDto> TourItems { get; set; }
        public int Subtotal { get; set; }
        public string Status { get; set; }
    }
}
