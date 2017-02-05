using System;
using WebFormsMvp;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface IGamesView : IView<GamesViewModel>
    {
        event EventHandler DefaultPageInit;
    }
}