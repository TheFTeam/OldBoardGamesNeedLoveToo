using System;
using System.Web.ModelBinding;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;


namespace OldBoardGamesNeedLoveToo.MVP.Tests.MyGamesPresenterTests
{
    [TestFixture]
    public class View_OnDeleteItem_Should
    {
        [Test]
        public void AddModelError_WhenItemIsNotFound()
        {
            // Arrange
            var viewMock = new Mock<IMyGamesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());
            Guid gameId = Guid.NewGuid();
            string errorKey = string.Empty;
            string expectedError = string.Format("Item with id {0} was not found", gameId);
            var gamesServiceMock = new Mock<IGamesService>();
            gamesServiceMock.Setup(u => u.GetGameById(gameId)).Returns<UserCustomInfo>(null);

            MyGamesPresenter myGamesPresenter = new MyGamesPresenter(viewMock.Object, gamesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnDeleteItem += null, new MyGamesEventArgs(gameId));

            // Assert
            Assert.AreEqual(1, viewMock.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, viewMock.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }

        [Test]
        public void DeleteGameIsCalled_WhenItemIsFound()
        {
            // Arrange
            var viewMock = new Mock<IMyGamesView>();
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            Guid gameId = Guid.NewGuid();
            var gamesServiceMock = new Mock<IGamesService>();
            var game = new Game() { Id = gameId };
            gamesServiceMock.Setup(c => c.GetGameById(gameId)).Returns(game);

            MyGamesPresenter myGamesPresenter = new MyGamesPresenter(viewMock.Object, gamesServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnDeleteItem += null, new MyGamesEventArgs(gameId));

            // Assert
            gamesServiceMock.Verify(u => u.DeleteGame(game), Times.Once());
        }
    }
}
