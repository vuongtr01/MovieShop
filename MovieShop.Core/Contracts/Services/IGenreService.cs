using MovieShop.Core.Models.ResponseModels;

namespace MovieShop.Core.Contracts.Services;

public interface IGenreService
{
    Task<IEnumerable<GenreResponseModel>> GetAllGenres();
}