using System.Linq;

using WebFormsMvp;
using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;

namespace OldBoardGamesNeedLoveToo.MVP.Presenters
{
    public class UserProfilePresenter : Presenter<IUserProfileView>
    {
        private readonly IUsersService usersService;
        private readonly IGamesService gamesService;

        public UserProfilePresenter(IUserProfileView view, IUsersService usersService, IGamesService gamesService) : base(view)
        {
            Guard.WhenArgument(usersService, "usersService").IsNull().Throw();
            Guard.WhenArgument(gamesService, "gamesService").IsNull().Throw();

            this.usersService = usersService;
            this.gamesService = gamesService;

            this.View.OnUserProfilePageInit += this.View_OnUserProfilePageInit;
        }

        private void View_OnUserProfilePageInit(object sender, UserDetailsByUsernameEventArgs e)
        {

            this.View.Model.Users = this.usersService.GetAllUserCustomInfos().Where(u => u.Username == e.Username);
            this.View.Model.Games = this.usersService.GetAllUserCustomInfoSellinGames(e.Username);
        }
    }
}