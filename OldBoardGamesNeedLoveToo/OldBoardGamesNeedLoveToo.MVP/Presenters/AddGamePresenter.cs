using System;
using System.Collections.Generic;

using WebFormsMvp;
using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class AddGamePresenter : Presenter<IAddGameView>
    {
        private readonly IGamesService gamesService;
        private readonly ICategoriesService categoriesService;

        public AddGamePresenter(IAddGameView view, IGamesService gamesService, ICategoriesService categoriesService)
            : base(view)
        {
            Guard.WhenArgument(gamesService, "gamesService").IsNull().Throw();
            Guard.WhenArgument(categoriesService, "categoriesService").IsNull().Throw();

            this.gamesService = gamesService;
            this.categoriesService = categoriesService;

            this.View.OnPageInit += this.View_OnPageInit;
            this.View.OnAddGameSubmit += this.View_OnAddGameSubmit;
        }

        private void View_OnAddGameSubmit(object sender, AddGameEventArgs e)
        {
            string name = e.Name;
            string content = e.Content;
            string description = e.Description;
            string language = e.Language;
            string producer = e.Producer;
            Guid ownerId = e.OwnerId;
            ConditionType condition;
            DateTime releaseDate;
            decimal price;
            int minPlayers;
            int maxPlayers;
            int minAgeofPlayers;
            int maxAgeOfPlayers;

            try
            {
                condition = (ConditionType) Enum.Parse(typeof(ConditionType), e.Condition);
                releaseDate = Convert.ToDateTime(e.ReleaseDate);
                price = decimal.Parse(e.Price);
                minPlayers = int.Parse(e.MinPlayers);
                maxPlayers = int.Parse(e.MaxPlayers);
                minAgeofPlayers = int.Parse(e.MinAgeOfPlayers);
                maxAgeOfPlayers = int.Parse(e.MaxAgeOfPlayers);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            ICollection<Category> selectedCategories = new List<Category>();
            foreach (var selectedCategoryId in e.SelectedCategoryIds)
            {
                selectedCategories.Add(this.categoriesService.GetCategoryById(new Guid(selectedCategoryId)));
            }


            byte[] image = e.Image;

            Game newGame = this.gamesService.CreateGame(name, content, selectedCategories, condition, language, price, ownerId, releaseDate, image, producer, description, minPlayers, maxPlayers, minAgeofPlayers, maxAgeOfPlayers);
            this.gamesService.AddGame(newGame);
        }

        private void View_OnPageInit(object sender, EventArgs e)
        {
            this.View.Model.Categories = this.categoriesService.GetAllCategories();
        }
    }
}