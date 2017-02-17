using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class ObjectDataSourceUserDetailsEventArgs
    {
        public ObjectDataSourceUserDetailsEventArgs(IUsersService service)
        {
            this.ObjectInstance = service;
        }

        public IUsersService ObjectInstance { get; set; }
    }
}