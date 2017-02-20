using System;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Services.Tests.GamesServiceTests
{
    [TestFixture]
    public class AddGames_Should
    {
        [Test]
        public void ShouldThrow_WhenGameIsNull()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => gamesService.AddGame(null));
        }
        [Test]
        public void ShouldInvokeRepositoryMethodAddOnce_WhenParametersAreValid()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            gamesService.AddGame(new Game());

            gamesRepositoryMock.Verify(x => x.Add(It.IsAny<Game>()), Times.Once);
        }
        [Test]
        public void ShouldInvokeUnitOfWorkOnlyOnce_WhenParametersAreValid()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            gamesService.AddGame(new Game());

            unitOfWorkMock.Verify(x => x.Commit(), Times.Once);
        }
    }
}
