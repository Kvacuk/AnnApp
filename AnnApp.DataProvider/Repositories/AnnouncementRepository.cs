using AnnApp.DataProvider.Repositories;
using AnnApp.DataProvider.Context;
using AnnApp.DataProvider.Entities;
using AnnApp.DataProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnApp.DataProvider.Repositories
{
    public class AnnouncementRepository : Repository<Announcement,Guid>,IAnnouncementRepository
    {

        public AnnouncementRepository(AnnContext context) : base(context)
        {
                
        }
    }
}
