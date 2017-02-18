using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class CategoryEventArgs : EventArgs
    {
        public CategoryEventArgs(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; private set; }
    }
}
