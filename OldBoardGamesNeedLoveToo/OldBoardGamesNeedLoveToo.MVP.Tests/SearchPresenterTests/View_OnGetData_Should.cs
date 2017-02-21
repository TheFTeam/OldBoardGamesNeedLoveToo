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

namespace OldBoardGamesNeedLoveToo.MVP.Tests.SearchPresenterTests
{
    [TestFixture]
    public class View_OnGetData_Should
    {
        [Test]
        public void AddGamesToViewModel_WhenOnGetDataEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<ISearchView>();
            viewMock.Setup(v => v.Model).Returns(new SearchViewModel());

            var games = new List<Game>()
                {
                    new Game()
                    {
                        Id = Guid.NewGuid(),
                        Name = "First game"
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

            var gamesServiceMock = new Mock<IGamesService>();
            gamesServiceMock.Setup(c => c.GetGamesByName(It.IsAny<string>())).Returns(games);

            SearchPresenter searchPresenter = new SearchPresenter(viewMock.Object, gamesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnGetData += null, new SearchQueryParamsEventArgs(It.IsAny<string>()));

            // Assert
            CollectionAssert.AreEquivalent(games, viewMock.Object.Model.Games);
        }
    }
}
