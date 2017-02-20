using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OldBoardGamesNeedLoveToo.Services.Tests.GamesServiceTests
{
    [TestFixture]
    public class GetAllGamesOfCurrentUser_Should
    {
        [Test]
        public void Throw_WhenIdIsEmpty()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentException>(() => gamesService.GetAllGamesOfCurrentUser(Guid.Empty));
        }

        [Test]
        public void Invoke_TheRepositoryMethodGetAll_Once()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var id = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            gamesRepositoryMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Game, bool>>>()));

            gamesService.GetAllGamesOfCurrentUser(id);

            gamesRepositoryMock.Verify(x => x.GetAll(It.IsAny<Expression<Func<Game, bool>>>()), Times.Once);

        }

        [Test]
        public void ReturnResult_WhenInvokingRepositoryMethod_GetAll()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var userId= Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7d");
            var gameId1 = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            var gameId2 = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7c");
            var name1 = "name1";
            var name2 = "name2";
            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            var expectedReturnedGames = new List<Game>()
            {
                new Game()
                {
                    Id =gameId1,
                    Name=name1
                },
                new Game()
                {
                    Id =gameId2,
                    Name=name2
                }
            };

            gamesRepositoryMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Game, bool>>>())).Returns(expectedReturnedGames);

            var actualReturnedGames=gamesService.GetAllGamesOfCurrentUser(userId);
            Assert.AreSame(expectedReturnedGames, actualReturnedGames);

        }

        [Test]
        public void ReturnResultAsTheCorrectType()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var userId = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7d");
            var gameId1 = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            var gameId2 = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7c");
            var name1 = "name1";
            var name2 = "name2";
            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            var expectedReturnedGames = new List<Game>()
            {
                new Game()
                {
                    Id =gameId1,
                    Name=name1
                },
                new Game()
                {
                    Id =gameId2,
                    Name=name2
                }
            };

            gamesRepositoryMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Game, bool>>>())).Returns(expectedReturnedGames);

            var actualReturnedGames = gamesService.GetAllGamesOfCurrentUser(userId);
            Assert.That(actualReturnedGames, Is.InstanceOf<IEnumerable<Game>>());

        }
    }
}
