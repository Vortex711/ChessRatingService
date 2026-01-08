namespace ChessRatingService.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public required string ExternalMatchId { get; set; }
        public int PlayerAId { get; set; }
        public int PlayerBId { get; set; }
        public int Result { get; set; }
        public DateTime PlayedAt { get; set; }
        public DateTime ProcessedAt { get; set; }
        public ICollection<RatingChange> RatingChanges { get; set; } = new List<RatingChange>();

    }
}
