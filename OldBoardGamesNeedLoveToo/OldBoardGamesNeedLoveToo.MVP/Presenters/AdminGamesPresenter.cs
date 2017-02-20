using System;

using WebFormsMvp;
using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class AdminGamesPresenter : Presenter<IAdminGamesView>
    {        
        private readonly IGamesService gamesService;

        public AdminGamesPresenter(IAdminGamesView view, IGamesService gamesService) : base(view)
        {
            Guard.WhenArgument(gamesService, "gamesService").IsNull().Throw();

            this.gamesService = gamesService;            

            this.View.AdminGetAllGames += this.View_AdminGetAllGames;
            this.View.AdminUpdateGames += this.View_AdminUpdateGames;
            this.View.AdminDeteleGame += this.View_AdminDeteleGame; 
        }

        private void View_AdminDeteleGame(object sender, CustomEventArgs.GameDetailsEventArgs e)
        {
            Game gameToDelete = this.gamesService.GetGameById(e.Id);
            if (gameToDelete == null)
            {
                this.View.ModelState.AddModelError("", string.Format("Item with id {0} was not found", e.Id));
                return;
            }

            this.gamesService.DeleteGame(gameToDelete);
        }

        private void View_AdminGetAllGames(object sender, EventArgs e)
        {
            this.View.Model.Games = this.gamesService.GetAllGames();
        }

        private void View_AdminUpdateGames(object sender, CustomEventArgs.GameDetailsEventArgs e)
        {
            Game gameToBeUpadeted = this.gamesService.GetGameById(e.Id);
            if (gameToBeUpadeted == null)
            {
                this.View.ModelState.AddModelError("", string.Format("Item with id {0} was not found", e.Id));
                return;
            }
            this.View.TryUpdateModel(gameToBeUpadeted);
            if (this.View.ModelState.IsValid)
            {
                this.gamesService.UpdateGame(gameToBeUpadeted);
            }
        }

        
    }
}
