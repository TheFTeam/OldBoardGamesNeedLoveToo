using System;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;

using WebFormsMvp;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface IGamesView : IView<GamesViewModel>
    {
        event EventHandler DefaultPageInit;

        event EventHandler<FilterGamesEventArgs> OnButtonFilterSubmit;
    }
}