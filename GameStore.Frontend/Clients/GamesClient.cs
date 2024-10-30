using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = 
    [
        new() { Id = 1, Genre = "Fighting", Name = "Street Fighter II", Price = 19.99M, ReleaseDate = new DateOnly(1992, 7, 15) },
        new() { Id = 2, Genre = "RPG", Name = "Final Fantasy XIV", Price = 59.99M, ReleaseDate = new DateOnly(2010, 9, 30) },
        new() { Id = 3, Genre = "Sports", Name = "FIFA 23", Price = 69.99M, ReleaseDate = new DateOnly(2022, 9, 27) }
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
        var genreName = genres.Single(genre => genre.Id == int.Parse(game.GenreId));
        var gameSumary = new GameSummary {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genreName.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
        games.Add(gameSumary);
    }
}
