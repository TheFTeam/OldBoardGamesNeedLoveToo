using System;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using Ninject;

using OldBoardGamesNeedLoveToo.Models;
using OldBoardGamesNeedLoveToo.Services;
using OldBoardGamesNeedLoveToo.Web.App_Start;
using OldBoardGamesNeedLoveToo.Web.Models;

namespace OldBoardGamesNeedLoveToo.Web
{
    public partial class AddGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var name = this.TextBoxName.Text;
            var image = this.FileUploadGameImage.FileBytes;
            var producer = this.TextBoxProducer.Text;
            var price = this.TextBoxPrice.Text;
            var description = this.TextBoxDescription.Text;
            var condition = this.DropDownListCondition.SelectedValue;
            var content = this.TextBoxDescription.Text;
            var dateOfRelease = this.TextBoxReleaseDate.Text;
            var language = this.TextBoxLanguage.Text;

            if (this.IsValid)
            {
                var gameToAdd = NinjectWebCommon.Kernel.Get<Game>();
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                var id = user.UserCustomInfo.Id;
                gameToAdd.OwnerId = id;
                gameToAdd.Name = name;
                gameToAdd.Image = image;
                gameToAdd.Producer = producer;
                gameToAdd.Price = decimal.Parse(price);
                gameToAdd.Desription = description;
                gameToAdd.Contents = content;
                gameToAdd.Condition = (ConditionType) Enum.Parse(typeof(ConditionType), condition);
                gameToAdd.ReleaseDate = DateTime.Parse(dateOfRelease);
                gameToAdd.Language = language;
                var service = NinjectWebCommon.Kernel.Get<GamesService>();
                service.AddGame(gameToAdd);
            }
        }
    }
}