using System.ComponentModel.DataAnnotations;

namespace AnnApp.DataProvider.Entities
{
    public class Announcement
    {
        [Key]
        public string Id {get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
