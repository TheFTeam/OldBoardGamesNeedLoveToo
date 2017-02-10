using System;
using System.Collections.Generic;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.Models.Contracts;

using OldBoardGamesNeedLoveToo.Services.Contracts;
using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;

namespace OldBoardGamesNeedLoveToo.Services
{
    public class UserService : IUserService
    {
        private readonly string userCustomRpositoryCannotBeNullExceptinMessage = "UserCustomInfo repository can not be null";
        private readonly string unitOfWorkCannotBeNullExceptinMessage = "UnitfWork can not be null";

        private readonly IRepository<UserCustomInfo> userCustomInfoRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<UserCustomInfo> userCustomInfoRepository, IUnitOfWork unitOfWork)
        {
            if (userCustomInfoRepository == null)
            {
                throw new ArgumentException(userCustomRpositoryCannotBeNullExceptinMessage);
            }

            this.userCustomInfoRepository = userCustomInfoRepository;

            if (unitOfWork == null)
            {
                throw new ArgumentException(unitOfWorkCannotBeNullExceptinMessage);
            }

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