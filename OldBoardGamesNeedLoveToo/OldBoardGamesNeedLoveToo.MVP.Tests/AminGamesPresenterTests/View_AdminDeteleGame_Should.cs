using System;
using System.Web.ModelBinding;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.AminGamesPresenterTests
{
    [TestFixture]
    public class View_AdminDeteleGame_Should
    {
        [Test]
        public void AddModelError_WhenItemIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<IAdminGamesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            Guid gameId = Guid.NewGuid();
            string expectedError = string.Format("Item with id {0} was not found", gameId);
            var gamesServiceMock = new Mock<IGamesService>();
            gamesServiceMock.Setup(c => c.GetGameById(gameId)).Returns<Game>(null);

            AdminGamesPresenter adminGamesPresenter = new AdminGamesPresenter(viewMock.Object, gamesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminDeteleGame += null, new GameDetailsEventArgs(gameId));

            // Assert
            Assert.AreEqual(1, viewMock.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, viewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }

        [Test]
        public void DeleteGameIsCalled_WhenItemIsFound()
        {
            // Arrange
            var viewMock = new Mock<IAdminGamesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            Guid gameId = Guid.NewGuid();
            var gamesServiceMock = new Mock<IGamesService>();
            var game = new Game() { Id = gameId };
            gamesServiceMock.Setup(c => c.GetGameById(gameId)).Returns(game);

            AdminGamesPresenter adminGamesPresenter = new AdminGamesPresenter(viewMock.Object, gamesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.AdminDeteleGame += null, null, new GameDetailsEventArgs(gameId));

            // Assert
            gamesServiceMock.Verify(c => c.DeleteGame(game), Times.Once());
        }
    }
}