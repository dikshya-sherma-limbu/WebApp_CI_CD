using Microsoft.AspNetCore.Mvc;
namespace lab4_web_app.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private static readonly string[] Genres = new[]
    {
        "Action", "Comedy", "Drama", "Horror", "Sci-Fi", "Thriller", "Romance", "Animation", "Documentary", "Fantasy"
    };

    private readonly ILogger<MovieController> _logger;

    public MovieController(ILogger<MovieController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetMovies")]
    public IEnumerable<Movie> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Movie
        {
            Id = index,
            Title = $"Movie {index}",
            ReleaseDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-Random.Shared.Next(1, 20))),
            Rating = Math.Round(Random.Shared.NextDouble() * 4 + 1, 1),
            Genre = Genres[Random.Shared.Next(Genres.Length)],
            Duration = Random.Shared.Next(90, 180)
        })
        .ToArray();
    }
}

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateOnly ReleaseDate { get; set; }
    public double Rating { get; set; }
    public string Genre { get; set; } = string.Empty;
    public int Duration { get; set; } // Duration in minutes
}