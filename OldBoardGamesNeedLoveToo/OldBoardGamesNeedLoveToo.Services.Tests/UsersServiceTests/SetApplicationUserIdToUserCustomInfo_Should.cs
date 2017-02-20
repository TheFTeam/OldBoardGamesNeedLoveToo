using System;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Services.Tests.UsersServiceTests
{
    [TestFixture]
    public class SetApplicationUserIdToUserCustomInfo_Should
    {
        [Test]
        public void Throw_WhenParameterUserCustomInfoIsNull()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);
            string applicationUserId = "123bz";

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => usersService.SetApplicationUserIdToUserCustomInfo(null, applicationUserId));
        }

        [Test]
        public void Throw_WhenParameterApplicationUserIdIsNull()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);
            UserCustomInfo user = new UserCustomInfo()
            {
                Username = "George"
            };
            string applicationUserId = null;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => usersService.SetApplicationUserIdToUserCustomInfo(user, applicationUserId));
        }

        [Test]
        public void InvokeRepositoryMethodUpdate_WhenParametersAreValid()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);
            UserCustomInfo user = new UserCustomInfo()
            {
                Username = "George"
            };
            string applicationUserId = "123ab";

            //Act 
             usersService.SetApplicationUserIdToUserCustomInfo(user, applicationUserId);

            //Assert
            usersRepositoryMock.Verify(x => x.Update(It.IsAny<UserCustomInfo>()), Times.Once);
        }

        [Test]
        public void InvokeUnitOfWork_WhenParametersAreValid()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);
            UserCustomInfo user = new UserCustomInfo()
            {
                Username = "George"
            };
            string applicationUserId = "123ab";

            //Act 
            usersService.SetApplicationUserIdToUserCustomInfo(user, applicationUserId);

            //Assert
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void SetRightApplicationUserIdToUserCustomInfo_WhenParametersAreValid()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);
            UserCustomInfo user = new UserCustomInfo()
            {
                Username = "George"
            };
            string applicationUserId = "123ab";

            //Act 
            usersService.SetApplicationUserIdToUserCustomInfo(user, applicationUserId);

            //Assert
            Assert.AreEqual(user.ApplicationUserId, applicationUserId);
        }
    }
}