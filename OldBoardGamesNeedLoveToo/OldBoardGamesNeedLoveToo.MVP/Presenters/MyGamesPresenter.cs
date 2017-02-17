﻿using System;
using System.Linq;

using WebFormsMvp;
using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class MyGamesPresenter : Presenter<IMyGamesView>
    {
        private readonly IGamesService gamesService;

        public MyGamesPresenter(IMyGamesView view, IGamesService gamesService)
            : base(view)
        {
            Guard.WhenArgument(gamesService, "gamesService").IsNull().Throw();

            this.gamesService = gamesService;

            this.View.MyGamesPageInit += View_MyGamesPageInit;
        }

        private void View_MyGamesPageInit(object sender, CustomEventArgs.MyGamesEventArgs e)
        {
            this.View.Model.Games = this.gamesService.GetAllGames().Where(x => x.OwnerId == e.Id);
        }
    }
}