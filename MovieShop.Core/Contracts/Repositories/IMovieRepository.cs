using MovieShop.Core.Entities;
using MovieShop.Core.Helper;
using MovieShop.Core.Models.ResponseModels;

namespace MovieShop.Core.Contracts.Repositories;

public interface IMovieRepository: IRepositoryAsync<Movie>
{
    Task<Movie> GetHighestGrossingMovies();
    Task<List<MovieCastResponseModel>> GetCastsList(int id);
    Task<PaginatedResult<Movie>> GetMoviesByGenre(int genreId, int pageSize, int pageIndex);
    
    Task<PaginatedResult<Movie>> GetPaginatedMovie(int pageSize, int pageIndex);
}