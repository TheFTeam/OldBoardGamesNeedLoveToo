using System;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using WebFormsMvp.Web;
using WebFormsMvp;
using Ninject;

using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Web.App_Start;
using OldBoardGamesNeedLoveToo.Web.Models;

namespace OldBoardGamesNeedLoveToo.Web
{
    [PresenterBinding(typeof(AddGamePresenter))]
    public partial class AddGame : MvpPage<AddGameViewModel>, IAddGameView
    {
        private Action onSubmit;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IAddGameViewModel GetFormData()
        {
            IAddGameViewModel inputViewData = NinjectWebCommon.Kernel.Get<AddGameViewModel>();
            inputViewData.Name = this.TextBoxName.Text;
            inputViewData.Condition = this.DropDownListCondition.SelectedValue;
            inputViewData.Content = this.TextBoxContents.Text;
            inputViewData.Description = this.TextBoxDescription.Text;
            inputViewData.Language = this.TextBoxLanguage.Text;
            inputViewData.Producer = this.TextBoxProducer.Text;
            inputViewData.Price = this.TextBoxPrice.Text;
            inputViewData.ReleaseDate = this.TextBoxReleaseDate.Text;
            inputViewData.MinPlayers = this.TextBoxMinPlayers.Text;
            inputViewData.MaxPlayers = this.TextBoxMaxPlayers.Text;
            inputViewData.MinAgeOfPlayers = this.TextBoxMinAgeOfPlayers.Text;
            inputViewData.MaxAgeOfPlayers = this.TextBoxMaxAgeOfPlayers.Text;
            inputViewData.Image = this.FileUploadGameImage.FileBytes;

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var id = user.UserCustomInfo.Id;

            inputViewData.OwnerId = id;

            return inputViewData;
        }

        public void SetSubmitAction(Action onSubmit)
        {
            this.onSubmit = onSubmit;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            this.onSubmit();
        }
    }
}