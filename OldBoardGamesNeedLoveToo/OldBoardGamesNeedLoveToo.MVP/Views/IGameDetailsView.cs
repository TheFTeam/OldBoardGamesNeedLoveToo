using System;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface IGameDetailsView : IView<GamesViewModel>
    {
        event EventHandler<GameDetailsEventArgs> GameDatailsPageInit;
    }
}