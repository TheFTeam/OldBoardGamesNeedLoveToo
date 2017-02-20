using System;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Services.Tests.CommentsServiceTests
{
    [TestFixture]
    public class AddComment_Should
    {
        [Test]
        public void Throw_WhenThePassedCommentIsNull()
        {
            //Arrange
            var commentRepositoryMock = new Mock<IRepository<Comment>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            CommentsService categoriesService = new CommentsService(commentRepositoryMock.Object, unitOfWorkMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => categoriesService.AddComment(null));
        }

        [Test]
        public void InvokeRepositoryMethodAddOnce_WhenThePassedCommentIsValid()
        {
            //Arrange
            var commentRepositoryMock = new Mock<IRepository<Comment>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            CommentsService commentService = new CommentsService(commentRepositoryMock.Object, unitOfWorkMock.Object);
            Guid commentId = Guid.NewGuid();
            Comment comment = new Comment();

            //Act
            commentService.AddComment(comment);

            //Assert
            commentRepositoryMock.Verify(x => x.Add(It.IsAny<Comment>()), Times.Once);
        }
    }
}
