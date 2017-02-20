using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;
using System;

namespace OldBoardGamesNeedLoveToo.Services.Tests.CommentsServiceTests
{
    [TestFixture]
    public class GetCommentById
    {
        [Test]
        public void ShouldThrow_WhenIdParameterIsNull()
        {
            //Arrange
            var commentRepositoryMock = new Mock<IRepository<Comment>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            CommentsService categoriesService = new CommentsService(commentRepositoryMock.Object, unitOfWorkMock.Object);

            //Act&Assert
            Assert.Throws<ArgumentNullException>(() => categoriesService.GetCommentById(null));
        }

        [Test]
        public void ReturnComment_WhenIdIsValid()
        {
            //Arrange
            var commentRepositoryMock = new Mock<IRepository<Comment>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Guid commentId = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            string content = "content";
            Comment comment = new Comment()
            {
                Id = commentId,
                Content = content
            };
            commentRepositoryMock.Setup(r => r.GetById(commentId)).Returns(comment);

            CommentsService commentsService = new CommentsService(commentRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            Comment categoryResult = commentsService.GetCommentById(commentId);

            //Assert
            Assert.AreSame(comment, categoryResult);
        }
    }
}
