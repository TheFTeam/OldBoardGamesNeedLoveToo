﻿using OldBoardGamesNeedLoveToo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBoardGamesNeedLoveToo.MVP.Models
{
    public interface IAdminGamesViewModel
    {
        IEnumerable<Game> Games { get; set; }
        IEnumerable<Category> Categories { get; set; }

    }
}