using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using System;

using WebFormsMvp;
using WebFormsMvp.Web;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.Models;
using System.Linq;
using System.Collections.Generic;

namespace OldBoardGamesNeedLoveToo.Web.Admin
{
    [PresenterBinding(typeof(AdminGamesPresenter))]
    public partial class ManageGames : MvpPage<AdminGamesViewModel>, IAdminGamesView
    {
        public event EventHandler AdminGetAllCategories;
        public event EventHandler AdminGetAllGames;
        public event EventHandler<GameDetailsEventArgs> AdminUpdateGames;

        public void Admin_GetAllGames()
        {
            this.AdminGetAllGames?.Invoke(this, null);
        }

        public IQueryable<Game> ListViewGames_GetData()
        {
            this.AdminGetAllGames?.Invoke(this, null);

            return this.Model.Games.ToList().AsQueryable();
        }

        public void ListViewGames_UpdateItem(Guid id)
        {
            this.AdminUpdateGames?.Invoke(this, new GameDetailsEventArgs(id));
        }

        public ICollection<Category> ListViewGames_GetCategories()
        {
            this.AdminGetAllCategories?.Invoke(this, null);

            return this.Model.Categories.ToList();
        }
    }
}