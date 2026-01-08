using Microsoft.AspNetCore.Mvc;
using ChessRatingService.Services;
using ChessRatingService.DTOs;

namespace ChessRatingService.Controllers
{
    [Route("api/leaderboard")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        private readonly LeaderboardService _leaderboardService;

        public LeaderboardController(LeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeaderboard(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] bool includeInactive = false)
        {
            var result = await _leaderboardService.GetLeaderboardAsync(page, pageSize, includeInactive);
            return Ok(result);
        }
    }
}
