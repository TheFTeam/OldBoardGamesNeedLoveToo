using System;
using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.AccountInfoPresenterTests
{
    [TestFixture]
    public class View_OnGetData_Should
    {
        [Test]
        public void AddUsersToViewModel_WhenOnGetDataEventIsRaised()
        {
            //Arrange
            var viewMock = new Mock<IAccountInfoView>();
            viewMock.Setup(v => v.Model).Returns(new UsersViewModel());
            var usersServiceMock = new Mock<IUsersService>();
            var firstUserId = Guid.NewGuid();

            var exprectedUsersCollection = new List<UserCustomInfo>()
            {
                new UserCustomInfo()
                {
                    Id = firstUserId,
                    Username = "maria@maria.com"
                }
            };
            usersServiceMock.Setup(x => x.GetAllUserCustomInfos()).Returns(exprectedUsersCollection);
            var expectedUser = exprectedUsersCollection.Where(u => u.Id == firstUserId);

            AccountInfoPresenter accountInfoPresenter = new AccountInfoPresenter(viewMock.Object, usersServiceMock.Object);

            //Act
            viewMock.Raise(v => v.OnGetData += null, null, new UserDetailsByIdEventArgs(firstUserId));

            // Assert
            Assert.AreEqual(expectedUser, viewMock.Object.Model.Users);
        }
    }
}