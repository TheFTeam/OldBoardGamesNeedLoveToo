using System;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Models;
using System.Collections.Generic;

namespace OldBoardGamesNeedLoveToo.Services.Tests.GamesServiceTests
{
    [TestFixture]
    public class CreateGame_Should
    {
        [Test]
        public void Throw_WhenNameIsNull()
        {
            //Arrange
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => gamesService.AddGame(null));
            string name = null;
            string contents = "contents";
            ICollection<Category> categories = new List<Category>() { new Category() };
            ConditionType condition = ConditionType.Excellent;
            string language = "language";
            decimal price = 100;
            Guid ownerId = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            DateTime releaseDate = DateTime.Now;
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            //Act & Assert

            Assert.Throws<ArgumentNullException>(() => gamesService
            .CreateGame(name, contents, categories, condition, language, price, ownerId, releaseDate, image));
        }

        [Test]
        public void Throw_WhenNameIsEmpty()
        {
            //Arrange
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => gamesService.AddGame(null));
            string name = string.Empty;
            string contents = "contents";
            ICollection<Category> categories = new List<Category>() { new Category() };
            ConditionType condition = ConditionType.Excellent;
            string language = "language";
            decimal price = 100;
            Guid ownerId = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            DateTime releaseDate = DateTime.Now;
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            //Act & Assert

