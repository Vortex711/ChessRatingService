using Microsoft.EntityFrameworkCore;
using ChessRatingService;
using ChessRatingService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ChessRatingDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ChessRatingDb")
    )
);

builder.Services.AddScoped<MatchProcessingService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
