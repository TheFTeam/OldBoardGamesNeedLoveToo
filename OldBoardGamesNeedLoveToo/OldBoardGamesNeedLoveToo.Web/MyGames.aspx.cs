using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using WebFormsMvp;
using WebFormsMvp.Web;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.Auth;

namespace OldBoardGamesNeedLoveToo.Web
{
    [PresenterBinding(typeof(MyGamesPresenter))]
    public partial class MyGames : MvpPage<GamesViewModel>, IMyGamesView
    {
        public event EventHandler<MyGamesEventArgs> OnGetData;
        public event EventHandler<MyGamesEventArgs> OnDeleteItem;
        public event EventHandler<MyGamesEventArgs> OnUpdateItem;

        public IQueryable<Game> GridViewMyGames_GetData()
        {
            Guid id = GetCurrentUserCustomInfoId();
            this.OnGetData?.Invoke(this, new MyGamesEventArgs(id));

            return this.Model.Games.ToList().AsQueryable();
        }

        public void GridViewMyGames_UpdateItem(Guid Id)
        {
            this.OnUpdateItem?.Invoke(this, new MyGamesEventArgs(Id));
        }

        public void GridViewMyGames_DeleteItem(Guid Id)
        {
            this.OnDeleteItem?.Invoke(this, new MyGamesEventArgs(Id));
        }

        private Guid GetCurrentUserCustomInfoId()
        {
            ApplicationUser user = HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(HttpContext.Current.User.Identity.GetUserId());
            Guid id = user.UserCustomInfo.Id;

            return id;
        }
    }
}