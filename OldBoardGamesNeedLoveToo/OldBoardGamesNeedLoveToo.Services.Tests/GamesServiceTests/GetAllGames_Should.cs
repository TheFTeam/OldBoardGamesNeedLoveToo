using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;
using System.Collections.Generic;

namespace OldBoardGamesNeedLoveToo.Services.Tests.GamesServiceTests
{
    [TestFixture]
    public class GetAllGames_Should
    {
        [Test]
        public void ShouldInvokeRepositoryMethodGetAllInlyOnce()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            gamesService.GetAllGames();

            gamesRepositoryMock.Verify(c => c.GetAll(), Times.Once);
        }
        [Test]
        public void ReturnResult_WhenInvokingRepositoryMethod_GetAll()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            GamesService gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            var expectedResultCollection = new List<Game>()
            {
                new Game() { Name = "name1" },
                new Game() { Name = "name2" }
            };

            gamesRepositoryMock.Setup(c => c.GetAll()).Returns(expectedResultCollection);

            IEnumerable<Game> gameResult = gamesService.GetAllGames();

            Assert.That(gameResult, Is.EqualTo(expectedResultCollection));
        }

        [Test]
        public void ShouldReturnCorrectValueType()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            var games = gamesService.GetAllGames();

            Assert.That(games, Is.InstanceOf<IEnumerable<Game>>());
        }

        [Test]
        public void ReturnNull_WhenReposityMethodGetAll_ReturnsNull()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            gamesRepositoryMock.Setup(c => c.GetAll()).Returns(() =>
            {
                return null;
            });

            IEnumerable<Game> gameResult = gamesService.GetAllGames();

            Assert.IsNull(gameResult);
        }
    }
}
