using System;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class GamesPresenter : Presenter<IGamesView>
    {
        private readonly string viewCannotBeNullExceptionMessage = "View can not be null.";
        private readonly string gamesRepositoryCannotBeNullExceptionMessage = "Games repository can not be null.";

        private readonly IGamesView view;
        private readonly IRepository<Game> gamesRepository;
        public GamesPresenter(IGamesView view, IRepository<Game> gamesRepository)
            : base(view)
        {
            if (view == null)
            {
                throw new ArgumentException(viewCannotBeNullExceptionMessage);
            }

            this.view = view;

            if (gamesRepository == null)
            {
                throw new ArgumentException(gamesRepositoryCannotBeNullExceptionMessage);
            }

            this.gamesRepository = gamesRepository;

            this.view.DefaultPageInit += View_DefaultPageInit;
        }

        private void View_DefaultPageInit(object sender, EventArgs e)
        {
            this.view.Model.Games = this.gamesRepository.GetAll();
        }
    }
}