﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OldBoardGamesNeedLoveToo.Web
{
    public partial class GameDisplay : System.Web.UI.UserControl
    {
        public IEnumerable<Ga> MyProperty { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}