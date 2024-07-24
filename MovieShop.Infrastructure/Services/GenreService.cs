using MovieShop.Core.Contracts.Repositories;
using MovieShop.Core.Contracts.Services;
using MovieShop.Core.Entities;
using MovieShop.Core.Models.ResponseModels;

namespace MovieShop.Infrastructure.Services;

public class GenreService: IGenreService
{
    private readonly IRepositoryAsync<Genre> _genreRepository;

    public GenreService(IRepositoryAsync<Genre> genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<GenreResponseModel>> GetAllGenres()
    {
        var genres = await _genreRepository.GetAll();
        return genres.Select(g => new GenreResponseModel
        {
            Id = g.Id,
            Name = g.Name
        });
    }
}