using Ninject.Modules;
using Ninject.Web.Common;

using OldBoardGamesNeedLoveToo.Data;
using OldBoardGamesNeedLoveToo.Data.Repositories;
using OldBoardGamesNeedLoveToo.Data.UnitOfWork;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.MVP.Presenters;

namespace OldBoardGamesNeedLoveToo.Web.App_Start.Modules
{
    public class ApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IObgnltContext>().To<ObgnltContext>().InRequestScope();
            this.Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));
            this.Bind<IUnitOfWork>().To<UnitOfWork>();

            this.Bind<IGamesViewModel>().To<GamesViewModel>();
            this.Bind<GamesPresenter>().ToSelf();
            this.Bind<GameDetailsPresenter>().ToSelf();
        }
    }
}