using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.DefaultPagePresenterTests
{
    [TestFixture]
    public class View_DefaultPageInit_Should
    {
        [Test]
        public void AddCategoriesToViewModel_WhenOnPageInitEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<IDefaultPageView>();
            viewMock.Setup(v => v.Model).Returns(new GamesViewModel());

            var games = new List<Game>()
                {
                    new Game()
                    {
                        Id = Guid.NewGuid(),
                        Name = "First Game",
                        Condition = ConditionType.Excellent
                    },
                     new Game()
                    {
                        Id = Guid.NewGuid(),
                        Name = "First Game",
                        Condition = ConditionType.Good
                    },
                      new Game()
                    {
                        Id = Guid.NewGuid(),
                        Name = "First Game",
                        Condition = ConditionType.VeryGood
                    }
                };

            var gamesServiceMock = new Mock<IGamesService>();
            gamesServiceMock.Setup(g => g.GetAllGames()).Returns(games);

            DefaultPagePresenter defaultPagePresenter = new DefaultPagePresenter(viewMock.Object, gamesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.DefaultPageInit += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(games, viewMock.Object.Model.Games);
        }
    }
}