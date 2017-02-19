using System.Linq;

using WebFormsMvp;
using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class AccountInfoPresenter : Presenter<IAccountInfoView>
    {
        private readonly IUsersService usersService;

        public AccountInfoPresenter(IAccountInfoView view, IUsersService usersService)
            : base(view)
        {
            Guard.WhenArgument(usersService, "usersService").IsNull().Throw();

            this.usersService = usersService;

            this.View.OnGetData += View_OnGetData;
            this.View.OnUpdateItem += View_OnUpdateItem;
        }

        private void View_OnUpdateItem(object sender, CustomEventArgs.UserDetailsByIdEventArgs e)
        {
            UserCustomInfo userToUpdate = this.usersService.GetUserCustomInfoById(e.Id);

            if (userToUpdate == null)
            {
                this.View.ModelState.AddModelError("", string.Format("Item with id {0} was not found", e.Id));
                return;
            }

            this.View.TryUpdateModel(userToUpdate);
            if (this.View.ModelState.IsValid)
            {
                this.usersService.UpdateUserCustomInfo(userToUpdate);
            }
        }

        private void View_OnGetData(object sender, CustomEventArgs.UserDetailsByIdEventArgs e)
        {
            this.View.Model.Users = this.usersService.GetAllUserCustomInfos().Where(x => x.Id == e.Id);
        }
    }
}