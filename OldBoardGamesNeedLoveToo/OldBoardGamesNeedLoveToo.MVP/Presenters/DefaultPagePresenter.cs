using System;

using WebFormsMvp;
using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class DefaultPagePresenter : Presenter<IDefaultPageView>
    {
        private readonly IGamesService gamesService;
        public DefaultPagePresenter(IDefaultPageView view, IGamesService gamesService)
            : base(view)
        {
            Guard.WhenArgument(gamesService, "gamesService").IsNull().Throw();

            this.gamesService = gamesService;

            this.View.DefaultPageInit += this.View_DefaultPageInit;
        }

        private void View_DefaultPageInit(object sender, EventArgs e)
        {
            this.View.Model.Games = this.gamesService.GetAllGames();
        }
    }
}