using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using System.Linq;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.UserProfilePresenterTests
{
    [TestFixture]
    public class View_OnUserProfilePageInit_Should
    {
        [Test]
        public void AddUsersToViewModel_WhenOnUserProfilePageInitEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<IUserProfileView>();
            viewMock.Setup(v => v.Model).Returns(new UsersViewModel());

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

            var gamesServiceMock = new Mock<IGamesService>();


            UserProfilePresenter userProfilePresenter = new UserProfilePresenter(viewMock.Object, usersServiceMock.Object, gamesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUserProfilePageInit += null, new UserDetailsByUsernameEventArgs("Ivan"));

            // Assert
            CollectionAssert.AreEquivalent(users.Where(x=>x.Username=="Ivan"), viewMock.Object.Model.Users);
        }

        [Test]
        public void AddGamesToViewModel_WhenOnGetDataEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<IUserProfileView>();
            viewMock.Setup(v => v.Model).Returns(new UsersViewModel());

            var games = new List<Game>()
                {
                    new Game()
                    {
                        Id = Guid.NewGuid(),
                        Name = "First game",
                        
                       
                    },
                     new Game()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Second game"
                    },
                      new Game()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Third game"
                    },
                };

            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(c => c.GetAllUserCustomInfoSellinGames(It.IsAny<string>())).Returns(games);

            var gamesServiceMock = new Mock<IGamesService>();

            UserProfilePresenter userProfilePresenter = new UserProfilePresenter(viewMock.Object, usersServiceMock.Object, gamesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnUserProfilePageInit += null, new UserDetailsByUsernameEventArgs(It.IsAny<string>()));

            // Assert
            CollectionAssert.AreEquivalent(games, viewMock.Object.Model.Games);
        }
    }
}
