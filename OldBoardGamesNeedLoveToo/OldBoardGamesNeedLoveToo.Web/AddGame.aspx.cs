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
using System.IO;

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

            byte[] fileData = null;
            Stream fileStream = null;
            int length = 0;

            if (this.FileUploadGameImage.HasFile)
            {
                try
                {
                    if (this.FileUploadGameImage.PostedFile.ContentType == "image/jpeg" ||
                        this.FileUploadGameImage.PostedFile.ContentType == "image/jpg" ||
                        this.FileUploadGameImage.PostedFile.ContentType == "image/png" ||
                        this.FileUploadGameImage.PostedFile.ContentType == "image/gif")
                    {
                        length = this.FileUploadGameImage.PostedFile.ContentLength;
                        fileData = new byte[length + 1];
                        fileStream = this.FileUploadGameImage.PostedFile.InputStream;
                        fileStream.Read(fileData, 0, length);
                        inputViewData.Image = fileData;

                    }
                    else
                    {
                        this.LabelFileUploadStatus.Text = "Accepted file formats: .jpg | .jpeg | .png | .gif";
                    }
                }
                catch (Exception ex)
                {
                    this.LabelFileUploadStatus.Text = "The file could not be uploaded.The following error occured: " + ex.Message;
                }

            }
            else
            {
                string location = Server.MapPath("~\\Content\\images\\Dice_WhiteHearts.png");
                inputViewData.Image = this.ReadImageFile(location);
            }

            ApplicationUser user = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(HttpContext.Current.User.Identity.GetUserId());
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

        private byte[] ReadImageFile(string imageLocation)
        {
            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo(imageLocation);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imageData = br.ReadBytes((int) imageFileLength);
            return imageData;
        }
    }
}