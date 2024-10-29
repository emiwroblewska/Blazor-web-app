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

    public GameSummary[] GetGames() => [.. games];
}
