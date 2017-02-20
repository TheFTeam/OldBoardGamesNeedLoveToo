using System;
using System.Collections.Generic;

using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.Services
{
    public class GamesService : IGamesService
    {
        private readonly IRepository<Game> gamesRepository;
        private readonly IRepository<Category> categoriesRepository;
        private readonly IUnitOfWork unitOfWork;

        public GamesService(IRepository<Game> gamesRepository, IRepository<Category> categoriesRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(gamesRepository, "gamesRepository").IsNull().Throw();
            Guard.WhenArgument(categoriesRepository, "categoriesRepository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.gamesRepository = gamesRepository;
            this.categoriesRepository = categoriesRepository;
            this.unitOfWork = unitOfWork;
        }
        public void AddGame(Game game)
        {
            Guard.WhenArgument(game, "game").IsNull().Throw();

            this.gamesRepository.Add(game);
            this.unitOfWork.Commit();
        }

        public Game CreateGame(string name, string contents, ICollection<Category> categories, ConditionType condition, string language, decimal price, Guid ownerId, DateTime releaseDate, byte[] image, string producer = null, string description = null, int minPlayers = 1, int maxPlayers = 100, int minAgeOfPlayers = 2, int maxAgeOfPlayers = 100)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();
            Guard.WhenArgument(contents, "contents").IsNullOrEmpty().Throw();
            Guard.WhenArgument(categories, "categories").IsNullOrEmpty().Throw();
            Guard.WhenArgument(language, "language").IsNullOrEmpty().Throw();
            Guard.WhenArgument(price, "price").IsLessThan(0).Throw();
            Guard.WhenArgument(ownerId, "ownerId").IsEmptyGuid().Throw();
            Guard.WhenArgument(image, "image").IsNullOrEmpty().Throw();
            return new Game()
            {
                Name = name,
                Contents = contents,
                Condition = condition,
                Categories = categories,
                Language = language,
                Price = price,
                OwnerId = ownerId,
                Desription = description,
                Image = image,
                MinPlayers = minPlayers,
                MaxPlayers = maxPlayers,
                MinAgeOfPlayers = minAgeOfPlayers,
                MaxAgeOfPlayers = maxAgeOfPlayers,
                isSold = false,
                ReleaseDate = releaseDate,
                Producer = producer
            };
        }

        public void DeleteGame(Game game)
        {
            Guard.WhenArgument(game, "game").IsNull().Throw();

            this.gamesRepository.Delete(game);
            this.unitOfWork.Commit();
        }

        public IEnumerable<Game> GetAllGames()
        {
            return this.gamesRepository.GetAll();
        }

        public IEnumerable<Game> GetAllGamesOfCurrentUser(Guid id)
        {
            Guard.WhenArgument(id, "id").IsEmptyGuid().Throw();

            return this.gamesRepository.GetAll(x => x.OwnerId == id);
        }

        public IEnumerable<Game> GetGamesByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return this.gamesRepository.GetAll();
            }
            else
            {
                return this.gamesRepository.GetAll(g => g.Name.ToLower().Contains(name.ToLower()));
            }
        }

        public Game GetGameById(object id)
        {
            Guard.WhenArgument(id, "id").IsNull().Throw();

            return this.gamesRepository.GetById(id);
        }

        public void UpdateGame(Game game)
        {
            Guard.WhenArgument(game, "game").IsNull().Throw();

            this.gamesRepository.Update(game);
            this.unitOfWork.Commit();
        }

        public IEnumerable<Game> GetAllFilteredGames(decimal minPrice, decimal maxPrice, int minNumberOfPlayers, int maxNumberOfPlayers, int minPlayersAge, int maxPlayersAge, Guid categoryId, ConditionType condition, DateTime releasedDateFrom, DateTime releasedDateTo)
        {
            var filteredGames = this.gamesRepository.GetAll(g =>
                minPrice <= g.Price
                && g.Price <= maxPrice
                //&& minNumberOfPlayers <= g.MinPlayers
                //&& maxNumberOfPlayers >= g.MaxPlayers
                //&& minPlayersAge <= g.MinAgeOfPlayers
                //&& maxPlayersAge <= g.MaxAgeOfPlayers
                //&& g.Categories.Where(c => c.Id == categoryId).Any()
                && releasedDateFrom <= g.ReleaseDate
                && g.ReleaseDate <= releasedDateTo
                && g.Condition == condition);

            return filteredGames;
        }
    }
}