using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OldBoardGamesNeedLoveToo.Models;

namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public class AdminCategoriesViewModel : IAdminCategoriesViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        
    }
}
