using System;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Services.Tests.UsersServiceTests
{
    [TestFixture]
    public class GetUserCustomInfoById_Should
    {
        [Test]
        public void ReturnNull_WhenIdParameterIsNull()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            UserCustomInfo userResult = usersService.GetUserCustomInfoById(null);

            //Assert
            Assert.IsNull(userResult);
        }

        [Test]
        public void ReturnUserCustomInfo_WhenIdIsValid()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Guid userId = Guid.NewGuid();
            string applicationUserId = Guid.NewGuid().ToString();
            string username = "milena@milena.org";
            UserCustomInfo user = new UserCustomInfo()
            {
                Id = userId,
                ApplicationUserId = applicationUserId,
                Username = username,
                Email = username

            };

            usersRepositoryMock.Setup(c => c.GetById(userId)).Returns(user);

            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            UserCustomInfo userResult = usersService.GetUserCustomInfoById(userId);

            //Assert
            Assert.AreSame(user, userResult);
        }
    }
}