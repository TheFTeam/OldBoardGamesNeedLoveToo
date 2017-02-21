using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;


namespace OldBoardGamesNeedLoveToo.Services.Tests.UsersServiceTests
{
    [TestFixture]
    public class UpdateUserCustomInfoWithRatingValue_Should
    {
        [Test]
        public void Throw_WhenParameterUsernameIsNull()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);
            int? ratingValue = null;
            string username = null;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => usersService.UpdateUserCustomInfoWithRatingValue(ratingValue, username));
        }
        
        [Test]
        public void InvokesRepositoryMethodGetAll_WhenParametersAreValid()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);
            int? ratingValue = 3;
            string username = "maria@maria.com";

            IEnumerable<UserCustomInfo> expectedUsersCollection = new List<UserCustomInfo>()
            {
                new UserCustomInfo()
                {
                    Username = username
                }
            };

            usersRepositoryMock.Setup(u => u.GetAll(It.IsAny<Expression<Func<UserCustomInfo, bool>>>())).Returns(expectedUsersCollection);

           //Act
            usersService.UpdateUserCustomInfoWithRatingValue(ratingValue, username);

            //Assert
            usersRepositoryMock.Verify(u => u.GetAll(It.IsAny<Expression<Func<UserCustomInfo, bool>>>()), Times.Once);
        }

        [Test]
        public void InvokesRepositoryMethodUpdate_WhenParametersAreValid()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);
            int? ratingValue = 3;
            string username = "maria@maria.com";

            UserCustomInfo userToUpdate = new UserCustomInfo()
            {
                Username = username
            };

            IEnumerable<UserCustomInfo> expectedUsersCollection = new List<UserCustomInfo>()
            {
                userToUpdate
            };

            usersRepositoryMock.Setup(u => u.GetAll(It.IsAny<Expression<Func<UserCustomInfo, bool>>>())).Returns(expectedUsersCollection);

            //Act
            usersService.UpdateUserCustomInfoWithRatingValue(ratingValue, username);

            //Assert
            usersRepositoryMock.Verify(u => u.Update(userToUpdate), Times.Once);
        }
    }
}