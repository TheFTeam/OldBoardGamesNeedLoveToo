using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.AminGamesPresenterTests
{
    [TestFixture]
    public class View_AdminGetAllGames_Should
    {
        [Test]
        public void AddGamesToViewModel_WhenAdminGetAllGamesEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<IAdminGamesView>();
            viewMock.Setup(v => v.Model).Returns(new AdminGamesViewModel());

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
            gamesServiceMock.Setup(c => c.GetAllGames()).Returns(games);

            AdminGamesPresenter adminGamesPresenter = new AdminGamesPresenter(viewMock.Object, gamesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminGetAllGames += null, EventArgs.Empty);

            // Assert
            CollectionAssert.AreEquivalent(games, viewMock.Object.Model.Games);
        }
    }
}
