using ComicsBackend.Comics.DataAccess;
using ComicsBackend.Comics.Domain.DTO;
using ComicsBackend.Comics.Domain.Entities;
using ComicsBackend.Comics.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComicsBackend.Comics.Services.Implementations;

public class ComicsService : IComicsService
{
    private static readonly HttpClient _client = new();
    private readonly Random _random = new();
    
    public async Task<ComicBook> GetComicsRandom()
    {
        await using var db = new ComicsDbContext();
        
        var random = _random.Next(1, 2730);

        while (db.ComicBooks.Any(x => x.Id == random))
        {
            random = _random.Next(1, 2730);
        }
        
        var url = $"https://xkcd.com/{random}/info.0.json";

        var comics = await _client.GetFromJsonAsync<ComicBook>(url);

        await db.AddAsync(comics);
        await db.SaveChangesAsync();

        return comics;
    }

    public async Task DeleteComics(ComicsModel comics)
    {
        await using var db = new ComicsDbContext();

        var searchedComics = await db.ComicBooks.FirstOrDefaultAsync(x => x.Id == comics.Id);

        if (searchedComics is null)
        {
            throw new Exception("Comics with this id doesn't exist.");
        }

        db.ComicBooks.Remove(searchedComics);
        await db.SaveChangesAsync();
    }
}