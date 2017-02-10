using System;
using System.Linq;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Views;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class GameDetailsPresenter : Presenter<IGameDetailsView>
    {
        private readonly string viewCannotBeNullExceptionMessage = "View can not be null.";
        private readonly string gamesRepositoryCannotBeNullExceptionMessage = "Games repository can not be null.";

        private readonly IGameDetailsView view;
        private readonly EfRepository<Game> gamesRepository;

        public GameDetailsPresenter(IGameDetailsView view, EfRepository<Game> gamesRepository)
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

            this.view.GameDatailsPageInit += this.View_GameDatailsPageInit;
        }

        private void View_GameDatailsPageInit(object sender, GameDetailsEventArgs e)
        {
            this.view.Model.Games = this.gamesRepository.GetAll().Where(g => g.Id == e.Id);
        }
    }
}