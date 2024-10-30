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
        Genre genreName = GetGenreById(game.GenreId);
        var gameSumary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genreName.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
        games.Add(gameSumary);
    }

    public GameDetails GetGame(int id)
    {
        GameSummary game = GetGameSummaryById(id);
        var genre = genres.Single(genre => string.Equals(game.Genre, genre.Name, StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void UpdateGame(GameDetails updatedGame)
    {
        var genre = GetGenreById(updatedGame.GenreId);
        GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
        var game = GetGameSummaryById(id);
        games.Remove(game);
    }

    private GameSummary GetGameSummaryById(int id)
    {
        var game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return genres.Single(genre => genre.Id == int.Parse(id));
    }
}
