using System;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.UI.WebControls;
using System.Web.UI;
using OldBoardGamesNeedLoveToo.Web.Models;

namespace OldBoardGamesNeedLoveToo.Web
{
    public partial class VerifyAccount : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var currentUser = manager.FindByName(User.Identity.Name);
                currentUser.UserCustomInfo.FirstName = this.TextBoxFirstName.Text;
                currentUser.UserCustomInfo.LastName = this.TextBoxLastName.Text;
                currentUser.UserCustomInfo.Email = currentUser.Email;
                currentUser.UserCustomInfo.Address = this.TextBoxAddress.Text;
                currentUser.UserCustomInfo.Phone = this.TextBoxPhone.Text;
                currentUser.PhoneNumber = this.TextBoxPhone.Text;
                manager.Update(currentUser);
            }
        }

        protected void CustomValidatorCheckBoxIAccept_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.CheckBoxIAccept.Checked;
        }
    }
}