namespace ChessRatingService.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public int CurrentRating { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastMatchAt { get; set; }
    }
}
