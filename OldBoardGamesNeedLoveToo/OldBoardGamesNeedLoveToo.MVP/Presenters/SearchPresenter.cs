using Bytes2you.Validation;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class SearchPresenter : Presenter<ISearchView>
    {
        private readonly IGamesService gamesService;
        public SearchPresenter(ISearchView view, IGamesService gamesService)
            : base(view)
        {
            Guard.WhenArgument(gamesService, "gamesService").IsNull().Throw();

            this.gamesService = gamesService;

            this.View.OnGetData += this.View_OnGetData;
        }

        private void View_OnGetData(object sender, CustomEventArgs.SearchQueryParamsEventArgs e)
        {
            this.View.Model.Games = this.gamesService.GetGamesByName(e.QueryParams);
        }
    }
}