namespace ChessRatingService.DTOs
{
    public class ProcessMatchRequest
    {
        public required string ExternalMatchId { get; set; }
        public int PlayerAId { get; set; }
        public int PlayerBId { get; set; }
        public int Result { get; set; }
        public DateTime PlayedAt { get; set; }
    }
}
