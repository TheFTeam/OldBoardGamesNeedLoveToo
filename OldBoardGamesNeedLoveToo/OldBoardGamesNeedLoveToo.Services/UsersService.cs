using System;
using System.Collections.Generic;

using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using System.Linq;

namespace OldBoardGamesNeedLoveToo.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<UserCustomInfo> userCustomInfoRepository;
        private readonly IUnitOfWork unitOfWork;

        public UsersService(IRepository<UserCustomInfo> userCustomInfoRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(userCustomInfoRepository, "userCustomInfoRepository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.userCustomInfoRepository = userCustomInfoRepository;
            this.unitOfWork = unitOfWork;
        }

        public UserCustomInfo GetUserCustomInfoById(object id)
        {
            return this.userCustomInfoRepository.GetById(id);
        }

        public void AddUserCustomInfo(UserCustomInfo userCustomInfo)
        {
            this.userCustomInfoRepository.Add(userCustomInfo);
            this.unitOfWork.Commit();
        }

        public UserCustomInfo CreateUserCustomInfo()
        {
            return new UserCustomInfo();
        }

        public IEnumerable<UserCustomInfo> GetAllUserCustomInfos()
        {
            return this.userCustomInfoRepository.GetAll();
        }

        public IEnumerable<Game> GetAllUserCustomInfoSellinGames(string username)
        {
            return this.userCustomInfoRepository.GetAll(u => u.Username == username).SelectMany(u => u.SellingGames);
        }

        public UserCustomInfo GetUserDetailsById(object id)
        {
            return this.userCustomInfoRepository.GetById(id);
        }

        public void UpdateUserCustomInfo(UserCustomInfo userCustomInfo)
        {
            this.userCustomInfoRepository.Update(userCustomInfo);
            this.unitOfWork.Commit();
        }

        public void SetApplicationUserIdToUserCustomInfo(UserCustomInfo userCustomInfo, string applicationUserId)
        {
            userCustomInfo.ApplicationUserId = applicationUserId;
            this.userCustomInfoRepository.Update(userCustomInfo);
            this.unitOfWork.Commit();
        }

        public void DeleteUserCustomInfo(UserCustomInfo userCustomInfo)
        {
            this.userCustomInfoRepository.Delete(userCustomInfo);
            this.unitOfWork.Commit();
        }
    }
}