using WebFormsMvp;

using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Views;
using System.Linq;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class GameDetailsPresenter : Presenter<IGameDetailsView>
    {
        private readonly IGameDetailsView view;
        private readonly EfRepository<Game> gamesRepository;

        public GameDetailsPresenter(IGameDetailsView view, EfRepository<Game> gamesRepository)
            : base(view)
        {
            this.view = view;
            this.gamesRepository = gamesRepository;

            this.view.GameDatailsPageInit += this.View_GameDatailsPageInit;
        }

        private void View_GameDatailsPageInit(object sender, GameDetailsEventArgs e)
        {
            this.view.Model.Games = this.gamesRepository.GetAll().Where(g => g.Id == e.Id);
        }
    }
}