using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;
using System;

namespace OldBoardGamesNeedLoveToo.Services.Tests.GamesServiceTests
{
    [TestFixture]
    public class UpdateGames_Should
    {
        [Test]
        public void Throw_WhenIdIsNull()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => gamesService.UpdateGame(null));
        }
        [Test]
        public void ShouldInvokeRepositoryMethodAddOnce_WhenParametersAreValid()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            gamesService.UpdateGame(new Game());

            gamesRepositoryMock.Verify(x => x.Update(It.IsAny<Game>()), Times.Once);
        }
        [Test]
        public void ShouldInvokeUnitOfWorkOnlyOnce_WhenParametersAreValid()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            gamesService.UpdateGame(new Game());

            unitOfWorkMock.Verify(x => x.Commit(), Times.Once);
        }
    }
}
