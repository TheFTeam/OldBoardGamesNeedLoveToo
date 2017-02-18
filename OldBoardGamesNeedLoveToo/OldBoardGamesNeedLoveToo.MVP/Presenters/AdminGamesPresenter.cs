using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class AdminGamesPresenter : Presenter<IAdminGamesView>
    {
        private readonly string viewCannotBeNullExceptionMessage = "View can not be null.";
        private readonly string gamesServiceCannotBeNullExceptionMessage = "Games service can not be null.";
        private readonly string categoriesServiceCannotBeNullExceptionMessage = "categories service can not be null";


        private readonly IGamesService gamesService;
        private readonly ICategoryService categoriesService;

        public AdminGamesPresenter(IAdminGamesView view, IGamesService gamesService, ICategoryService categoriesService) : base(view)
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

            if (categoriesService == null)
            {
                throw new ArgumentException(categoriesServiceCannotBeNullExceptionMessage);
            }

            this.categoriesService = categoriesService;

            this.View.AdminGetAllGames += View_AdminGetAllGames;
            this.View.AdminUpdateGames += View_AdminUpdateGames;
            this.View.AdminGetAllCategories += View_AdminGetAllCategories;

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
                this.View.ModelState.AddModelError("", String.Format("Item with id {0} was not found", e.Id));
                return;
            }
            this.View.TryUpdateModel(gameToBeUpadeted);
            if (this.View.ModelState.IsValid)
            {
                this.gamesService.UpdateGame(gameToBeUpadeted);
            }
        }

        private void View_AdminGetAllCategories(object sender, EventArgs e)
        {
            this.View.Model.Categories = this.categoriesService.GetAllCategories();
        }


    }
}
