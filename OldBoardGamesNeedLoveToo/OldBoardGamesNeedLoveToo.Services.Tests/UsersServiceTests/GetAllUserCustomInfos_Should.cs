using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Services.Tests.UsersServiceTests
{
    [TestFixture]
    public class GetAllUserCustomInfos_Should
    {
        [Test]
        public void Invoke_TheRepositoryMethodGetAll_Once()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            IEnumerable<UserCustomInfo> usersResult = usersService.GetAllUserCustomInfos();

            //Assert
            usersRepositoryMock.Verify(u => u.GetAll(), Times.Once);
        }

        [Test]
        public void ReturnResult_WhenInvokingRepositoryMethod_GetAll()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            IEnumerable<UserCustomInfo> expectedResultCollection = new List<UserCustomInfo>();

            usersRepositoryMock.Setup(c => c.GetAll()).Returns(() =>
            {
                return expectedResultCollection;
            });

            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            IEnumerable<UserCustomInfo> actualResultUsersCollection = usersService.GetAllUserCustomInfos();

            //Assert
            Assert.That(actualResultUsersCollection, Is.EqualTo(expectedResultCollection));
        }

        [Test]
        public void ReturnResultOfCorrectType()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            usersRepositoryMock.Setup(c => c.GetAll()).Returns(() =>
            {
                IEnumerable<UserCustomInfo> expectedResultUsersCollection = new List<UserCustomInfo>();
                return expectedResultUsersCollection;
            });

            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            IEnumerable<UserCustomInfo> actualResultUsersCollection = usersService.GetAllUserCustomInfos();

            //Assert
            Assert.That(actualResultUsersCollection, Is.InstanceOf<IEnumerable<UserCustomInfo>>());
        }

        [Test]
        public void ReturnNull_WhenReposityMethodGetAll_ReturnsNull()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            usersRepositoryMock.Setup(c => c.GetAll()).Returns(() =>
            {
                return null;
            });

            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            IEnumerable<UserCustomInfo> actualResultUsersCollection = usersService.GetAllUserCustomInfos();

            //Assert
            Assert.IsNull(actualResultUsersCollection);
        }
    }
}