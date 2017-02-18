using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using System;
using WebFormsMvp;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class AdminGamesPresenter : Presenter<IAdminGamesView>
    {
        private readonly string viewCannotBeNullExceptionMessage = "View can not be null.";
        private readonly string gamesServiceCannotBeNullExceptionMessage = "Games service can not be null.";
        
        private readonly IGamesService gamesService;

        public AdminGamesPresenter(IAdminGamesView view, IGamesService gamesService) : base(view)
        {
            if (view == null)
            {
                throw new ArgumentException(viewCannotBeNullExceptionMessage);
            }
            if (gamesService == null)
            {
                throw new ArgumentException(gamesServiceCannotBeNullExceptionMessage);
            }

            this.gamesService = gamesService;
            

            this.View.AdminGetAllGames += View_AdminGetAllGames;
            this.View.AdminUpdateGames += View_AdminUpdateGames;
            this.View.AdminDeteleGame += View_AdminDeteleGame; ;

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
