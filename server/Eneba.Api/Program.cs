using Eneba.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Read DATABASE_URL from environment
var dbUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
if (string.IsNullOrWhiteSpace(dbUrl))
{
    throw new Exception("DATABASE_URL is not set");
}

// Configure Postgres (Supabase)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(dbUrl));

// CORS (React dev + Vercel)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(origin =>
                origin.StartsWith("http://localhost") ||
                origin.Contains(".vercel.app"));
    });
});

var app = builder.Build();

app.UseCors("AllowClient");

// Swagger always on (dev)
app.UseSwagger();
app.UseSwaggerUI();

// Health check
app.MapGet("/health", () => Results.Ok(new { ok = true }));

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.Games.Any())
    {
        db.Games.AddRange(
            new Eneba.Api.Models.Game
            {
                Name = "FIFA 23",
                PriceEur = 19.99m,
                Platform = "PC",
                ImageUrl = "https://images.igdb.com/igdb/image/upload/t_cover_big/co4t1k.jpg"
            },
            new Eneba.Api.Models.Game
            {
                Name = "Red Dead Redemption 2",
                PriceEur = 24.99m,
                Platform = "PC",
                ImageUrl = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1q1f.jpg"
            },
            new Eneba.Api.Models.Game
            {
                Name = "Cyberpunk 2077",
                PriceEur = 29.99m,
                Platform = "PC",
                ImageUrl = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2lbd.jpg"
            },
            new Eneba.Api.Models.Game
            {
                Name = "Elden Ring",
                PriceEur = 34.99m,
                Platform = "PC",
                ImageUrl = "https://images.igdb.com/igdb/image/upload/t_cover_big/co4jni.jpg"
            },
            new Eneba.Api.Models.Game
            {
                Name = "Split Fiction",
                PriceEur = 14.99m,
                Platform = "PC",
                ImageUrl = "https://images.igdb.com/igdb/image/upload/t_cover_big/co7xyz.jpg"
            }
        );

        db.SaveChanges();
    }
}

app.MapControllers();

app.Run();