namespace AnnApp.Services.DTO
{
    public class AnnouncementDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<AnnouncementDto> SimilarAnnouncements { get; set; }
    }
}
