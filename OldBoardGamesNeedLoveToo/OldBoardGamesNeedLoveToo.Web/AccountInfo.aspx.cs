using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using WebFormsMvp;
using WebFormsMvp.Web;

using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Web.Models;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.Web
{
    [PresenterBinding(typeof(AccountInfoPresenter))]
    public partial class AccountInfo : MvpPage<UsersViewModel>, IAccountInfoView
    {
        public event EventHandler<UserDetailsByIdEventArgs> OnGetData;
        public event EventHandler<UserDetailsByIdEventArgs> OnUpdateItem;

        public IQueryable<UserCustomInfo> ListViewUserDetails_GetData()
        {
            Guid id = this.GetCurrentUserIdFromSession();
            this.OnGetData?.Invoke(null, new UserDetailsByIdEventArgs(id));

            return this.Model.Users.ToList().AsQueryable();
        }

        public void ListViewUserDetails_UpdateItem(Guid Id)
        {
            this.OnUpdateItem?.Invoke(this, new UserDetailsByIdEventArgs(Id));
        }

        private Guid GetCurrentUserIdFromSession()
        {
            ApplicationUser user = HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(HttpContext.Current.User.Identity.GetUserId());

            Guid id = Guid.Empty;
            if (user != null)
            {
                id = user.UserCustomInfo.Id;
                this.Session["Id"] = id;
                this.Session.Timeout = 30;
            }

            return id;
        }

        protected void ButtonSubmitProfilePic_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(HttpContext.Current.User.Identity.GetUserId());
            byte[] fileData = null;
            Stream fileStream = null;
            int length = 0;

            if (this.FileUploadProfilePic.HasFile)
            {
                try
                {
                    if (this.FileUploadProfilePic.PostedFile.ContentType == "image/jpeg" ||
                        this.FileUploadProfilePic.PostedFile.ContentType == "image/jpg" ||
                        this.FileUploadProfilePic.PostedFile.ContentType == "image/png")
                    {
                        length = this.FileUploadProfilePic.PostedFile.ContentLength;
                        fileData = new byte[length + 1];
                        fileStream = this.FileUploadProfilePic.PostedFile.InputStream;
                        fileStream.Read(fileData, 0, length);
                        user.UserCustomInfo.ProfilePricture = fileData;
                        manager.Update(user);
                    }
                    else
                    {
                        this.LabelFileUploadStatus.Text = "Accepted file formats: .jpg | .jpeg | .png";
                    }
                }
                catch (Exception ex)
                {
                    this.LabelFileUploadStatus.Text = "The file could not be uploaded.The following error occured: " + ex.Message;
                }

            }
        }
    }
}