using System;
using System.Linq;
using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class AccountInfoPresenter : Presenter<IAccountInfoView>
    {
        private readonly string viewCannotBeNullExceptionMessage = "View can not be null.";

        private readonly IAccountInfoView view;
        private readonly IUserService service;

        public AccountInfoPresenter(IAccountInfoView view, IUserService service)
            : base(view)
        {
            if (view == null)
            {
                throw new ArgumentException(viewCannotBeNullExceptionMessage);
            }

            this.view = view;

            if (service == null)
            {
                throw new ArgumentException("Service cannot be null");
            }

            this.service = service;

            this.view.DefaultPageInit += View_DefaultPageInit;
            this.view.ObjectCreating += View_ObjectCreating;
        }

        private void View_ObjectCreating(object sender, CustomEventArgs.ObjectDataSourceUserDetailsEventArgs e)
        {
            e.ObjectInstance = this.service;
        }

        private void View_DefaultPageInit(object sender, CustomEventArgs.UserDetailsEventArgs e)
        {
            this.view.Model.Users = this.service.GetAllUserCustomInfos().Where(x => x.Id == e.Id);
        }
    }
}