﻿using System;
using System.Collections.Generic;
using System.Linq;

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
            this.gamesRepository.Add(game);
            this.unitOfWork.Commit();
        }

        public Game CreateGame(string name, string contents, ConditionType condition, string language, decimal price, Guid ownerId, DateTime releaseDate, byte[] image, string producer = null, string description = null, int minPlayers = 1, int maxPlayers = 100, int minAgeOfPlayers = 2, int maxAgeOfPlayers = 100)
        {
            return new Game()
            {
                Name = name,
                Contents = contents,
                Condition = condition,
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
            this.gamesRepository.Delete(game);
            this.unitOfWork.Commit();
        }

        public IEnumerable<Game> GetAllGames()
        {
            return this.gamesRepository.GetAll();
        }

        public IEnumerable<Game> GetAllGamesOfCurrentUser(Guid id)
        {
            return this.gamesRepository.GetAll().Where(x => x.OwnerId == id);
        }

        public IEnumerable<Game> GetGamesByName(string name)
        {
            return string.IsNullOrEmpty(name) ? this.gamesRepository.GetAll()
                : this.gamesRepository.GetAll().Where(g =>
                (string.IsNullOrEmpty(g.Name) ? false : g.Name.ToLower().Contains(name.ToLower())));
        }

        public Game GetGameById(object id)
        {
            return this.gamesRepository.GetById(id);
        }

        public void UpdateGame(Game game)
        {
            this.gamesRepository.Update(game);
            this.unitOfWork.Commit();
        }

        public IEnumerable<Game> GetAllFilteredGames(decimal minPrice, decimal maxPrice, int minNumberOfPlayers, int maxNumberOfPlayers, int minPlayersAge, int maxPlayersAge, Guid categoryId, ConditionType condition, DateTime releasedDateFrom, DateTime releasedDateTo)
        {
            //var categories = this.categoriesRepository.GetAll().Where(c => c.Id == categoryId);
            //var filteredGamesByCategory = categories.Select(c => c.Games);

            var filteredGames = this.gamesRepository.GetAll()
                .Where(g =>
                minPrice <= g.Price
                && g.Price <= maxPrice
                //&& minNumberOfPlayers <= g.MinPlayers
                //&& maxNumberOfPlayers >= g.MaxPlayers
                //&& minPlayersAge <= g.MinAgeOfPlayers
                //&& maxPlayersAge <= g.MaxAgeOfPlayers
                && releasedDateFrom <= g.ReleaseDate
                && g.ReleaseDate <= releasedDateTo
                && g.Condition == condition);

            return filteredGames;
        }
    }
}