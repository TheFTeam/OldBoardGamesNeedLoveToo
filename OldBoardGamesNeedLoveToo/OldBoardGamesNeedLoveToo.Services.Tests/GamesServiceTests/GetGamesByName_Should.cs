using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;
using System.Linq.Expressions;
using System;

namespace OldBoardGamesNeedLoveToo.Services.Tests.GamesServiceTests
{
    [TestFixture]
    public class GetGamesByName_Should
    {
        [Test]
        public void InvokeRepositoryGetAll_WhenNameIsEmpty()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var name = string.Empty;

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            gamesService.GetGamesByName(name);

            gamesRepositoryMock.Verify(g => g.GetAll(), Times.Once);
        }
        [Test]
        public void InvokeRepositoryGetAll_WhenNameIsNull()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            string name = null;

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            gamesService.GetGamesByName(name);

            gamesRepositoryMock.Verify(g => g.GetAll(), Times.Once);
        }
        [Test]
        public void Return_WhenNameIsNull()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            string name = null;
            var expectedReturnedGames = new List<Game>()
            {
                new Game() { Name = "game1" },
                new Game() { Name = "game2" }
            };
            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            gamesRepositoryMock.Setup(x => x.GetAll()).Returns(expectedReturnedGames);

            var actualReturnedGames = gamesService.GetGamesByName(name);

            Assert.AreSame(expectedReturnedGames, actualReturnedGames);

        }
        [Test]
        public void Return_WhenNameIsEmpty()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            string name = string.Empty;
            var expectedReturnedGames = new List<Game>()
            {
                new Game() { Name = "game1" },
                new Game() { Name = "game2" }
            };
            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            gamesRepositoryMock.Setup(x => x.GetAll()).Returns(expectedReturnedGames);

            var actualReturnedGames = gamesService.GetGamesByName(name);

            Assert.AreSame(expectedReturnedGames, actualReturnedGames);

        }
        [Test]
        public void ReturnCorrectType_WhenNameIsNull()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            string name = null;
            var expectedReturnedGames = new List<Game>()
            {
                new Game() { Name = "game1" },
                new Game() { Name = "game2" }
            };
            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            gamesRepositoryMock.Setup(x => x.GetAll()).Returns(expectedReturnedGames);

            var actualReturnedGames = gamesService.GetGamesByName(name);

            Assert.That(actualReturnedGames,Is.InstanceOf<IEnumerable<Game>>());

        }
        [Test]
        public void ReturnCorrectType_WhenNameIsEmpty()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            string name = string.Empty;
            var expectedReturnedGames = new List<Game>()
            {
                new Game() { Name = "game1" },
                new Game() { Name = "game2" }
            };
            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            gamesRepositoryMock.Setup(x => x.GetAll()).Returns(expectedReturnedGames);

            var actualReturnedGames = gamesService.GetGamesByName(name);

            Assert.That(actualReturnedGames, Is.InstanceOf<IEnumerable<Game>>());

        }
        [Test]
        public void InvokeRepositoryGetAll_WhenNameIsNotNullOrEmpty()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var name = "notNullOrEmpty";

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);
            gamesRepositoryMock.Setup(r => r.GetAll(It.IsAny<Expression<Func<Game, bool>>>()));

            gamesService.GetGamesByName(name);

            gamesRepositoryMock.Verify(g => g.GetAll(It.IsAny<Expression<Func<Game, bool>>>()), Times.Once);
        }
        [Test]
        public void Return_WhenNameIsNotNullOrEmpty()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            string name = "notNullOrEmpty";
            var expectedReturnedGames = new List<Game>()
            {
                new Game() { Name = "game1" },
                new Game() { Name = "game2" }
            };
            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            gamesRepositoryMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Game, bool>>>())).Returns(expectedReturnedGames);

            var actualReturnedGames = gamesService.GetGamesByName(name);

            Assert.AreSame(expectedReturnedGames, actualReturnedGames);

        }
        [Test]
        public void ReturnCorrectType_WhenNameIsNotNullOrEmpty()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            string name = "notNullOrEmpty";
            var expectedReturnedGames = new List<Game>()
            {
                new Game() { Name = "game1" },
                new Game() { Name = "game2" }
            };
            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            gamesRepositoryMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Game, bool>>>())).Returns(expectedReturnedGames);

            var actualReturnedGames = gamesService.GetGamesByName(name);

            Assert.That(actualReturnedGames, Is.InstanceOf<IEnumerable<Game>>());

        }

    }
}
