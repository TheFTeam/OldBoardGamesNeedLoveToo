using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using System;

using WebFormsMvp;
using WebFormsMvp.Web;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.Models;
using System.Linq;

namespace OldBoardGamesNeedLoveToo.Web.Admin
{
    [PresenterBinding(typeof(AdminGamesPresenter))]
    public partial class ManageGames : MvpPage<AdminGamesViewModel>, IAdminGamesView
    {
        public event EventHandler AdminGetAllGames;
        public event EventHandler<GameDetailsEventArgs> AdminDeteleGame;
        public event EventHandler<GameDetailsEventArgs> AdminUpdateGames;

        public IQueryable<Game> GridViewManageGames_GetData()
        {
            this.AdminGetAllGames?.Invoke(this, null);

            return this.Model.Games.ToList().AsQueryable();
        }

        public void GridViewManageGames_UpdateItem(Guid id)
        {
            this.AdminUpdateGames?.Invoke(this, new GameDetailsEventArgs(id));
        }

        public void GridViewManageGames_DeleteItem(Guid id)
        {
            this.AdminDeteleGame?.Invoke(this, new GameDetailsEventArgs(id));
        }
    }
}