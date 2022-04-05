using AnnApp.Services.DTO;

namespace AnnApp.Services.Interfaces
{
    public interface IAnnouncementService
    {
        Task<IEnumerable<AnnouncementDto>> GetAnnouncementListAsync();
        Task<AnnouncementDto> GetAnnouncementByIdAsync(string Id);
        Task<AnnouncementDto> AddAnnouncementAsync(AnnouncementDto dto);
        Task<AnnouncementDto> EditAnnouncementAsync(AnnouncementDto dto);
        Task DeleteAnnouncementAsync(string Id);
    }
}
