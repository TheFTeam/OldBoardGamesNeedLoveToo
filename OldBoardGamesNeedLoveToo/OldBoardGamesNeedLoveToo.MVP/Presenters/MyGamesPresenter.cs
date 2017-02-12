using System;
using System.Linq;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class MyGamesPresenter : Presenter<IMyGamesView>
    {
        private readonly string viewCannotBeNullExceptionMessage = "View can not be null.";
        private readonly string serviceCannotBeNullExceptionMessage = "Service cannot be null";

        private readonly IMyGamesView view;
        private readonly IGamesService service;

        public MyGamesPresenter(IMyGamesView view, IGamesService service) : base(view)
        {
            if (view == null)
            {
                throw new ArgumentException(viewCannotBeNullExceptionMessage);
            }

            this.view = view;

            if (service == null)
            {
                throw new ArgumentException(serviceCannotBeNullExceptionMessage);
            }

            this.service = service;

            this.view.MyGamesPageInit += View_MyGamesPageInit;
        }

        private void View_MyGamesPageInit(object sender, CustomEventArgs.MyGamesEventArgs e)
        {
            this.view.Model.Games = this.service.GetAllGames().Where(x => x.OwnerId == e.Id);
        }
    }
}
