using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Services.Contracts
{
    public interface IUsersService
    {
        UserCustomInfo GetUserCustomInfoById(object id);

        IEnumerable<UserCustomInfo> GetAllUserCustomInfos();

        IEnumerable<Game> GetAllUserCustomInfoSellinGames(string username);

        void SetApplicationUserIdToUserCustomInfo(UserCustomInfo userCustomInfo, string applicationUserId);

        UserCustomInfo CreateUserCustomInfo();

        void AddUserCustomInfo(UserCustomInfo userCustomInfo);

        void UpdateUserCustomInfo(UserCustomInfo userCustomInfo);

        void DeleteUserCustomInfo(UserCustomInfo userCustomInfo);
    }
}