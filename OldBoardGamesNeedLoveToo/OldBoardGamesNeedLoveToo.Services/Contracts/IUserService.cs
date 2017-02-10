using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBoardGamesNeedLoveToo.Services.Contracts
{
    public interface IUserService
    {
        UserCustomInfo GetUserCustomInfoById(object id);

        IEnumerable<UserCustomInfo> GetAllUserCustomInfos();

        void SetApplicationUserIdToUserCustomInfo(UserCustomInfo userCustomInfo, string applicationUserId);

        UserCustomInfo CreateUserCustomInfo();

        void AddUserCustomInfo(UserCustomInfo userCustomInfo);

        void UpdateUserCustomInfo(UserCustomInfo userCustomInfo);

        void DeleteUserCustomInfo(UserCustomInfo userCustomInfo);
    }
}