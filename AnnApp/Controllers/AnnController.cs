using AnnApp.Services.DTO;
using AnnApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        [HttpGet("Announccements")]
        public async Task<IActionResult> GetAnnouncementsList()
        {
            var list = await _announcementService.GetAnnouncementListAsync();
            return Ok(list);
        }

        /// Getting announcement by Id
        [HttpGet("Announcement/{AnnId}")]
        public async Task<IActionResult> GetAnnouncementById(string AnnId)
        {
            var announcement = await _announcementService.GetAnnouncementByIdAsync(AnnId);
            return Ok(announcement);
        }

        /// Allows you to add a new announcement.
        [HttpPost("Announcement")]
        public async Task<IActionResult> AddNewAnnoucement(string title, string description)
        {
            var addedAnnouncement = await _announcementService.AddAnnouncementAsync(title,description);
            return Ok(addedAnnouncement);
        }

        /// Allows you to edit a announcement.
        [HttpPut("Announcement/{id}")]
        public async Task<IActionResult> EditAnnouncement(string id, string title,string description)
        {
            var res = await _announcementService.EditAnnouncementAsync(id,title,description);
            return Ok(res);
        }

        /// Allows you to Remove a announcement.
        [HttpDelete("Announcement/{Id}")]
        public async Task<IActionResult> RemoveAnnouncement(string Id)
        {
            await _announcementService.DeleteAnnouncementAsync(Id);
            return Ok("Announcement successfully removed");
        }
    }
}
