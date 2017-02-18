using System;
using System.Web.ModelBinding;

using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    public interface IMyGamesView : IView<GamesViewModel>
    {
        event EventHandler<MyGamesEventArgs> OnGetData;

        event EventHandler<MyGamesEventArgs> OnDeleteItem;

        event EventHandler<MyGamesEventArgs> OnUpdateItem;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}