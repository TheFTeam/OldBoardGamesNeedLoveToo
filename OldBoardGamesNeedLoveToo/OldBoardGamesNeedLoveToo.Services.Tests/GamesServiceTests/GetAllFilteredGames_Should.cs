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
    public class GetAllFilteredGames_Should
    {
        [Test]
        public void InvokeRepositoryMethodGetAllOnce()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            decimal minPrice = 1;
            decimal maxPrice = 2;
            int minNumberOfPlayers = 2;
            int maxNumberOfPlayers = 4;
            int minPlayersAge = 2;
            int maxPlayersAge = 20;
            Guid categoryId = Guid.Empty;
            ConditionType condition = ConditionType.Excellent;
            DateTime releasedDateFrom = DateTime.Now;
            DateTime releasedDateTo = DateTime.Now;

            gamesRepositoryMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Game, bool>>>()));

            gamesService.GetAllFilteredGames(minPrice, maxPrice, minNumberOfPlayers, maxNumberOfPlayers, minPlayersAge, maxPlayersAge, categoryId, condition, releasedDateFrom, releasedDateTo);

            gamesRepositoryMock.Verify(x => x.GetAll(It.IsAny<Expression<Func<Game, bool>>>()), Times.Once);
        }

        [Test]
        public void Return()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            decimal minPrice = 1;
            decimal maxPrice = 2;
            int minNumberOfPlayers = 2;
            int maxNumberOfPlayers = 4;
            int minPlayersAge = 2;
            int maxPlayersAge = 20;
            Guid categoryId = Guid.Empty;
            ConditionType condition = ConditionType.Excellent;
            DateTime releasedDateFrom = DateTime.Now;
            DateTime releasedDateTo = DateTime.Now;

            var expectedReturnedGames = new List<Game>()
            {
                new Game()
                {
                    Name ="game1"
                },
                new Game()
                {
                    Name = "game2"
                }
            };

            gamesRepositoryMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Game, bool>>>())).Returns(expectedReturnedGames);

            var actualReturnedGames = gamesService.GetAllFilteredGames(minPrice, maxPrice, minNumberOfPlayers, maxNumberOfPlayers, minPlayersAge, maxPlayersAge, categoryId, condition, releasedDateFrom, releasedDateTo);

            Assert.AreSame(expectedReturnedGames, actualReturnedGames);
        }

        [Test]
        public void ReturnCorrectType()
        {
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            decimal minPrice = 1;
            decimal maxPrice = 2;
            int minNumberOfPlayers = 2;
            int maxNumberOfPlayers = 4;
            int minPlayersAge = 2;
            int maxPlayersAge = 20;
            Guid categoryId = Guid.Empty;
            ConditionType condition = ConditionType.Excellent;
            DateTime releasedDateFrom = DateTime.Now;
            DateTime releasedDateTo = DateTime.Now;

            var expectedReturnedGames = new List<Game>()
            {
                new Game()
                {
                    Name ="game1"
                },
                new Game()
                {
                    Name = "game2"
                }
            };

            gamesRepositoryMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Game, bool>>>())).Returns(expectedReturnedGames);

            var actualReturnedGames = gamesService.GetAllFilteredGames(minPrice, maxPrice, minNumberOfPlayers, maxNumberOfPlayers, minPlayersAge, maxPlayersAge, categoryId, condition, releasedDateFrom, releasedDateTo);

            Assert.That(actualReturnedGames,Is.InstanceOf<IEnumerable<Game>>());
        }
    }
}
