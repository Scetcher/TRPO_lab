using System;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Profiles;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork.Interfaces;
using Moq;
using NUnit.Framework;

namespace BLL.Tests
{
    public class RegionServiceTest
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IMapper> _mockMapper;

        [SetUp]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
        }

        [Test]
        public void RegionServiceCtor_NullConstructionParams_ExceptionThrows()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;
            IMapper nullMapper = null;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new RegionService(nullUnitOfWork, nullMapper));
        }

        [Test]
        public void RegionServiceRemoveRegion_UserIsUser_ThrowMethodAccessException()
        {
            // Arrange
            var user = new User(Guid.NewGuid(), Guid.NewGuid().ToString());
            Authorization.SetUser(user);

            IRegionService regionService = new RegionService(_mockUnitOfWork.Object, _mockMapper.Object);

            // Act
            // Assert
            Assert.ThrowsAsync<MethodAccessException>(() => regionService.RemoveRegion(Guid.NewGuid()));
        }

        [Test]
        public async Task GetRegionFromDAL_CorrectMappingToRegionDTO()
        {
            // Arrange
            var user = new Administrator(Guid.NewGuid(), Guid.NewGuid().ToString());
            Authorization.SetUser(user);

            var itemId = Guid.NewGuid();
            var regionServiceService = GetRegionService(itemId);

            // Act
            var actualRegionDto = await regionServiceService.GeteRegionAsync(itemId);

            // Assert
            Assert.True(
                actualRegionDto.Id == itemId
                && actualRegionDto.Name == "testName"
            );
        }

        private IRegionService GetRegionService(Guid itemId)
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedRegion = new Region()
            {
                Id = itemId,
                Name = "testName"
            };
            var mockDbSet = new Mock<IRepository<Region>>();

            mockDbSet.Setup(mock => mock.GetByIdAsync(itemId)).ReturnsAsync(expectedRegion);

            mockContext
                .Setup(context =>
                    context.Repository<Region>())
                .Returns(mockDbSet.Object);
            mockContext.Setup(mock => mock.GetByIdAsync<Region>(itemId)).ReturnsAsync(expectedRegion);
            var cfg = new MapperConfiguration(a => a.AddProfile(new RegionProfile()));
            IRegionService regionService = new RegionService(mockContext.Object, new Mapper(cfg));

            return regionService;
        }

    }
}