using System;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface IAddGameView : IView<AddGameViewModel>
    {
        event EventHandler OnPageInit;

        event EventHandler<AddGameEventArgs> OnAddGameSubmit;
    }
}