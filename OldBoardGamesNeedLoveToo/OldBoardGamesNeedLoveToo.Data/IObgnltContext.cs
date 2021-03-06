﻿using System.Data.Entity;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Data
{
    public interface IObgnltContext
    {
        IDbSet<Game> Games { get; set; }

        IDbSet<UserCustomInfo> UsersCustomInfo { get; set; }
    }
}