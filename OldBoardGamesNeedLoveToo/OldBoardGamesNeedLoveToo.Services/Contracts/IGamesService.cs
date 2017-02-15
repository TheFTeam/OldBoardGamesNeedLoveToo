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

        Game CreateGame(string name, string contents, ConditionType condition, string language, decimal price, Guid ownerId, DateTime releaseDate, byte[] image, string producer = null, string description = null, int minPlayers = 1, int maxPlayers = 100, int minAgeOfPlayers = 2, int maxAgeOfPlayers = 100);

        void AddGame(Game game);

        void UpdateGame(Game game);

        void DeleteGame(Game game);
    }
}