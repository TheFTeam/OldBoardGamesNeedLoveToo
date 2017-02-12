using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public class UsersViewModel : IUsersViewModel
    {
        public IEnumerable<UserCustomInfo> Users { get; set; }        
    }
}
