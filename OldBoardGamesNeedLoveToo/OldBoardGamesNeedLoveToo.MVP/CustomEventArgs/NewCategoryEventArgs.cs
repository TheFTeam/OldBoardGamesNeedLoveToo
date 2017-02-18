using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class NewCategoryEventArgs: EventArgs
    {
        public NewCategoryEventArgs(string categoryName)
        {
            this.CategoryName = categoryName;
        }

        public string CategoryName { get; set; }
    }
}
