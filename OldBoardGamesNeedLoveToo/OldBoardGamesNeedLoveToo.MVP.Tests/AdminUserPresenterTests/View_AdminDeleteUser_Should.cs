﻿using System;
using System.Web.ModelBinding;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.AdminUserPresenterTests
{
    [TestFixture]
    public class View_AdminDeleteUser_Should
    {
        [Test]
        public void AddModelError_WhenItemIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<IAdminUsersView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            Guid userId = Guid.NewGuid();
            string errorKey = string.Empty;
            string expectedError = string.Format("Item with id {0} was not found", userId);
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(u => u.GetUserCustomInfoById(userId)).Returns<UserCustomInfo>(null);

            AdminUserPresenter adminUsersPresenter = new AdminUserPresenter(viewMock.Object, usersServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminDeleteUser += null, null, new UserDetailsByIdEventArgs(userId));

            // Assert
            Assert.AreEqual(1, viewMock.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, viewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }

        [Test]
        public void DeleteUserCustomInfoIsCalled_WhenItemIsFound()
        {
            // Arrange
            var viewMock = new Mock<IAdminUsersView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            Guid userId = Guid.NewGuid();
            var usersServiceMock = new Mock<IUsersService>();
            var user = new UserCustomInfo() { Id = userId };
            usersServiceMock.Setup(c => c.GetUserCustomInfoById(userId)).Returns(user);

            AdminUserPresenter adminUsersPresenter = new AdminUserPresenter(viewMock.Object, usersServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminDeleteUser += null, null, new UserDetailsByIdEventArgs(userId));

            // Assert
            usersServiceMock.Verify(u => u.DeleteUserCustomInfo(user), Times.Once());
        }
    }
}