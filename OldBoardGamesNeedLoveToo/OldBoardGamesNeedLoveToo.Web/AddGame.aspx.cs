using System;
using System.IO;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using System.Collections.Generic;
using System.Web.UI.WebControls;

using WebFormsMvp.Web;
using WebFormsMvp;

using OldBoardGamesNeedLoveToo.MVP.Presenters;
using OldBoardGamesNeedLoveToo.MVP.Models;
using OldBoardGamesNeedLoveToo.MVP.Views;
using OldBoardGamesNeedLoveToo.Auth;
using OldBoardGamesNeedLoveToo.MVP.CustomEventArgs;

namespace OldBoardGamesNeedLoveToo.Web
{
    [PresenterBinding(typeof(AddGamePresenter))]
    public partial class AddGame : MvpPage<AddGameViewModel>, IAddGameView
    {
        public event EventHandler OnPageInit;
        public event EventHandler<AddGameEventArgs> OnAddGameSubmit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.OnPageInit?.Invoke(sender, e);
            this.ListBoxCategories.DataSource = this.Model.Categories;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                return;
            }

            string name = this.TextBoxName.Text;
            string condition = this.DropDownListCondition.SelectedValue;
            string content = this.TextBoxContents.Text;
            string description = this.TextBoxDescription.Text;
            string language = this.TextBoxLanguage.Text;
            string producer = this.TextBoxProducer.Text;
            string price = this.TextBoxPrice.Text;
            string releaseDate = this.TextBoxReleaseDate.Text;
            string minPlayers = this.TextBoxMinPlayers.Text;
            string maxPlayers = this.TextBoxMaxPlayers.Text;
            string minAgeOfPlayers = this.TextBoxMinAgeOfPlayers.Text;
            string maxAgeOfPlayers = this.TextBoxMaxAgeOfPlayers.Text;

            var selectedCategoriesIds = new List<string>();
            foreach (ListItem item in this.ListBoxCategories.Items)
            {
                if (item.Selected)
                {
                    selectedCategoriesIds.Add(item.Value);
                }
            }

            byte[] fileData = null;
            Stream fileStream = null;
            int length = 0;
            byte[] image = fileData;

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
                        image = fileData;
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
                image = this.ReadImageFile(location);
            }

            ApplicationUser user = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(HttpContext.Current.User.Identity.GetUserId());
            var ownerId = user.UserCustomInfo.Id;

            this.OnAddGameSubmit?.Invoke(sender, new AddGameEventArgs(condition, content, description, image, language, name, price, producer, releaseDate, minPlayers, maxPlayers, minAgeOfPlayers, maxAgeOfPlayers, ownerId, selectedCategoriesIds));
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

        protected void CustomValidatorTextBoxMaxAgeOfPlayers_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int maxAgeOfPlayers = 100;
            int value = int.Parse(args.Value);
            int valueMinAgeOfPlayers = int.Parse(this.TextBoxMinAgeOfPlayers.Text);
            args.IsValid = (valueMinAgeOfPlayers <= value && value <= maxAgeOfPlayers);
        }

        protected void CustomValidatorTextBoxMinAgeOfPlayers_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int minimumAgeOfPlayers = 2;
            int value = int.Parse(args.Value);
            args.IsValid = (value >= minimumAgeOfPlayers);
        }

        protected void CustomValidatorTextBoxName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int minLength = 2;
            int maxLength = 100;
            args.IsValid = (minLength <= args.Value.Length && args.Value.Length <= maxLength);
        }

        protected void CustomValidatorTextBoxMinPlayers_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int minPlayers = int.Parse(args.Value);
            args.IsValid = (minPlayers >= 1);
        }

        protected void CustomValidatorTextBoxMaxPlayers_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int maxPlayers = int.Parse(args.Value);
            int minPlayers = int.Parse(this.TextBoxMinPlayers.Text);
            args.IsValid = (minPlayers <= maxPlayers && maxPlayers <= 20);
        }
    }
}