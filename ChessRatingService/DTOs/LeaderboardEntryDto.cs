namespace ChessRatingService.DTOs
{
    public class LeaderboardEntryDto
    {
        public int PlayerId { get; set; }
        public int Rating { get; set; }
        public int Rank { get; set; }
        public DateTime? LastMatchAt {get; set;}
    }
}
