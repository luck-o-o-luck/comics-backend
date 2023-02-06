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
    private readonly ComicsDbContext _context;
 
    public ComicsService()
    {
        _context = new ComicsDbContext();
    }

    public async Task<ComicBook> GetComicsRandom()
    {
        var random = _random.Next(1, 2730);

        while (_context.ComicBooks.Any(x => x.Id == random))
        {
            random = _random.Next(1, 2730);
        }

        var url = $"https://xkcd.com/{random}/info.0.json";

        var comics = await _client.GetFromJsonAsync<ComicBook>(url);

        await _context.AddAsync(comics);
        await _context.SaveChangesAsync();

        return comics;
    }

    public async Task DeleteComics(ComicsModel comics)
    {
        var searchedComics = await _context.ComicBooks.FirstOrDefaultAsync(x => x.Id == comics.Id);

        if (searchedComics is null)
        {
            throw new Exception("Comics with this id doesn't exist.");
        }

        _context.ComicBooks.Remove(searchedComics);
        await _context.SaveChangesAsync();
    }
}