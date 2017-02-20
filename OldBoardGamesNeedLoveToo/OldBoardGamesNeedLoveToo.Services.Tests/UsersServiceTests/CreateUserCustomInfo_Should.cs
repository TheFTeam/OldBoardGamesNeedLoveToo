using Moq;
using NUnit.Framework;
using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBoardGamesNeedLoveToo.Services.Tests.UsersServiceTests
{
    [TestFixture]
    public class CreateUserCustomInfo_Should
    {
        [Test]
        public void ReturnObjectOfTypeUserCustomInfo()
        {
            //Arrange
            var usersRepositoryMock = new Mock<IRepository<UserCustomInfo>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
           
            UsersService usersService = new UsersService(usersRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            UserCustomInfo userResult = usersService.CreateUserCustomInfo();

            //Assert
            Assert.That(userResult, Is.InstanceOf<UserCustomInfo>());
        }
    }
}
