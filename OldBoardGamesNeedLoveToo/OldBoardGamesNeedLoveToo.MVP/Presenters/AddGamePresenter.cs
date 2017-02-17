using System;

using WebFormsMvp;
using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class AddGamePresenter : Presenter<IAddGameView>
    {
        private readonly IGamesService gamesService;

        public AddGamePresenter(IAddGameView view, IGamesService gamesService)
            : base(view)
        {
            Guard.WhenArgument(gamesService, "gamesService").IsNull().Throw();

            this.gamesService = gamesService;

            this.View.SetSubmitAction(this.OnSubmit);
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

            byte[] image = inputData.Image;

            Game newGame = this.gamesService.CreateGame(name, content, condition, language, price, ownerId, releaseDate, image, producer, description, minPlayers, maxPlayers, minAgeofPlayers, maxAgeOfPlayers);
            this.gamesService.AddGame(newGame);
        }
    }
}