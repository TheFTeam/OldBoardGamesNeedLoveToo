using System;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class GamesPresenter : Presenter<IGamesView>
    {
        private readonly IGamesView view;
        private readonly IRepository<Game> gamesRepository;
        public GamesPresenter(IGamesView view, IRepository<Game> gamesRepository)
            : base(view)
        {
            this.view = view;
            this.gamesRepository = gamesRepository;

            this.view.DefaultPageInit += View_DefaultPageInit;
        }

        private void View_DefaultPageInit(object sender, EventArgs e)
        {
            this.view.Model.Games = this.gamesRepository.GetAll();
        }
    }
}
