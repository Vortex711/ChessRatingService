using ChessRatingService.Entities;

namespace ChessRatingService.Services
{
    public class MatchProcessingService
    {
        private readonly ChessRatingDbContext _db;
        public MatchProcessingService (ChessRatingDbContext db)
        {
            _db = db;
        }

        private double CalculateExpectedScore(int rating, int opponentRating)
        {
            return 1.0 / (1.0 + Math.Pow(10, (opponentRating - rating) / 400.0));
        }

        private int GetKFactor(int rating)
        {
            if (rating < 800) return 50;
            if (rating < 1200) return 40;
            if (rating < 1600) return 30;
            if (rating < 2000) return 20;
            return 10;
        }


        public void ProcessMatch(
            string externalMatchId,
            int playerAId,
            int playerBId,
            int result,
            DateTime playedAt)
        {
            //Check if ExternalMatchId exists
            var alreadyProcessed = _db.Matches
                .Any(m => m.ExternalMatchId == externalMatchId);

            if (alreadyProcessed)
            {
                return;
            }

            //Check if PlayerIds exists 
            var playerA = _db.Players
                .SingleOrDefault(p => p.Id == playerAId);
            var playerB = _db.Players
                .SingleOrDefault(p => p.Id == playerBId);

            if (playerA == null || playerB == null)
            {
                throw new InvalidOperationException("One or both players do not exist.");
            } 

            if (!playerA.IsActive || !playerB.IsActive)
            {
                throw new InvalidOperationException("One or both players are inactive.");
            }

            //Calculate Rating
            double expectedA = CalculateExpectedScore(playerA.CurrentRating, playerB.CurrentRating);
            double expectedB = CalculateExpectedScore(playerB.CurrentRating, playerA.CurrentRating);

            double actualA;
            double actualB;

            if (result == 1)
            {
                actualA = 1.0;
                actualB = 0.0;
            } else if (result == 2)
            {
                actualA = 0.0;
                actualB = 1.0;
            } else
            {
                actualA = actualB = 0.5;    
            }

            int kA = GetKFactor(playerA.CurrentRating);
            int kB = GetKFactor(playerB.CurrentRating);

            int deltaA = (int)Math.Round(kA * (actualA - expectedA));
            int deltaB = (int)Math.Round(kB * (actualB - expectedB));

            int newRatingA = playerA.CurrentRating + deltaA;
            int newRatingB = playerB.CurrentRating + deltaB;

            //Start transaction
            using var transaction = _db.Database.BeginTransaction();

            var match = new Match
            {
                ExternalMatchId = externalMatchId,
                PlayerAId = playerAId,
                PlayerBId = playerBId,
                Result = result,
                PlayedAt = playedAt,
                ProcessedAt = DateTime.UtcNow
            };

            _db.Matches.Add(match);

            var ratingChangeA = new RatingChange
            {
                PlayerId = playerAId,
                Match = match,
                RatingBefore = playerA.CurrentRating,
                RatingAfter = newRatingA,
                Delta = deltaA,
                CreatedAt = DateTime.UtcNow
            };

            _db.RatingChanges.Add(ratingChangeA);

            var ratingChangeB = new RatingChange
            {
                PlayerId = playerBId,
                Match = match,
                RatingBefore = playerB.CurrentRating,
                RatingAfter = newRatingB,
                Delta = deltaB,
                CreatedAt = DateTime.UtcNow
            };

            _db.RatingChanges.Add(ratingChangeB);

            playerA.CurrentRating = newRatingA;
            playerB.CurrentRating = newRatingB;
            playerA.LastMatchAt = playedAt;
            playerB.LastMatchAt = playedAt;

            _db.SaveChanges();
            transaction.Commit();
        }
    }
}
