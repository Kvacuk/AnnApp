using AnnApp.DataProvider.Context;
using AnnApp.DataProvider.Entities;
using AnnApp.DataProvider.Interfaces;

namespace AnnApp.DataProvider.Repositories
{
    public class AnnouncementRepository : Repository<Announcement, string>, IAnnouncementRepository
    {

        public AnnouncementRepository(AnnContext context) : base(context)
        {

        }
    }
}
