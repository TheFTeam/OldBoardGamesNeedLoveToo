using System;

using WebFormsMvp;

namespace OldBoardGamesNeedLoveToo.Web.App_Start.Factories
{
    /// <summary>
    /// Custom Presenter Factory Interface set by Shakuu - https://github.com/shakuu
    /// </summary>
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
