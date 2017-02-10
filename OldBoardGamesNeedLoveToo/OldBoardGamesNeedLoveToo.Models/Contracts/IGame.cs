using System;

namespace OldBoardGamesNeedLoveToo.Models.Contracts
{
    public interface IGame
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Desription { get; set; }

        string Contents { get; set; }

        byte[] Image { get; set; }

        ConditionType Condition { get; set; }

        int MinPlayers { get; set; }

        int MaxPlayers { get; set; }

        int MinAgeOfPlayers { get; set; }

        int MaxAgeOfPlayers { get; set; }

        string Language { get; set; }

        DateTime ReleaseDate { get; set; }

        DateTime AddedOnDate { get; }

        string Producer { get; set; }

        decimal Price { get; set; }

        bool isSold { get; set; }

        Guid OwnerId { get; set; }

        Guid? BuyerId { get; set; }
    }
}
