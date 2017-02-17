using System;
using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public class UsersViewModel : IUsersViewModel
    {
        public IEnumerable<Game> Games { get; set; }

        public IEnumerable<UserCustomInfo> Users { get; set; }
    }
}