            Assert.Throws<ArgumentException>(() => gamesService
            .CreateGame(name, contents, categories, condition, language, price, ownerId, releaseDate, image));
        }
        [Test]
        public void Throw_WhenContentIsNull()
        {
            //Arrange
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => gamesService.AddGame(null));
            string name = "name";
            string contents = null;
            ICollection<Category> categories = new List<Category>() { new Category() };
            ConditionType condition = ConditionType.Excellent;
            string language = "language";
            decimal price = 100;
            Guid ownerId = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            DateTime releaseDate = DateTime.Now;
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            //Act & Assert

            Assert.Throws<ArgumentNullException>(() => gamesService
            .CreateGame(name, contents, categories, condition, language, price, ownerId, releaseDate, image));
        }
        [Test]
        public void Throw_WhenContentIsEmpty()
        {
            //Arrange
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => gamesService.AddGame(null));
            string name = "name";
            string contents = string.Empty;
            ICollection<Category> categories = new List<Category>() { new Category() };
            ConditionType condition = ConditionType.Excellent;
            string language = "language";
            decimal price = 100;
            Guid ownerId = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            DateTime releaseDate = DateTime.Now;
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            //Act & Assert

            Assert.Throws<ArgumentException>(() => gamesService
            .CreateGame(name, contents, categories, condition, language, price, ownerId, releaseDate, image));
        }

        [Test]
        public void Throw_WhenCategoriesAreNull()
        {
            //Arrange
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => gamesService.AddGame(null));
            string name = "name";
            string contents = "contents";
            ICollection<Category> categories = null;
            ConditionType condition = ConditionType.Excellent;
            string language = "language";
            decimal price = 100;
            Guid ownerId = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            DateTime releaseDate = DateTime.Now;
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            //Act & Assert

            Assert.Throws<ArgumentNullException>(() => gamesService
            .CreateGame(name, contents, categories, condition, language, price, ownerId, releaseDate, image));
        }

        [Test]
        public void Throw_WhenCategoriesAreEmpty()
        {
            //Arrange
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => gamesService.AddGame(null));
            string name = "name";
            string contents = "contents";
            ICollection<Category> categories = new List<Category>();
            ConditionType condition = ConditionType.Excellent;
            string language = "language";
            decimal price = 100;
            Guid ownerId = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            DateTime releaseDate = DateTime.Now;
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            //Act & Assert

            Assert.Throws<ArgumentException>(() => gamesService
            .CreateGame(name, contents, categories, condition, language, price, ownerId, releaseDate, image));
        }

        [Test]
        public void Throw_WhenLanguageIsNull()
        {
            //Arrange
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => gamesService.AddGame(null));
            string name = "name";
            string contents = "contents";
            ICollection<Category> categories = new List<Category>() { new Category() };
            ConditionType condition = ConditionType.Excellent;
            string language = null;
            decimal price = 100;
            Guid ownerId = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            DateTime releaseDate = DateTime.Now;
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            //Act & Assert

            Assert.Throws<ArgumentNullException>(() => gamesService
            .CreateGame(name, contents, categories, condition, language, price, ownerId, releaseDate, image));
        }
        [Test]
        public void Throw_WhenPriceIsNegativeNumber()
        {
            //Arrange
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => gamesService.AddGame(null));
            string name = "name";
            string contents = "contents";
            ICollection<Category> categories = new List<Category>() { new Category() };
            ConditionType condition = ConditionType.Excellent;
            string language = "language";
            decimal price = -100;
            Guid ownerId = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            DateTime releaseDate = DateTime.Now;
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            //Act & Assert

            Assert.Throws<ArgumentOutOfRangeException>(() => gamesService
            .CreateGame(name, contents, categories, condition, language, price, ownerId, releaseDate, image));
        }

        [Test]
        public void Throw_WhenLanguageIsEmpty()
        {
            //Arrange
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => gamesService.AddGame(null));
            string name = "name";
            string contents = "contents";
            ICollection<Category> categories = new List<Category>() { new Category() };
            ConditionType condition = ConditionType.Excellent;
            string language = string.Empty;
            decimal price = 100;
            Guid ownerId = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            DateTime releaseDate = DateTime.Now;
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            //Act & Assert

            Assert.Throws<ArgumentException>(() => gamesService
            .CreateGame(name, contents, categories, condition, language, price, ownerId, releaseDate, image));
        }

        [Test]
        public void Throw_WhenOwnerIdIsEmpty()
        {
            //Arrange
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => gamesService.AddGame(null));
            string name = "name";
            string contents = "contents";
            ICollection<Category> categories = new List<Category>() { new Category() };
            ConditionType condition = ConditionType.Excellent;
            string language = "language";
            decimal price = 100;
            Guid ownerId = Guid.Empty;
            DateTime releaseDate = DateTime.Now;
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            //Act & Assert

            Assert.Throws<ArgumentException>(() => gamesService
            .CreateGame(name, contents, categories, condition, language, price, ownerId, releaseDate, image));
        }

        public void Throw_WhenImageInNull()
        {
            //Arrange
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => gamesService.AddGame(null));
            string name = "name";
            string contents = "contents";
            ICollection<Category> categories = new List<Category>() { new Category() };
            ConditionType condition = ConditionType.Excellent;
            string language = "language";
            decimal price = 100;
            Guid ownerId = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            DateTime releaseDate = DateTime.Now;
            byte[] image = null;
            //Act & Assert

            Assert.Throws<ArgumentException>(() => gamesService
            .CreateGame(name, contents, categories, condition, language, price, ownerId, releaseDate, image));
        }

        public void Throw_WhenImageInEmpty()
        {
            //Arrange
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => gamesService.AddGame(null));
            string name = "name";
            string contents = "contents";
            ICollection<Category> categories = new List<Category>() { new Category() };
            ConditionType condition = ConditionType.Excellent;
            string language = "language";
            decimal price = 100;
            Guid ownerId = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            DateTime releaseDate = DateTime.Now;
            byte[] image = new byte[] { };
            //Act & Assert

            Assert.Throws<ArgumentException>(() => gamesService
            .CreateGame(name, contents, categories, condition, language, price, ownerId, releaseDate, image));
        }

        [Test]
        public void ReturnGame_WhenAllParametersAreValid()
        {
            //Arrange
            var gamesRepositoryMock = new Mock<IRepository<Game>>();
            var categoryRepositoryMock = new Mock<IRepository<Category>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var gamesService = new GamesService(gamesRepositoryMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => gamesService.AddGame(null));
            string name = "name";
            string contents = "contents";
            ICollection<Category> categories = new List<Category>() { new Category() { Name = "Category" } };
            ConditionType condition = ConditionType.Excellent;
            string language = "language";
            decimal price = 100;
            Guid ownerId = Guid.Parse("1db6f07d-46f2-4a63-8efd-10306478dd7e");
            DateTime releaseDate = DateTime.Now;
            byte[] image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            string producer = null;
            string description = null;
            int minPlayers = 1;
            int maxPlayers = 100;
            int minAgeOfPlayers = 2;
            int maxAgeOfPlayers = 100;
            //Act & Assert

            var game = gamesService.CreateGame(name, contents, categories, condition, language, price, ownerId, releaseDate, image);

            Assert.AreSame(name, game.Name);
            Assert.AreSame(contents, game.Contents);
            Assert.AreSame(categories, game.Categories);
            Assert.AreEqual(condition, game.Condition);
            Assert.AreSame(language, game.Language);
            Assert.AreEqual(price, game.Price);
            Assert.AreEqual(ownerId, game.OwnerId);
            Assert.AreEqual(releaseDate, game.ReleaseDate);
            Assert.AreSame(image, game.Image);
            Assert.AreSame(producer, game.Producer);
            Assert.AreSame(description, game.Desription);
            Assert.AreEqual(minPlayers, game.MinPlayers);
            Assert.AreEqual(maxPlayers, game.MaxPlayers);
            Assert.AreEqual(minAgeOfPlayers, game.MinAgeOfPlayers);
            Assert.AreEqual(maxAgeOfPlayers, game.MaxAgeOfPlayers);

        }
    }
}
