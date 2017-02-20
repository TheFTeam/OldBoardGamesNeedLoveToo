using System;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Services.Tests.UsersServiceTests
{
    [TestFixture]
    public class UpdateUserCustomInfo_Should
    {
        [Test]
        public void Throw_WhenThePassedUserCustomInfoIsNull()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => usersService.UpdateUserCustomInfo(null));
        }

        [Test]
        public void InvokeRepositoryMethodUpdateOnce_WhenThePassedUserCustomInfoIsValid()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);
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

            //Act
            usersService.UpdateUserCustomInfo(user);

            //Assert
            usersRepositoryMock.Verify(x => x.Update(It.IsAny<UserCustomInfo>()), Times.Once);
        }
    }
}