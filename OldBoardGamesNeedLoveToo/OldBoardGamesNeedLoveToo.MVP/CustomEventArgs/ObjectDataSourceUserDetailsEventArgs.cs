using OldBoardGamesNeedLoveToo.Services.Contracts;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class ObjectDataSourceUserDetailsEventArgs
    {
        public ObjectDataSourceUserDetailsEventArgs(IUserService service)
        {
            this.ObjectInstance = service;
        }

        public IUserService ObjectInstance { get; set; }
    }
}