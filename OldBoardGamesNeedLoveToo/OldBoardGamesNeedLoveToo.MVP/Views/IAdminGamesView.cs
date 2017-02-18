using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
