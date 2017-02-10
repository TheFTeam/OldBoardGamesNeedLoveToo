using System;
using System.Collections.Generic;

namespace OldBoardGamesNeedLoveToo.Models.Contracts
{
    public interface IUserCustomInfo
    {
        Guid Id { get; set; }

        string Username { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string ApplicationUserId { get; set; }

        ICollection<Game> BoughtGames { get; set; }

        ICollection<Game> SellingGames { get; set; }
    }
}