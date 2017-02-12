using System;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface IGameDetailsView : IView<GamesViewModel>
    {
        event EventHandler<GameDetailsEventArgs> GameDatailsPageInit;
    }
}