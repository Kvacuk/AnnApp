using AnnApp.Services.DTO;

namespace AnnApp.Services.Interfaces
{
    public interface IAnnouncementService
    {
        Task<IEnumerable<AnnouncementDto>> GetAnnouncementListAsync();
        Task<AnnouncementDto> GetAnnouncementByIdAsync(string Id);
        Task<AnnouncementDto> AddAnnouncementAsync(string title,string description);
        Task<AnnouncementDto> EditAnnouncementAsync(string id, string title, string description);
        Task DeleteAnnouncementAsync(string Id);
    }
}
