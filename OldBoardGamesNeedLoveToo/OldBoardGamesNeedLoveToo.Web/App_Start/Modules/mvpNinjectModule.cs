﻿using System;
using System.Linq;

using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;

using WebFormsMvp;
using WebFormsMvp.Binder;

using OldBoardGamesNeedLoveToo.Web.App_Start.Factories;

namespace OldBoardGamesNeedLoveToo.Web.App_Start.Modules
{
    /// <summary>
    /// MVPNinjectModule set by shakuu - https://github.com/shakuu
    /// </summary>
    public class MvpNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IPresenterFactory>().To<WebFormsMvpPresenterFactory>().InSingletonScope();

            this.Bind<ICustomPresenterFactory>().ToFactory().InSingletonScope();

            this.Bind<IPresenter>().ToMethod(this.GetPresenter)
                .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null));
        }

        private IPresenter GetPresenter(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = (Type) parameters[0].GetValue(context, null);
            var viewInstance = (IView) parameters[1].GetValue(context, null);

            var ctorParamter = new ConstructorArgument("view", viewInstance);

            return (IPresenter) context.Kernel.Get(presenterType, ctorParamter);
        }
    }
}