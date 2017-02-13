using System;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class AddGamePresenter : Presenter<IAddGameView>
    {
        private readonly IAddGameView view;
        private readonly IGamesService service;

        public AddGamePresenter(IAddGameView view, IGamesService service) : base(view)
        {
            this.view = view;
            this.service = service;

            this.view.SetSubmitAction(this.OnSubmit);
        }

        public void OnSubmit()
        {
            IAddGameViewModel inputData = this.view.GetFormData();
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


            Game newGame = this.service.CreateGame(name, content, condition, language, price, ownerId, releaseDate, producer, description, null, minPlayers, maxPlayers, minAgeofPlayers, maxAgeOfPlayers);
            this.service.AddGame(newGame);
        }
    }
}