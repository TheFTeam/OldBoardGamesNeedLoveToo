﻿using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;
using System;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface IAdminGamesView : IView<AdminGamesViewModel>
    {
        event EventHandler AdminGetAllGames;
        event EventHandler<GameDetailsEventArgs> AdminDeteleGame;
        event EventHandler<GameDetailsEventArgs> AdminUpdateGames;
        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
