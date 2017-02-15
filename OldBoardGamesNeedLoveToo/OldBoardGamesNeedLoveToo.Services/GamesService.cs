using System;
using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using System.Linq;

namespace OldBoardGamesNeedLoveToo.Services
{
    public class GamesService : IGamesService
    {
        private readonly string gamesRepositoryCannotBeNullExceptinMessage = "Games repository can not be null";
        private readonly string unitOfWorkCannotBeNullExceptinMessage = "UnitfWork can not be null";

        private readonly IRepository<Game> gamesRepository;
        private readonly IUnitOfWork unitOfWork;

        public GamesService(IRepository<Game> gamesRepository, IUnitOfWork unitOfWork)
        {
            if (gamesRepository == null)
            {
                throw new ArgumentException(gamesRepositoryCannotBeNullExceptinMessage);
            }

            this.gamesRepository = gamesRepository;

            if (unitOfWork == null)
            {
                throw new ArgumentException(unitOfWorkCannotBeNullExceptinMessage);
            }

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

        public Game GetGameById(object id)
        {
            return this.gamesRepository.GetById(id);
        }

        public void UpdateGame(Game game)
        {
            this.gamesRepository.Update(game);
            this.unitOfWork.Commit();
        }
    }
}