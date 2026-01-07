using ChessRatingService.Services;
using Microsoft.AspNetCore.Mvc;
using ChessRatingService.DTOs;

namespace ChessRatingService.Controllers
{
    [Route("api/matches")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly MatchProcessingService _matchService;

        public MatchesController(MatchProcessingService matchService)
        {
            _matchService = matchService;
        }

        [HttpPost("process")]
        public IActionResult ProcessMatch(ProcessMatchRequest request)
        {
            _matchService.ProcessMatch(
                request.ExternalMatchId,
                request.PlayerAId,
                request.PlayerBId,
                request.Result,
                request.PlayedAt
            );

            return Ok();
        }
    }
}
