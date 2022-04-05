using AnnApp.DataProvider.Entities;
using AnnApp.Services.DTO;
using AnnApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        // GET: api/<AnnController>
        [HttpGet("Announccements")]
        public async Task<IEnumerable<AnnouncementDto>> GetList()
        {
            return await _announcementService.GetAnnouncementListAsync();
        }

        // GET api/<AnnController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AnnController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AnnController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnnController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
