using OldBoardGamesNeedLoveToo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public interface IAdminCategoriesViewModel
    {
        IEnumerable<Category> Categories { get; set; }
    }
}
