using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using System;
using System.Web.ModelBinding;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.RatingPresenterTests
{
    [TestFixture]
    public class View_OnRatingChange_Should
    {
        [Test]
        public void CallUpdateUserCustomInfoWithRatingValue()
        {
            // Arrange
            var viewMock = new Mock<IRatingView>();
            viewMock.Setup(v => v.Model).Returns(new RatingViewModel());

            var userServiceMock = new Mock<IUsersService>();
            RatingPresenter ratingPresenter = new RatingPresenter(viewMock.Object, userServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnRatingChanged += null, new RatingValueEventArgs(It.IsAny<int>(), It.IsAny<string>()));

            // Assert
            userServiceMock.Verify(c => c.UpdateUserCustomInfoWithRatingValue(It.IsAny<int>(), It.IsAny<string>()), Times.Once());
        }
    }
}
