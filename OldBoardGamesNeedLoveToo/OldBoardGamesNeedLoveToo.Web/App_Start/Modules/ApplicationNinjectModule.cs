﻿using Ninject.Modules;
using Ninject.Web.Common;

using OldBoardGamesNeedLoveToo.Data;
using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.Services.Contracts;
using OldBoardGamesNeedLoveToo.Services;
using OldBoardGamesNeedLoveToo.Models.Contracts;
using OldBoardGamesNeedLoveToo.Models;
using Ninject.Extensions.UnitOfWork;

namespace OldBoardGamesNeedLoveToo.Web.App_Start.Modules
{
    public class ApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IGame>().To<Game>();
            this.Bind<IUserCustomInfo>().To<UserCustomInfo>();

            this.Bind<ObgnltContext>().To<ObgnltContext>().InRequestScope();
            this.Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            this.Bind<IUsersService>().To<UsersService>().InRequestScope();
            this.Bind<IGamesService>().To<GamesService>().InRequestScope();
            this.Bind<ICategoriesService>().To<CategoriesService>().InRequestScope();
            this.Bind<ICommentsService>().To<CommentsService>().InRequestScope();


            this.Bind<IGamesViewModel>().To<GamesViewModel>();
            this.Bind<GamesListUserControlPresenter>().ToSelf();
            this.Bind<GameDetailsPresenter>().ToSelf();

            this.Bind<IAddGameViewModel>().To<AddGameViewModel>();
            this.Bind<AddGamePresenter>().ToSelf();

            this.Bind<IUsersViewModel>().To<UsersViewModel>();
            this.Bind<AccountInfoPresenter>().ToSelf();

            this.Bind<IAdminGamesViewModel>().To<AdminGamesViewModel>();
            this.Bind<AdminGamesPresenter>().ToSelf();

            this.Bind<IAdminUsersViewModel>().To<AdminUsersViewModel>();
            this.Bind<AdminUserPresenter>().ToSelf();
        }
    }
}