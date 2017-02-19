using System;

using WebFormsMvp;
using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using System.Collections.Generic;

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

            this.View.SetSubmitAction(this.OnSubmit);
            this.View.OnPageInit += this.View_OnPageInit;
        }

        private void View_OnPageInit(object sender, EventArgs e)
        {
            this.View.Model.Categories = this.categoriesService.GetAllCategories();
        }

        public void OnSubmit()
        {
            IAddGameViewModel inputData = this.View.GetFormData();
            string name = inputData.Name;
            string content = inputData.Content;
            string description = inputData.Description;
            string language = inputData.Language;
            string producer = inputData.Producer;
            Guid ownerId = inputData.OwnerId;
            ConditionType condition;
            DateTime releaseDate;
            decimal price;
            int minPlayers;
            int maxPlayers;
            int minAgeofPlayers;
            int maxAgeOfPlayers;

            try
            {
                condition = (ConditionType) Enum.Parse(typeof(ConditionType), inputData.Condition);
                releaseDate = Convert.ToDateTime(inputData.ReleaseDate);
                price = decimal.Parse(inputData.Price);
                minPlayers = int.Parse(inputData.MinPlayers);
                maxPlayers = int.Parse(inputData.MaxPlayers);
                minAgeofPlayers = int.Parse(inputData.MinAgeOfPlayers);
                maxAgeOfPlayers = int.Parse(inputData.MaxAgeOfPlayers);

            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException(e.Message);
            }

            ICollection<Category> selectedCategories = new List<Category>();
            foreach (var selectedCategoryId in inputData.SelectedCategoryIds)
            {
                selectedCategories.Add(this.categoriesService.GetCategoryById(new Guid(selectedCategoryId)));
            }


            byte[] image = inputData.Image;

            Game newGame = this.gamesService.CreateGame(name, content, selectedCategories, condition, language, price, ownerId, releaseDate, image, producer, description, minPlayers, maxPlayers, minAgeofPlayers, maxAgeOfPlayers);
            this.gamesService.AddGame(newGame);
        }
    }
}