using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Tests.AddGamePresenterTests
{
    [TestFixture]
    public class OnAddGameSubmit_Should
    {
        [Test]
        public void CallCreateGame_WhenThePassedParametersFromEventArgsAreValid()
        {
            // Arrange
            var viewMock = new Mock<IAddGameView>();
            var gamesServiceMock = new Mock<IGamesService>();
            var categoriesServiceMock = new Mock<ICategoriesService>();
            string name = "The Game";
            string condition = "2";
            var parsedCondition = (ConditionType) Enum.Parse(typeof(ConditionType), condition);
            string content = "cards";
            string description = "The game is awesome";
            string language = "Bulgarian";
            string producer = "The Producer";
            string price = "330";
            var parsedPrice = decimal.Parse(price);
            string releaseDate = "12/10/2015 00:00:00";
            var parsedReleaseDate = Convert.ToDateTime(releaseDate);
            string minPlayers = "3";
            var parsedMinPlayers = int.Parse(minPlayers);
            string maxPlayers = "9";
            var parsedMaxPlayers = int.Parse(maxPlayers);
            string minAgeOfPlayers = "6";
            var parsedMinAgeOfPlayers = int.Parse(minAgeOfPlayers);
            string maxAgeOfPlayers = "12";
            var parsedMaxAgeOfPlayer = int.Parse(maxAgeOfPlayers);
            Guid selectedCategoryId = Guid.NewGuid();
            var category = new Category() { Id = selectedCategoryId, Name = "category" };
            var selectedCategoriesIds = new List<string>() { selectedCategoryId.ToString() };
            var categories = new List<Category>() { category };
            byte[] image = new byte[100];
            Guid ownerId = Guid.NewGuid();

            var game = new Game()
            {
                Name = name,
                Desription = description,
                Contents = content,
                Condition = parsedCondition,
                Categories = categories,
                Price = parsedPrice,
                ReleaseDate = parsedReleaseDate,
                MinPlayers = parsedMinPlayers,
                MaxPlayers = parsedMaxPlayers,
                MinAgeOfPlayers = parsedMinAgeOfPlayers,
                MaxAgeOfPlayers = parsedMaxAgeOfPlayer,
                Image = image,
                OwnerId = ownerId,
                Language = language,
                Producer = producer
            };

            categoriesServiceMock.Setup(c => c.GetCategoryById(selectedCategoryId)).Returns(category);
            gamesServiceMock.Setup(c => c.CreateGame(name, content, categories, parsedCondition, language, parsedPrice, ownerId, parsedReleaseDate, image, producer, description, parsedMinPlayers, parsedMaxPlayers, parsedMinAgeOfPlayers, parsedMaxAgeOfPlayer)).Returns(game);

            AddGamePresenter addGamePresenter = new AddGamePresenter(viewMock.Object, gamesServiceMock.Object, categoriesServiceMock.Object);

            // Act
            viewMock.Raise(g => g.OnAddGameSubmit += null, null, new AddGameEventArgs(condition, content, description, image, language, name, price, producer, releaseDate, minPlayers, maxPlayers, minAgeOfPlayers, maxAgeOfPlayers, ownerId, selectedCategoriesIds));

            // Assert
            gamesServiceMock.Verify(c => c.CreateGame(name, content, categories, parsedCondition, language, parsedPrice, ownerId, parsedReleaseDate, image, producer, description, parsedMinPlayers, parsedMaxPlayers, parsedMinAgeOfPlayers, parsedMaxAgeOfPlayer), Times.Once());
        }

        [Test]
        public void NotCallCreateGame_WhenThePassedParametersFromEventArgsAreNotValid()
        {
            // Arrange
            var viewMock = new Mock<IAddGameView>();
            var gamesServiceMock = new Mock<IGamesService>();
            var categoriesServiceMock = new Mock<ICategoriesService>();

            string name = null;
            string condition = "6";
            var parsedCondition = (ConditionType) Enum.Parse(typeof(ConditionType), condition);
            string content = "cards";
            string description = "The game is awesome";
            string language = "Bulgarian";
            string producer = "The Producer";
            string price = "330";
            var parsedPrice = decimal.Parse(price);
            string releaseDate = "12/10/2015 00:00:00";
            var parsedReleaseDate = Convert.ToDateTime(releaseDate);
            string minPlayers = "3";
            var parsedMinPlayers = int.Parse(minPlayers);
            string maxPlayers = "9";
            var parsedMaxPlayers = int.Parse(maxPlayers);
            string minAgeOfPlayers = "6";
            var parsedMinAgeOfPlayers = int.Parse(minAgeOfPlayers);
            string maxAgeOfPlayers = "12";
            var parsedMaxAgeOfPlayer = int.Parse(maxAgeOfPlayers);
            Guid selectedCategoryId = Guid.NewGuid();
            var category = new Category() { Id = selectedCategoryId, Name = "category" };
            var selectedCategoriesIds = new List<string>() { selectedCategoryId.ToString() };
            var categories = new List<Category>() { new Category() { Id = selectedCategoryId } };
            byte[] image = new byte[100];
            Guid ownerId = Guid.NewGuid();

            var game = new Game()
            {
                Name = name,
                Desription = description,
                Contents = content,
                Condition = parsedCondition,
                Categories = categories,
                Price = parsedPrice,
                ReleaseDate = parsedReleaseDate,
                MinPlayers = parsedMinPlayers,
                MaxPlayers = parsedMaxPlayers,
                MinAgeOfPlayers = parsedMinAgeOfPlayers,
                MaxAgeOfPlayers = parsedMaxAgeOfPlayer,
                Image = image,
                OwnerId = ownerId,
                Language = language,
                Producer = producer
            };
            categoriesServiceMock.Setup(c => c.GetCategoryById(selectedCategoryId)).Returns(category);
            gamesServiceMock.Setup(c => c.CreateGame(name, content, categories, parsedCondition, language, parsedPrice, ownerId, parsedReleaseDate, image, producer, description, parsedMinPlayers, parsedMaxPlayers, parsedMinAgeOfPlayers, parsedMaxAgeOfPlayer)).Returns<Game>(null);

            AddGamePresenter addGamePresenter = new AddGamePresenter(viewMock.Object, gamesServiceMock.Object, categoriesServiceMock.Object);

            // Act
            viewMock.Raise(g => g.OnAddGameSubmit += null, new AddGameEventArgs(condition, content, description, image, language, name, price, producer, releaseDate, minPlayers, maxPlayers, minAgeOfPlayers, maxAgeOfPlayers, ownerId, selectedCategoriesIds));

            // Assert
            gamesServiceMock.Verify(c => c.CreateGame(name, content, categories, parsedCondition, language, parsedPrice, ownerId, parsedReleaseDate, image, producer, description, parsedMinPlayers, parsedMaxPlayers, parsedMinAgeOfPlayers, parsedMaxAgeOfPlayer), Times.Never());
        }

        [Test]
        public void NotCallAddGame_WhenThePassedParameterContentFromEventArgsIsNull()
        {
            // Arrange
            var viewMock = new Mock<IAddGameView>();
            var gamesServiceMock = new Mock<IGamesService>();
            var categoriesServiceMock = new Mock<ICategoriesService>();

            string name = null;
            string condition = "2";
            var parsedCondition = (ConditionType) Enum.Parse(typeof(ConditionType), condition);
            string content = "cards";
            string description = "The game is awesome";
            string language = "Bulgarian";
            string producer = "The Producer";
            string price = "330";
            var parsedPrice = decimal.Parse(price);
            string releaseDate = "12/10/2015 00:00:00";
            var parsedReleaseDate = Convert.ToDateTime(releaseDate);
            string minPlayers = "3";
            var parsedMinPlayers = int.Parse(minPlayers);
            string maxPlayers = "9";
            var parsedMaxPlayers = int.Parse(maxPlayers);
            string minAgeOfPlayers = "6";
            var parsedMinAgeOfPlayers = int.Parse(minAgeOfPlayers);
            string maxAgeOfPlayers = "12";
            var parsedMaxAgeOfPlayer = int.Parse(maxAgeOfPlayers);
            Guid selectedCategoryId = Guid.NewGuid();
            var category = new Category() { Id = selectedCategoryId, Name = "category" };
            var selectedCategoriesIds = new List<string>() { selectedCategoryId.ToString() };
            var categories = new List<Category>() { new Category() { Id = selectedCategoryId } };
            byte[] image = new byte[100];
            Guid ownerId = Guid.NewGuid();

            var game = new Game()
            {
                Name = name,
                Desription = description,
                Contents = content,
                Condition = parsedCondition,
                Categories = categories,
                Price = parsedPrice,
                ReleaseDate = parsedReleaseDate,
                MinPlayers = parsedMinPlayers,
                MaxPlayers = parsedMaxPlayers,
                MinAgeOfPlayers = parsedMinAgeOfPlayers,
                MaxAgeOfPlayers = parsedMaxAgeOfPlayer,
                Image = image,
                OwnerId = ownerId,
                Language = language,
                Producer = producer
            };

            categoriesServiceMock.Setup(c => c.GetCategoryById(selectedCategoryId)).Returns(category);
            gamesServiceMock.Setup(c => c.CreateGame(name, content, categories, parsedCondition, language, parsedPrice, ownerId, parsedReleaseDate, image, producer, description, parsedMinPlayers, parsedMaxPlayers, parsedMinAgeOfPlayers, parsedMaxAgeOfPlayer)).Returns<Game>(null);

            AddGamePresenter addgamePresenter = new AddGamePresenter(viewMock.Object, gamesServiceMock.Object, categoriesServiceMock.Object);

            // Act
            viewMock.Raise(c => c.OnAddGameSubmit += null, null, new AddGameEventArgs(condition, content, description, image, language, name, price, producer, releaseDate, minPlayers, maxPlayers, minAgeOfPlayers, maxAgeOfPlayers, ownerId, selectedCategoriesIds));

            // Assert
            gamesServiceMock.Verify(c => c.AddGame(game), Times.Never());
        }

        [Test]
        public void CallAddGame_WhenThePassedParameterContentFromEventArgsAreValid()
        {
            // Arrange
            var viewMock = new Mock<IAddGameView>();
            var gamesServiceMock = new Mock<IGamesService>();
            var categoriesServiceMock = new Mock<ICategoriesService>();

            string name = "Maria";
            string condition = "2";
            var parsedCondition = (ConditionType) Enum.Parse(typeof(ConditionType), condition);
            string content = "cards";
            string description = "The game is awesome";
            string language = "Bulgarian";
            string producer = "The Producer";
            string price = "330";
            var parsedPrice = decimal.Parse(price);
            string releaseDate = "12/10/2015 00:00:00";
            var parsedReleaseDate = Convert.ToDateTime(releaseDate);
            string minPlayers = "3";
            var parsedMinPlayers = int.Parse(minPlayers);
            string maxPlayers = "9";
            var parsedMaxPlayers = int.Parse(maxPlayers);
            string minAgeOfPlayers = "6";
            var parsedMinAgeOfPlayers = int.Parse(minAgeOfPlayers);
            string maxAgeOfPlayers = "12";
            var parsedMaxAgeOfPlayer = int.Parse(maxAgeOfPlayers);
            Guid selectedCategoryId = Guid.NewGuid();
            var category = new Category() { Id = selectedCategoryId, Name = "category" };
            var selectedCategoriesIds = new List<string>() { selectedCategoryId.ToString() };
            var categories = new List<Category>() { new Category() { Id = selectedCategoryId } };
            byte[] image = new byte[100];
            Guid ownerId = Guid.NewGuid();

            var game = new Game()
            {
                Name = name,
                Desription = description,
                Contents = content,
                Condition = parsedCondition,
                Categories = categories,
                Price = parsedPrice,
                ReleaseDate = parsedReleaseDate,
                MinPlayers = parsedMinPlayers,
                MaxPlayers = parsedMaxPlayers,
                MinAgeOfPlayers = parsedMinAgeOfPlayers,
                MaxAgeOfPlayers = parsedMaxAgeOfPlayer,
                Image = image,
                OwnerId = ownerId,
                Language = language,
                Producer = producer
            };

            categoriesServiceMock.Setup(c => c.GetCategoryById(selectedCategoryId)).Returns(category);
            gamesServiceMock.Setup(c => c.CreateGame(name, content, categories, parsedCondition, language, parsedPrice, ownerId, parsedReleaseDate, image, producer, description, parsedMinPlayers, parsedMaxPlayers, parsedMinAgeOfPlayers, parsedMaxAgeOfPlayer)).Returns(game);

            AddGamePresenter addgamePresenter = new AddGamePresenter(viewMock.Object, gamesServiceMock.Object, categoriesServiceMock.Object);

            // Act
            viewMock.Raise(c => c.OnAddGameSubmit += null, new AddGameEventArgs(condition, content, description, image, language, name, price, producer, releaseDate, minPlayers, maxPlayers, minAgeOfPlayers, maxAgeOfPlayers, ownerId, selectedCategoriesIds));

            // Assert
            gamesServiceMock.Verify(c => c.AddGame(game), Times.Once());
        }
    }
}
