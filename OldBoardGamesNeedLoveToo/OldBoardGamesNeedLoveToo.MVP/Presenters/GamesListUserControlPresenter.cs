using System;

using WebFormsMvp;
using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class GamesListUserControlPresenter : Presenter<IGamesView>
    {
        private readonly IGamesService gamesService;
        private readonly ICategoriesService categoriesService;

        public GamesListUserControlPresenter(IGamesView view, IGamesService gamesService, ICategoriesService categoriesService)
            : base(view)
        {
            Guard.WhenArgument(gamesService, "gamesService").IsNull().Throw();
            Guard.WhenArgument(categoriesService, "categoriesService").IsNull().Throw();

            this.gamesService = gamesService;
            this.categoriesService = categoriesService;

            this.View.DefaultPageInit += View_DefaultPageInit;
            this.View.OnButtonFilterSubmit += View_OnButtonFilterSubmit;
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
            catch (FormatException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch(ArgumentException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            this.View.Model.Games = this.gamesService.GetAllFilteredGames(minPrice, maxPrice, minNumberOfPlayers, maxNumberOfPlayers, minAgefPlayers, maxAgeOfPlayers, categoryId, condition, releaseDateFrom, releaseDateTo);
        }

        private void View_DefaultPageInit(object sender, EventArgs e)
        {
            this.View.Model.Categories = this.categoriesService.GetAllCategories();
        }
    }
}