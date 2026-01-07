using ChessRatingService.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChessRatingService
{
    public class ChessRatingDbContext : DbContext
    {
        public ChessRatingDbContext(DbContextOptions<ChessRatingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<RatingChange> RatingChanges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasIndex(m => m.ExternalMatchId)
                .IsUnique();

            modelBuilder.Entity<Player>()
                .ToTable(t => t.HasCheckConstraint(
                    "CK_Player_CurrentRating_Min100",
                    "CurrentRating >= 100"
                ));

            modelBuilder.Entity<RatingChange>()
                .HasOne<Player>()
                .WithMany()
                .HasForeignKey(rc => rc.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RatingChange>()
                .HasOne<Match>()
                .WithMany()
                .HasForeignKey(rc => rc.MatchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RatingChange>()
                .HasIndex(rc => new { rc.MatchId, rc.PlayerId })
                .IsUnique();
        }
    }
}
