using AnnApp.DataProvider.Entities;
using AnnApp.Services.DTO;
using AutoMapper;

namespace AnnApp.Services.Infrastracture
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AnnouncementDto, Announcement>().AfterMap(
                (dto, an) =>
                {
                    an.Id = Guid.Parse(dto.Id);
                });


            CreateMap<Announcement, AnnouncementDto>().AfterMap(
                (an, dto) =>
                {
                    dto.Id = an.Id.ToString();
                })
                .ForMember(x => x.SimilarAnnouncements, opt => opt.Ignore());
        }
    }
}
