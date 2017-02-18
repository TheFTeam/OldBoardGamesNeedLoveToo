using System;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface ISearchView : IView<SearchViewModel>
    {
        event EventHandler<SearchQueryParamsEventArgs> OnGetData;
    }
}