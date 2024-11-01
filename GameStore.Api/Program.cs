using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new( 1, "Fighting", "Street Fighter II", 19.99M, new DateOnly(1992, 7, 15) ),
    new( 2, "RPG", "Final Fantasy XIV", 59.99M, new DateOnly(2010, 9, 30) ),
    new( 3, "Sports", "FIFA 23", 69.99M, new DateOnly(2022, 9, 27) )
];

app.MapGet("games", () => games);

app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id)).WithName("GetGame");

app.MapPost("games", (CreateGameDto newGame) => 
{
    GameDto game = new(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);
    games.Add(game);    
    return Results.CreatedAtRoute("GetGame", new {id = game.Id});
}

app.Run();
