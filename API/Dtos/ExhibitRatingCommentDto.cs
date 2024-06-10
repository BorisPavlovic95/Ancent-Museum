namespace API.Dtos
{
    public class ExhibitRatingCommentDto
    {
        public int ExhibitsId { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public int TourId { get; set; }
    }
}
