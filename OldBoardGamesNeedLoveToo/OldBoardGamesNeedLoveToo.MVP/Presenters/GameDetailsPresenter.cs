using System.Linq;

using WebFormsMvp;
using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class GameDetailsPresenter : Presenter<IGameDetailsView>
    {
        private readonly IGamesService gamesService;

        public GameDetailsPresenter(IGameDetailsView view, IGamesService gamesService)
            : base(view)
        {
            Guard.WhenArgument(gamesService, "gamesService").IsNull().Throw();


            this.gamesService = gamesService;

            this.View.GameDatailsPageInit += this.View_GameDatailsPageInit;
        }

        private void View_GameDatailsPageInit(object sender, GameDetailsEventArgs e)
        {
            this.View.Model.Games = this.gamesService.GetAllGames().Where(g => g.Id == e.Id);
        }
    }
}