using ChessRatingService.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ChessRatingService.Services
{
    public class LeaderboardService
    {
        private readonly ChessRatingDbContext _db;

        public LeaderboardService(ChessRatingDbContext db)
        {
            _db = db;
        }

        public async Task<List<LeaderboardEntryDto>> GetLeaderboardAsync(
            int page,
            int pageSize,
            bool includeInactive = false)
        {
            var skip = (page - 1) * pageSize;

            var query = _db.Players
                .AsNoTracking();

            if (!includeInactive)
            {
                query = query
                 .Where(p => p.IsActive);
            }

            var players = await query
                .OrderByDescending(p => p.CurrentRating)
                .Skip(skip)
                .Take(pageSize)
                .Select(p => new LeaderboardEntryDto
                {
                    PlayerId = p.Id,
                    Rating = p.CurrentRating,
                    LastMatchAt = p.LastMatchAt
                })
                .ToListAsync();

            for (int i = 0; i < players.Count; i ++)
            {
                players[i].Rank = skip + i + 1;
            }

            return players;
            
        }
    }
}
