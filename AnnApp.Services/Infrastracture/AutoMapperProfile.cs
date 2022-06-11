using AnnApp.DataProvider.Entities;
using AnnApp.Services.DTO;
using AutoMapper;

namespace AnnApp.Services.Infrastracture
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AnnouncementDto, Announcement>();

            CreateMap<Announcement, AnnouncementDto>()
                .ForMember(x => x.SimilarAnnouncements, opt => opt.Ignore());
        }
    }
}
