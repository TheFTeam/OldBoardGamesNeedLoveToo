using System;
using System.Collections.Generic;
using System.Linq;

using Bytes2you.Validation;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;

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
            Guard.WhenArgument(userCustomInfo, "userCustomInfo").IsNull().Throw();

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

        public void UpdateUserCustomInfo(UserCustomInfo userCustomInfo)
        {
            Guard.WhenArgument(userCustomInfo, "userCustomInfo").IsNull().Throw();

            this.userCustomInfoRepository.Update(userCustomInfo);
            this.unitOfWork.Commit();
        }

        public void UpdateUserCustomInfoWithRatingValue(int? ratingValue, string username)
        {
            Guard.WhenArgument(username, "username").IsNull().Throw();

            UserCustomInfo userToUpdate = this.userCustomInfoRepository.GetAll(u => u.Username == username).FirstOrDefault();

            Guard.WhenArgument(userToUpdate, "userToUpdate").IsNull().Throw();

            userToUpdate.NumberOfUsersGivenRating += 1;
            userToUpdate.SumOfUsersRating += ratingValue;

            if (userToUpdate.NumberOfUsersGivenRating == 0)
            {
                userToUpdate.NumberOfUsersGivenRating = 1;
            }

            if (userToUpdate.SumOfUsersRating == null || userToUpdate.SumOfUsersRating == 0)
            {
                userToUpdate.SumOfUsersRating = 1;
            }
            userToUpdate.AverageRatingResult = (double) userToUpdate.SumOfUsersRating / userToUpdate.NumberOfUsersGivenRating;
            this.UpdateUserCustomInfo(userToUpdate);
        }

        public void SetApplicationUserIdToUserCustomInfo(UserCustomInfo userCustomInfo, string applicationUserId)
        {
            Guard.WhenArgument(userCustomInfo, "userCustomInfo").IsNull().Throw();
            Guard.WhenArgument(applicationUserId, "applicationUserId").IsNull().Throw();

            userCustomInfo.ApplicationUserId = applicationUserId;
            this.userCustomInfoRepository.Update(userCustomInfo);
            this.unitOfWork.Commit();
        }

        public void DeleteUserCustomInfo(UserCustomInfo userCustomInfo)
        {
            Guard.WhenArgument(userCustomInfo, "userCustomInfo").IsNull().Throw();

            this.userCustomInfoRepository.Delete(userCustomInfo);
            this.unitOfWork.Commit();
        }

        public double GetAverageUserRating(string username)
        {
            Guard.WhenArgument(username, "username").IsNull().Throw();

            UserCustomInfo user = this.userCustomInfoRepository.GetAll(u => u.Username == username).FirstOrDefault();

            Guard.WhenArgument(user, "user").IsNull().Throw();

            return user.AverageRatingResult;
        }
    }
}