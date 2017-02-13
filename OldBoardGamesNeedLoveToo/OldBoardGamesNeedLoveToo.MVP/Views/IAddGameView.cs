using System;

using OldBoardGamesNeedLoveToo.MVP.Models;
using WebFormsMvp;

namespace OldBoardGamesNeedLoveToo.MVP.Views
{
    /// <summary>
    /// A view for getting the input data for adding a new game
    /// </summary>
    public interface IAddGameView : IView<AddGameViewModel>
    {
        /// <summary>
        /// Get the submitted user data for adding a new game
        /// </summary>
        /// <returns>Returns the view model</returns>
        IAddGameViewModel GetFormData();

        /// <summary>
        /// Set a callback action to run when the user submits the "Add an old game" form
        /// </summary>
        /// <param name="onSubmit"></param>
        void SetSubmitAction(Action onSubmit);
    }
}