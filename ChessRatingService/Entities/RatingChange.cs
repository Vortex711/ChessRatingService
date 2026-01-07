namespace ChessRatingService.Entities
{
    public class RatingChange
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Match Match { get; set; } = null!;
        public int MatchId { get; set; }
        public int RatingBefore { get; set; }
        public int RatingAfter { get; set; }
        public int Delta { get; set; }
        public DateTime CreatedAt { get; set; }
}
}
