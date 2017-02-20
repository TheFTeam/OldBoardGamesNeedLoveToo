using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Services.Tests.UsersServiceTests
{
    [TestFixture]
    public class GetAllUserCustomInfoSellinGames_Should
    {

        [Test]
        public void ReturnNull_WhenUsernameParameterIsNull()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            IEnumerable<Game> actualCollectionOfGamesResult = usersService.GetAllUserCustomInfoSellinGames(null);

            //Assert
            Assert.IsEmpty(actualCollectionOfGamesResult);
        }

        [Test]
        public void ReturnCollectionOfSellingGames_WhenIdIsValid()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Guid userId = Guid.NewGuid();
            string applicationUserId = Guid.NewGuid().ToString();
            string username = "milena@milena.org";

            Game firstGame = new Game() { Name = "First Game" };
            Game secondGame = new Game() { Name = "Second Game" };
            Game thirdGame = new Game() { Name = "Third Game" };

            IEnumerable<Game> expectedCurrentUserSellingGames = new List<Game>()
            {
                firstGame,
                secondGame,
                thirdGame
            };

            UserCustomInfo user = new UserCustomInfo()
            {
                Id = userId,
                ApplicationUserId = applicationUserId,
                Username = username,
                Email = username,
                SellingGames = expectedCurrentUserSellingGames.ToList()
            };

            IEnumerable<UserCustomInfo> users = new List<UserCustomInfo>()
            {
                user
            };

            usersRepositoryMock.Setup(u => u.GetAll(It.IsAny<Expression<Func<UserCustomInfo, bool>>>())).Returns(users);

            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            var actualCollectionOfGamesResult = usersService.GetAllUserCustomInfoSellinGames(username);

            //Assert
            Assert.AreEqual(expectedCurrentUserSellingGames, actualCollectionOfGamesResult);
        }
    }
}