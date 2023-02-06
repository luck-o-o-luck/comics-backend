using ComicsBackend.Comics.Domain.DTO;
using ComicsBackend.Comics.Domain.Entities;

namespace ComicsBackend.Comics.Services.interfaces;

public interface IComicsService
{
    public Task<ComicBook> GetComicsRandom();
    public Task DeleteComics(ComicsModel comics);
}