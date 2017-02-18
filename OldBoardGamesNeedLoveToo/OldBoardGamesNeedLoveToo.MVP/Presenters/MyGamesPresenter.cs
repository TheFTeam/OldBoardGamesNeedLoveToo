using WebFormsMvp;
using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class MyGamesPresenter : Presenter<IMyGamesView>
    {
        private readonly IGamesService gamesService;

        public MyGamesPresenter(IMyGamesView view, IGamesService gamesService)
            : base(view)
        {
            Guard.WhenArgument(gamesService, "gamesService").IsNull().Throw();

            this.gamesService = gamesService;

            this.View.OnGetData += this.View_OnGetData;
            this.View.OnUpdateItem += this.View_OnUpdateItem;
            this.View.OnDeleteItem += this.View_OnDeleteItem;
        }

        private void View_OnDeleteItem(object sender, CustomEventArgs.MyGamesEventArgs e)
        {
            Game gameToDelete = this.gamesService.GetGameById(e.Id);
            if (gameToDelete == null)
            {
                this.View.ModelState.AddModelError("", string.Format("Item with id {0} was not found", e.Id));
                return;
            }

            this.gamesService.DeleteGame(gameToDelete);
        }

        private void View_OnUpdateItem(object sender, CustomEventArgs.MyGamesEventArgs e)
        {
            Game game = this.gamesService.GetGameById(e.Id);

            if (game == null)
            {
                this.View.ModelState.AddModelError("", string.Format("Item with id {0} was not found", e.Id));
                return;
            }

            this.View.TryUpdateModel(game);
            if (this.View.ModelState.IsValid)
            {
                this.gamesService.UpdateGame(game);
            }
        }

        private void View_OnGetData(object sender, CustomEventArgs.MyGamesEventArgs e)
        {
            this.View.Model.Games = this.gamesService.GetAllGamesOfCurrentUser(e.Id);
        }
    }
}