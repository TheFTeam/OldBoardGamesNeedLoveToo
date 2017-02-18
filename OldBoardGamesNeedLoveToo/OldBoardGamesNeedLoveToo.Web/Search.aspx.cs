using System;
using System.Linq;
using System.Web.UI.WebControls;

using Microsoft.Owin;
using WebFormsMvp.Web;
using WebFormsMvp;

using System.Web.ModelBinding;
using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.MVP.Presenters;

namespace OldBoardGamesNeedLoveToo.Web
{
    [PresenterBinding(typeof(SearchPresenter))]
    public partial class Search : MvpPage<SearchViewModel>, ISearchView
    {
        public event EventHandler<SearchQueryParamsEventArgs> OnGetData;

        public IQueryable<Game> ListViewSearchResultsGames_GetData([QueryString] string q)
        {
            this.OnGetData?.Invoke(this, new SearchQueryParamsEventArgs(q));

            return this.Model.Games.ToList().AsQueryable();
        }
    }
}