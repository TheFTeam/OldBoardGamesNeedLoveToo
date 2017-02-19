using Bytes2you.Validation;

namespace OldBoardGamesNeedLoveToo.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ObgnltContext context;

        public UnitOfWork(ObgnltContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}