using AnnApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnnApp.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        public AnnController(IAnnouncementService announcement)
        {
            _announcementService = announcement;
        }

        /// Announcements list
        [HttpGet]
        public async Task<IActionResult> GetAnnouncementsList()
        {
            var list = await _announcementService.GetAnnouncementListAsync();
            return Ok(list);
        }

        /// Getting announcement by Id
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAnnouncementById(string Id)
        {
            var announcement = await _announcementService.GetAnnouncementByIdAsync(Id);
            return Ok(announcement);
        }

        /// Allows you to add a new announcement.
        [HttpPost]
        public async Task<IActionResult> AddNewAnnoucement(string title, string description)
        {
            var addedAnnouncement = await _announcementService.AddAnnouncementAsync(title, description);
            return Ok(addedAnnouncement);
        }

        /// Allows you to edit a announcement.
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAnnouncement(string id, string title, string description)
        {
            var res = await _announcementService.EditAnnouncementAsync(id, title, description);
            return Ok(res);
        }

        /// Allows you to Remove a announcement.
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveAnnouncement(string Id)
        {
            await _announcementService.DeleteAnnouncementAsync(Id);
            return Ok("Announcement successfully removed");
        }
    }
}
