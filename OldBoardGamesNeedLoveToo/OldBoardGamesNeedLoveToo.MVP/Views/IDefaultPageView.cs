using System;

using WebFormsMvp;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface IDefaultPageView : IView<GamesViewModel>
    {
        event EventHandler DefaultPageInit;
    }
}