using AnnApp.DataProvider.Entities;
using AnnApp.DataProvider.Interfaces;
using AnnApp.Services.Infrastracture;
using AnnApp.Services.Interfaces;
using AnnApp.Services.Services;
using AnnApp.Tests.Mock;
using AutoMapper;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AnnApp.Tests.Services.Test
{
    public class AnnouncementServiceTests
    {
        public IAnnouncementService _announcementService;
        public IAnnouncementRepository _announcementRepository;
        public IMapper _mapper;
        public IUnitOfWork _context;
        public Announcement _correctAnnouncement;

        public AnnouncementServiceTests()
        {
            _announcementRepository = new FakeAnnouncementRepository();
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.SaveAsync());
            uow.Setup(x => x.AnnouncementRepository).Returns(_announcementRepository);
            _context = uow.Object;

            var MappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            _mapper = MappingConfig.CreateMapper();

            _announcementService = new AnnouncementService(_context, _mapper);

            _correctAnnouncement = new Announcement()
            {
                Id = "0659acee-760e-4010-ad6d-df2a677b12d1",
                Title = "Test",
                Description = "LongTestText",
                CreatedDate = DateTime.Parse("05.04.2022")
            };
        }

        #region Add Announcement
        [Fact]
        public async Task AddingAnnouncementTest()
        {
            //Arrange
            var title = "test";
            var description = "TestDescription";
            //Act
            var actual = await _announcementService.AddAnnouncementAsync(title, description);

            //Assert
            Assert.Equal(title, actual.Title);
        }

        #endregion
        #region GetAnnouncements
        [Fact]
        
        public async Task GetAnnouncementList()
        {
            //Arrange 
            await _context.AnnouncementRepository.CreateAsync(_correctAnnouncement);

            //Act 
            var actual = _announcementService.GetAnnouncementListAsync().Result.Count();

            //Arrange
            Assert.Equal(1, actual);
        }

        [Fact]
        public async Task GetAnnouncementById()
        {

            //Arrange 
            await _context.AnnouncementRepository.CreateAsync(_correctAnnouncement);
            var expectedId = "0659acee-760e-4010-ad6d-df2a677b12d1";

            //Act
            var actual = await _announcementService.GetAnnouncementByIdAsync(_correctAnnouncement.Id);

            //Assert
            Assert.Equal(expectedId, actual.Id);
        }


        #endregion

        #region EditAnnouncement
         [Fact]
         public async Task EditAnnouncement()
        {
            //Arrange
            await _context.AnnouncementRepository.CreateAsync(_correctAnnouncement);
            var expectedTitle = " Expected Title";
            var expectedDescription = "Expected Description";

            //Act
            var actual = await _announcementService.EditAnnouncementAsync(_correctAnnouncement.Id, expectedTitle, expectedDescription);

            //Assert
            Assert.Equal(expectedTitle, actual.Title);
            Assert.Equal(expectedDescription, actual.Description);
        }
        #endregion

        #region RemoveAnnouncement

        [Fact]
        public async Task RemoveAnnouncement()
        {
            //Arrange
            await _context.AnnouncementRepository.CreateAsync(_correctAnnouncement);


            //Act
            await _announcementService.DeleteAnnouncementAsync(_correctAnnouncement.Id);
            var actualCount = _context.AnnouncementRepository.ListItemsAsync().Result.Count();
            //Assert
            Assert.Equal(0, actualCount);
        }
        #endregion


    }
}
