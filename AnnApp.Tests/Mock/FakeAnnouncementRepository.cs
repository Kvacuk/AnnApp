using AnnApp.DataProvider.Entities;
using AnnApp.DataProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnApp.Tests.Mock
{
    public class FakeAnnouncementRepository : IAnnouncementRepository
    {
        public List<Announcement> Announcements = new List<Announcement>();
        public Task CreateAsync(Announcement item)
        {
            Announcements.Add(item);
            return Task.CompletedTask;
        }

        public void Delete(Announcement item)
        {
            Announcements.Remove(item);
        }

        public Task DeleteByIdAsync(string id)
        {
            Announcements.RemoveAt(Announcements.IndexOf(Announcements.FirstOrDefault(x => x.Id == id)));
            return Task.CompletedTask;
        }

        public Task<Announcement> GetItemAsync(string id)
        {
            return Task.FromResult(Announcements.FirstOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<Announcement>> ListItemsAsync()
        {
            return Task.FromResult(Announcements.Select(x=>x));
        }

        public Task SaveAsync()
        {
            return Task.CompletedTask;
        }

        public void Update(Announcement model)
        {
            var index = Announcements.IndexOf(Announcements.FirstOrDefault(x => x.Id == model.Id));
            Announcements[index] = model;
        }
    }
}
