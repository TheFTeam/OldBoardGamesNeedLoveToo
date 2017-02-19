using System;
using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Services.Contracts
{
    public interface IGamesService
    {
        Game GetGameById(object id);

        IEnumerable<Game> GetAllGames();

        IEnumerable<Game> GetAllGamesOfCurrentUser(Guid id);

        IEnumerable<Game> GetAllFilteredGames(decimal minPrice, decimal maxPrice, int minNumberOfPlayers, int maxNumberOfPlayers, int minPlayersAge, int maxPlayersAge, Guid categoryId, ConditionType condition, DateTime releasedDateFrom, DateTime releasedDateTo);

        IEnumerable<Game> GetGamesByName(string name);

        Game CreateGame(string name, string contents, ICollection<Category> categories, ConditionType condition, string language, decimal price, Guid ownerId, DateTime releaseDate, byte[] image, string producer = null, string description = null, int minPlayers = 1, int maxPlayers = 100, int minAgeOfPlayers = 2, int maxAgeOfPlayers = 100);

        void AddGame(Game game);

        void UpdateGame(Game game);

        void DeleteGame(Game game);
    }
}