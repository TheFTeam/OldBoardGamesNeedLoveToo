using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.RatingPresenterTests
{
    [TestFixture]
    public class View_OnPageInit_Should
    {
        public class View_OnCategoriesGetData_Should
        {
            [Test]
            public void AddRatigToViewModel_WhenOnPageInitEventIsRaised()
            {
                // Arrange
                var viewMock = new Mock<IRatingView>();
                viewMock.Setup(v => v.Model).Returns(new RatingViewModel());

                var rating = 5d;
                var userServiceMock = new Mock<IUsersService>();
                userServiceMock.Setup(x => x.GetAverageUserRating(It.IsAny<string>())).Returns(rating);

                RatingPresenter ratingPresenter = new RatingPresenter(viewMock.Object, userServiceMock.Object);

                // Act
                viewMock.Raise(v => v.onPageInit += null, new RatingValueEventArgs(null, It.IsAny<string>()));

                // Assert
                Assert.AreEqual(rating, viewMock.Object.Model.AverageRating);
            }
        }
    }
}
