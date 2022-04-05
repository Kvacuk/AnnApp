using AnnApp.DataProvider.Entities;
using AnnApp.DataProvider.Interfaces;
using AnnApp.Services.DTO;
using AnnApp.Services.Interfaces;
using AutoMapper;
using System.Text.RegularExpressions;

namespace AnnApp.Services.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public AnnouncementService(IUnitOfWork context, IMapper mapper)
        {
            _database = context;
            _mapper = mapper;
        }
        public async Task<AnnouncementDto> AddAnnouncementAsync(AnnouncementDto dto)
        {

            if (dto != null)
            {
                var item = _mapper.Map<Announcement>(dto);
                item.Id = Guid.NewGuid();
                item.CreatedDate = DateTime.UtcNow;

                await _database.AnnouncementRepository.CreateAsync(item);
                await _database.SaveAsync();

                return _mapper.Map<AnnouncementDto>(item);
            }
            else
            {
                throw new ArgumentException("Didn't fill require fields");
            }
        }

        public async Task DeleteAnnouncementAsync(string Id)
        {
            var expressionForGuid = @"^\w8-\w4-\w4-\w4-\w12$";
            if (!String.IsNullOrWhiteSpace(Id) && Regex.IsMatch(Id, expressionForGuid))
            {
                await _database.AnnouncementRepository.DeleteByIdAsync(Guid.Parse(Id));
            }
            else
            {
                throw new ArgumentException("Wrong filled Id`s format");
            }
        }

        public async Task<AnnouncementDto> EditAnnouncementAsync(AnnouncementDto dto)
        {
            var item = await GetAnnouncementByIdAsync(dto.Id);
            item.Title = dto.Title;
            item.Description = dto.Description;
            var tmpItem = _mapper.Map<Announcement>(item);
            _database.AnnouncementRepository.Update(tmpItem);
            await _database.SaveAsync();
            return item;
        }

        public async Task<AnnouncementDto> GetAnnouncementByIdAsync(string Id)
        {
            var expressionForGuid = @"^\w8-\w4-\w4-\w4-\w12$";
            if (!String.IsNullOrWhiteSpace(Id) && Regex.IsMatch(Id, expressionForGuid))
            {
                var paresedId = Guid.Parse(Id);
                var item = await _database.AnnouncementRepository.GetItemAsync(paresedId);
                if (item != null)
                {
                    var res = _mapper.Map<AnnouncementDto>(item);
                    res.SimilarAnnouncements = SimilarAnnouncements(res);
                    return res;
                }
                else
                    throw new ArgumentException("Announcement with current Id wasn't found");
            }
            else
            {
                throw new ArgumentException("Wrong filled Id`s format");
            }
        }

        public async Task<IEnumerable<AnnouncementDto>> GetAnnouncementListAsync()
        {
            var list = await _database.AnnouncementRepository.ListItemsAsync();
            return _mapper.Map<IEnumerable<AnnouncementDto>>(list);

        }

        private IEnumerable<AnnouncementDto> SimilarAnnouncements(AnnouncementDto dto)
        {
            string[] dtoArr = dto.Title.Split(" ");
            var list = GetAnnouncementListAsync().Result;
            int counter = 0;
            foreach (var item in list)
            {
                if (counter == 3)
                    yield break;
                string[] itemArr = item.Title.Split(" ");
                foreach (var item2 in dtoArr)
                    foreach (var item3 in itemArr)
                    {
                        if (item2.Equals(item3))
                        {
                            yield return item;
                            counter++;
                            goto End;
                        }
                    }
                End:;
            }
        }
    }
}
