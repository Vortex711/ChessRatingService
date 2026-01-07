namespace ChessRatingService.Services
{
    public class MatchRatingService
    {
        private readonly ChessRatingDbContext _db;
        public MatchRatingService (ChessRatingDbContext db)
        {
            _db = db;
        }

        public void ProcessMatch(
            string externalMatchId,
            int playerAId,
            int playerBId,
            int result,
            DateTime playedAt)
        {

        }
    }
}
