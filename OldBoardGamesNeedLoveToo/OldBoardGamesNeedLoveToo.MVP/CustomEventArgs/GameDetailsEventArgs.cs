namespace OldBoardGamesNeedLoveToo.MVP.CustomEventArgs
{
    public class GameDetailsEventArgs
    {
        public GameDetailsEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}