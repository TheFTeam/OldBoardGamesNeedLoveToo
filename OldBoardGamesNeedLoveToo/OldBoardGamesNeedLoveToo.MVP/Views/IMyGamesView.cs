using System;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using WebFormsMvp;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface IMyGamesView : IView<GamesViewModel>
    {
        event EventHandler<MyGamesEventArgs> MyGamesPageInit;
    }
}