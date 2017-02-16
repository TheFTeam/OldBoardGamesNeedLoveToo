using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OldBoardGamesNeedLoveToo.Web.UserControls
{
    public partial class CommentsList : System.Web.UI.UserControl
    {
        public bool IsVisible
        {
            get
            {
                return this.Visible;
            }
            set
            {
                this.Visible = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}