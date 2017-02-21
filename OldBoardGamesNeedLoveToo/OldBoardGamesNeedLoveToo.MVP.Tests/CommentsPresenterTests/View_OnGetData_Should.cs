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

namespace OldBoardGamesNeedLoveToo.MVP.Tests.CommentsPresenterTests
{
    [TestFixture]
    public class View_OnGetData_Should
    {
        [Test]
        public void AddCommentsToViewModel_WhenOnPageInitEventIsRaised()
        {
            // Arrange
            var viewMock = new Mock<ICommentsView>();
            viewMock.Setup(v => v.Model).Returns(new CommentsViewModel());
            var gameId = Guid.NewGuid();

            var comments = new List<Comment>()
                {
                    new Comment()
                    {
                        Id = Guid.NewGuid(),
                        Content = "Hello",
                        GameId = gameId
                    },
                     new Comment()
                    {
                        Id = Guid.NewGuid(),
                        Content = "Hi",
                        GameId = gameId
                    },
                      new Comment()
                    {
                        Id = Guid.NewGuid(),
                        Content = "Buenos Dias",
                        GameId = gameId
                    }
                };

            var commentsServiceMock = new Mock<ICommentsService>();
            commentsServiceMock.Setup(c => c.GetAllCommentsByGameId(gameId)).Returns(comments);

            CommentsPresenter commentsPresenter = new CommentsPresenter(viewMock.Object, commentsServiceMock.Object);

            // Act
            viewMock.Raise(v => v.OnGetData += null, null, new CommentsByGameIdEventArgs(gameId));

            // Assert
            CollectionAssert.AreEquivalent(comments, viewMock.Object.Model.Comments);
        }
    }
}