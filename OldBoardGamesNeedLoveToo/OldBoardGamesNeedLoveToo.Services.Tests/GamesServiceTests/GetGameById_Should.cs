using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;
using System;
using System.Collections.Generic;

namespace OldBoardGamesNeedLoveToo.Services.Tests.GamesServiceTests
{
    [TestFixture]
    public class GetGameById_Should
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
        public void InvokeRepositoryMethodGetByIdOnce_WhenProvidedCorrectParameters()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            var id = 3;

            gamesRepositoryMock.Setup(g => g.GetById(id));

            gamesService.GetGameById(id);

            gamesRepositoryMock.Verify(c => c.GetById(id), Times.Once);
        }

        [Test]
        public void Return_WhenIdIsCorrect()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            var expectedReturnedGame = new Game() { Name = "game1" };

            var id = 3;

            gamesRepositoryMock.Setup(g => g.GetById(id)).Returns(expectedReturnedGame);

            var actualReturnedGame=gamesService.GetGameById(id);

            Assert.AreSame(expectedReturnedGame, actualReturnedGame);
        }

        [Test]
        public void ReturnCorrectType_WhenIdIsCorrect()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            var expectedReturnedGame = new Game() { Name = "game1" };

            var id = 3;

            gamesRepositoryMock.Setup(g => g.GetById(id)).Returns(expectedReturnedGame);

            var actualReturnedGame = gamesService.GetGameById(id);

            Assert.That(actualReturnedGame, Is.InstanceOf<Game>());
        }
    }
}
