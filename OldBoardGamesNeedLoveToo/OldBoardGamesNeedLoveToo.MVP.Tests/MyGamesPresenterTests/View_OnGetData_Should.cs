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

namespace OldBoardGamesNeedLoveToo.MVP.Tests.MyGamesPresenterTests
{
    [TestFixture]
    public class View_OnGetData_Should
    {
        [Test]
        public void AddGamesToViewModel_WhenOnGetDataEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<IMyGamesView>();
            viewMock.Setup(v => v.Model).Returns(new GamesViewModel());

            var games = new List<Game>()
                {
                    new Game()
                    {
                        Id = Guid.NewGuid(),
                        Name = "game1"
                    },
                    new Game()
                    {
                        Id = Guid.NewGuid(),
                        Name = "game2"
                    },
                    new Game()
                    {
                        Id = Guid.NewGuid(),
                        Name = "game3"
                    }
                };

            var gamesServiceMock = new Mock<IGamesService>();
            gamesServiceMock.Setup(c => c.GetAllGamesOfCurrentUser(It.IsAny<Guid>())).Returns(games);

            MyGamesPresenter myGamesPresenter = new MyGamesPresenter(viewMock.Object, gamesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnGetData += null, new MyGamesEventArgs(It.IsAny<Guid>()));

            // Assert
            CollectionAssert.AreEquivalent(games, viewMock.Object.Model.Games);
        }
    }
}
