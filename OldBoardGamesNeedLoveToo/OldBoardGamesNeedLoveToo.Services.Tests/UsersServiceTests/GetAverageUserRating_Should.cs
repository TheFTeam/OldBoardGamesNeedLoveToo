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
    public class GetAverageUserRating_Should
    {
        [Test]
        public void Throw_WhenParameterUsernameIsNull()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);
            string username = null;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => usersService.GetAverageUserRating(username));
        }

        [Test]
        public void Throw_WhenUserToGetAverageratingIsNotFoundAndIsNull()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);
            string username = "maria@maria.com";
            
            usersRepositoryMock.Setup(u => u.GetAll(It.IsAny<Expression<Func<UserCustomInfo, bool>>>())).Returns(new List<UserCustomInfo>());

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => usersService.GetAverageUserRating(username));
        }

        [Test]
        public void ReturnValidTypeResultWhenParameterIsValidAndUserExists()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);
            string username = "maria@maria.com";
            double averageRatingValueOfUser = 22.67;

            UserCustomInfo user = new UserCustomInfo()
            {
                Username = username,
                AverageRatingResult = averageRatingValueOfUser                
            };

            IEnumerable<UserCustomInfo> expectedCollection = new List<UserCustomInfo>() { user };
            usersRepositoryMock.Setup(u => u.GetAll(It.IsAny<Expression<Func<UserCustomInfo, bool>>>())).Returns(expectedCollection);
            UserCustomInfo userToGetAverageRating = expectedCollection.FirstOrDefault();

            //Act 
            double actualResult = usersService.GetAverageUserRating(username);

            //Assert
            Assert.AreEqual(userToGetAverageRating.AverageRatingResult, actualResult);
        }
    }
}