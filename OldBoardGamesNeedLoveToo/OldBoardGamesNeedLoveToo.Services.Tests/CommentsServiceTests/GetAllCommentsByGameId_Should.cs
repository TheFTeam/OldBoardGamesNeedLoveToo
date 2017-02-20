using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;
using System;
using System.Linq.Expressions;

namespace OldBoardGamesNeedLoveToo.Services.Tests.CommentsServiceTests
{
    [TestFixture]
    public class GetAllCommentsByGameId_Should
    {
        [Test]
        public void Throw_WhenPassedParameterIdIsEmpty()
        {
            //Arrange
            var commentRepositoryMock = new Mock<IRepository<Comment>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            CommentsService commentService = new CommentsService(commentRepositoryMock.Object, unitOfWorkMock.Object);
            Guid id = new Guid();

            //Act & Assert
            Assert.Throws<ArgumentException>(() => commentService.GetAllCommentsByGameId(id));
        }

        [Test]
        public void Invoke_TheRepositoryMethodGetAllGames_Once()
        {
            //Arrange
            var commentRepositoryMock = new Mock<IRepository<Comment>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            CommentsService commentService = new CommentsService(commentRepositoryMock.Object, unitOfWorkMock.Object);
            Guid id = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            commentRepositoryMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Comment, bool>>>(), It.IsAny<Expression<Func<Comment, DateTime>>>())); 

            //Act
            IEnumerable<Comment> commentsResult = commentService.GetAllCommentsByGameId(id);

            //Assert
            commentRepositoryMock.Verify(c => c.GetAll(It.IsAny<Expression<Func<Comment, bool>>>(), It.IsAny<Expression<Func<Comment, DateTime>>>()),Times.Once);
        }

        [Test]
        public void ReturnResult_WhenInvokingRepositoryMethod_GetAll()
        {
            //Arrange
            var ccommentsRepositoryMock = new Mock<IRepository<Comment>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Guid id = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");

            IEnumerable<Comment> expectedResultCollection = new List<Comment>()
            {
                new Comment() { GameId=id ,PostedOnDate=DateTime.Now},
                new Comment() { GameId=id ,PostedOnDate=DateTime.Now},
                new Comment() { GameId=id ,PostedOnDate=DateTime.Now},
                new Comment() { GameId=id ,PostedOnDate=DateTime.Now}
            };

            ccommentsRepositoryMock.Setup(c => c.GetAll(It.IsAny<Expression<Func<Comment, bool>>>(), It.IsAny<Expression<Func<Comment, DateTime>>>())).Returns(() =>
            {
                return expectedResultCollection;
            });

            CommentsService commentsService = new CommentsService(ccommentsRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            IEnumerable<Comment> commentResult = commentsService.GetAllCommentsByGameId(id);

            //Assert
            Assert.AreSame(commentResult, expectedResultCollection);
        }


    }
}
