using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.AdminUserPresenterTests
{
    [TestFixture]
    public class View_AdminGetAllUsers_Should
    {
        [Test]
        public void AddUsersToViewModel_WhenOnPageInitEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<IAdminUsersView>();
            viewMock.Setup(v => v.Model).Returns(new AdminUsersViewModel());

            var users = new List<UserCustomInfo>()
                {
                    new UserCustomInfo()
                    {
                        Id = Guid.NewGuid(),
                        Username = "Ivan"
                    },
                     new UserCustomInfo()
                    {
                        Id = Guid.NewGuid(),
                        Username = "Krisi"
                    },
                      new UserCustomInfo()
                    {
                        Id = Guid.NewGuid(),
                        Username = "Ogi"
                    }
                };

            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(c => c.GetAllUserCustomInfos()).Returns(users);

            AdminUserPresenter adminUsersPresenter = new AdminUserPresenter(viewMock.Object, usersServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminGetAllUsers += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(users, viewMock.Object.Model.Users);
        }
    }
}