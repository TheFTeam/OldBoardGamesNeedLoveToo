using System;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Services.Tests.CommentsServiceTests
{
    [TestFixture]
    public class CreateComment_Should
    {
        [Test]
        public void Throw_WhenPassedParameterContentIsNull()
        {
            //Arrange
            var commentRepositoryMock = new Mock<IRepository<Comment>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            CommentsService commentService = new CommentsService(commentRepositoryMock.Object, unitOfWorkMock.Object);
            string comment = null;
            Guid gameid = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            string sampleUser = "username";

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => commentService.CreateComment(comment, gameid, sampleUser));
        }

        [Test]
        public void Throw_WhenPassedParameterGameIdIsEmpty()
        {
            //Arrange
            var commentRepositoryMock = new Mock<IRepository<Comment>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            CommentsService commentService = new CommentsService(commentRepositoryMock.Object, unitOfWorkMock.Object);
            var comment = "witty comment";
            Guid gameid = new Guid();
            var sampleUser = "username";

            //Act & Assert
            Assert.Throws<ArgumentException>(() => commentService.CreateComment(comment, gameid, sampleUser));
        }

        [Test]
        public void Throw_WhenPassedParameterUsernameIsEmpty()
        {
            //Arrange
            var commentRepositoryMock = new Mock<IRepository<Comment>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            CommentsService commentService = new CommentsService(commentRepositoryMock.Object, unitOfWorkMock.Object);
            var comment = "witty comment";
            Guid gameid = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            string sampleUser = null;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => commentService.CreateComment(comment, gameid, sampleUser));
        }

        [Test]
        public void ReturnComment_WhenPassedParametersAreValid()
        {
            //Arrange
            var commentRepositoryMock = new Mock<IRepository<Comment>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var comment = "witty comment";
            Guid gameid = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            string sampleUser = "user";

            CommentsService commentService = new CommentsService(commentRepositoryMock.Object, unitOfWorkMock.Object);

            //Act
            Comment commentResult = commentService.CreateComment(comment, gameid, sampleUser);

            //Assert
            Assert.AreEqual(commentResult.Content, comment);
            Assert.AreEqual(commentResult.GameId, gameid);
            Assert.AreEqual(commentResult.PostedByUserName, sampleUser);
        }

    }
}
