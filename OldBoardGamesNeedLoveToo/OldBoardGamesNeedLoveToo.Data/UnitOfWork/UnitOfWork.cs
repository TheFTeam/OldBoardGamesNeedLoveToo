using System;

namespace OldBoardGamesNeedLoveToo.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ObgnltContext context;

        public UnitOfWork(ObgnltContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("DbContect cannot be null");
            }

            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}