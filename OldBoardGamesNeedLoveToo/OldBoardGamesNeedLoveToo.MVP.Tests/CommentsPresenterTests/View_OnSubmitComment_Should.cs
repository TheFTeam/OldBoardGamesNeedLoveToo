using System;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.CommentsPresenterTests
{
    [TestFixture]
    public class View_OnSubmitComment_Should
    {
        [Test]
        public void CallCreateComment_WhenThePassedParametersFromEventArgsAreValid()
        {
            // Arrange
            var viewMock = new Mock<ICommentsView>();
            var commentsServiceMock = new Mock<ICommentsService>();
            var gameId = Guid.NewGuid();
            var username = "Misho";
            var content = "Hello";
            var comment = new Comment() { Content = content, PostedByUserName = username };
            commentsServiceMock.Setup(c => c.CreateComment(content, gameId, username)).Returns(comment);

            CommentsPresenter commentsPresenter = new CommentsPresenter(viewMock.Object, commentsServiceMock.Object);

            // Act
            viewMock.Raise(c => c.OnSubmitComment += null, null, new CommentDetailsEventArgs(content, gameId, username));

            // Assert
            commentsServiceMock.Verify(c => c.CreateComment(content, gameId, username), Times.Once());
        }

        [Test]
        public void NotCallAddComment_WhenThePassedParameterUsernameFromEventArgsIsNull()
        {
            // Arrange
            var viewMock = new Mock<ICommentsView>();
            var commentsServiceMock = new Mock<ICommentsService>();
            var gameId = Guid.NewGuid();
            string username = null;
            var content = "Hello";
            var comment = new Comment() { Content = content, PostedByUserName = username };
            commentsServiceMock.Setup(c => c.CreateComment(content, gameId, username)).Returns<Comment>(null);

            CommentsPresenter commentsPresenter = new CommentsPresenter(viewMock.Object, commentsServiceMock.Object);

            // Act
            viewMock.Raise(c => c.OnSubmitComment += null, null, new CommentDetailsEventArgs(content, gameId, username));

            // Assert
            commentsServiceMock.Verify(c => c.AddComment(comment), Times.Never());
        }

        [Test]
        public void NotCallAddComment_WhenThePassedParameterContentFromEventArgsIsNull()
        {
            // Arrange
            var viewMock = new Mock<ICommentsView>();
            var commentsServiceMock = new Mock<ICommentsService>();
            var gameId = Guid.NewGuid();
            string username = "Misho";
            string content = null;
            var comment = new Comment() { Content = content, PostedByUserName = username };
            commentsServiceMock.Setup(c => c.CreateComment(content, gameId, username)).Returns<Comment>(null);

            CommentsPresenter commentsPresenter = new CommentsPresenter(viewMock.Object, commentsServiceMock.Object);

            // Act
            viewMock.Raise(c => c.OnSubmitComment += null, null, new CommentDetailsEventArgs(content, gameId, username));

            // Assert
            commentsServiceMock.Verify(c => c.AddComment(comment), Times.Never());
        }

        [Test]
        public void CallAddComment_WhenThePassedParametersFromEventArgsAreValid()
        {
            // Arrange
            var viewMock = new Mock<ICommentsView>();
            var commentsServiceMock = new Mock<ICommentsService>();
            var gameId = Guid.NewGuid();
            var username = "Misho";
            var content = "Hello";
            var comment = new Comment() { Content = content, PostedByUserName = username };
            commentsServiceMock.Setup(c => c.CreateComment(content, gameId, username)).Returns(comment);

            CommentsPresenter commentsPresenter = new CommentsPresenter(viewMock.Object, commentsServiceMock.Object);

            // Act
            viewMock.Raise(c => c.OnSubmitComment += null, null, new CommentDetailsEventArgs(content, gameId, username));

            // Assert
            commentsServiceMock.Verify(c => c.AddComment(comment), Times.Once());
        }
    }
}