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

        Game CreateGame();

        void AddGame(Game game);

        void UpdateGame(Game game);

        void DeleteGame(Game game);
    }
}