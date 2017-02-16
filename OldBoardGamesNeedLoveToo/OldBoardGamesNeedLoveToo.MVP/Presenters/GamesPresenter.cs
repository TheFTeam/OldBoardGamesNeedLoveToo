using System;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class GamesPresenter : Presenter<IGamesView>
    {
        private readonly string viewCannotBeNullExceptionMessage = "View can not be null.";
        private readonly string gamesServiceCannotBeNullExceptionMessage = "Games service can not be null.";
        private readonly string categoriesServiceCannotBeNullExceptionMessage = "Categories service can not be null.";

        private readonly IGamesView view;
        private readonly IGamesService gamesService;
        private readonly ICategoryService categoryService;

        public GamesPresenter(IGamesView view, IGamesService gamesService, ICategoryService categoryService)
            : base(view)
        {
            if (view == null)
            {
                throw new ArgumentException(viewCannotBeNullExceptionMessage);
            }

            this.view = view;

            if (gamesService == null)
            {
                throw new ArgumentException(gamesServiceCannotBeNullExceptionMessage);
            }

            this.gamesService = gamesService;

            if (categoryService == null)
            {
                throw new ArgumentException(categoriesServiceCannotBeNullExceptionMessage);
            }

            this.categoryService = categoryService;

            this.view.DefaultPageInit += View_DefaultPageInit;
            this.view.OnButtonFilterSubmit += View_OnButtonFilterSubmit;
        }

        private void View_OnButtonFilterSubmit(object sender, CustomEventArgs.FilterGamesEventArgs e)
        {
            decimal minPrice;
            decimal maxPrice;
            int minNumberOfPlayers;
            int maxNumberOfPlayers;
            int minAgefPlayers;
            int maxAgeOfPlayers;
            ConditionType condition;
            DateTime releaseDateFrom;
            DateTime releaseDateTo;
            Guid categoryId;

            try
            {
                minPrice = decimal.Parse(e.MinPrice);
                maxPrice = decimal.Parse(e.MaxPrice);
                minNumberOfPlayers = int.Parse(e.MinNumberOfPlayers);
                maxNumberOfPlayers = int.Parse(e.MaxNumberOfPlayers);
                minAgefPlayers = int.Parse(e.MinPlayersAge);
                maxAgeOfPlayers = int.Parse(e.MaxPlayersAge);
                releaseDateFrom = Convert.ToDateTime(e.ReleasedateFrom);
                releaseDateTo = Convert.ToDateTime(e.ReleaseDateTo);
                categoryId = new Guid(e.CategoryId);
                condition = (ConditionType) Enum.Parse(typeof(ConditionType), e.Condition);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            this.view.Model.Games = this.gamesService.GetAllFilteredGames(minPrice, maxPrice, minNumberOfPlayers, maxNumberOfPlayers, minAgefPlayers, maxAgeOfPlayers, categoryId, condition, releaseDateFrom, releaseDateTo);
        }

        private void View_DefaultPageInit(object sender, EventArgs e)
        {
            this.view.Model.Games = this.gamesService.GetAllGames();
            this.view.Model.Categories = this.categoryService.GetAllCategories();
        }
    }
}