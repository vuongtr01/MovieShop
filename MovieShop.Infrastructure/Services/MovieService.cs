using MovieShop.Core.Contracts.Repositories;
using MovieShop.Core.Contracts.Services;
using MovieShop.Core.Entities;
using MovieShop.Core.Helper;
using MovieShop.Core.Models.RequestModels;
using MovieShop.Core.Models.ResponseModels;

namespace MovieShop.Infrastructure.Services;

public class MovieService: IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        this._movieRepository = movieRepository;
    }

    public async Task<int> AddMovie(MovieRequestModel model)
    {
        Movie entity = new Movie();
        entity.BackdropUrl = model.BackdropUrl;
        entity.Budget = model.Budget;
        entity.CreateBy = model.CreateBy;
        entity.CreatedDate = model.CreatedDate;
        entity.ImdbUrl = model.ImdbUrl;
        entity.Overview = model.Overview;
        entity.PosterUrl = model.PosterUrl;
        entity.Price = model.Price;
        entity.ReleaseDate = model.ReleaseDate;
        entity.Revenue = model.Revenue;
        entity.RunTime = model.RunTime;
        entity.Title = model.Title;
        entity.TmdbUrl = model.TmdbUrl;

        return await _movieRepository.Insert(entity);
    }

    public async Task<int> UpdateMovie(MovieRequestModel model, int id)
    {
        Movie entity = new Movie();
        entity.BackdropUrl = model.BackdropUrl;
        entity.Budget = model.Budget;
        entity.CreateBy = model.CreateBy;
        entity.CreatedDate = model.CreatedDate;
        entity.ImdbUrl = model.ImdbUrl;
        entity.Overview = model.Overview;
        entity.PosterUrl = model.PosterUrl;
        entity.Price = model.Price;
        entity.ReleaseDate = model.ReleaseDate;
        entity.Revenue = model.Revenue;
        entity.RunTime = model.RunTime;
        entity.Title = model.Title;
        entity.TmdbUrl = model.TmdbUrl;
        entity.Id = id;

        return await _movieRepository.Update(entity);
    }

    public async Task<int> DeleteMovie(int id)
    {
        return await _movieRepository.DeleteById(id);
    }

    public async Task<PaginatedResult<MovieResponseModel>> GetAllMovies(int pageSize = 20, int pageIndex = 1)
    {
        var movies = await _movieRepository.GetPaginatedMovie(pageSize, pageIndex);

        var movieResponseModels = movies.Data.Select(m => new MovieResponseModel
        {
            Id = m.Id,
            TmdbUrl = m.TmdbUrl,
            ImdbUrl = m.ImdbUrl,
            Title = m.Title,
            Overview = m.Overview,
            Tagline = m.Tagline,
            RunTime = m.RunTime,
            Budget = m.Budget,
            Revenue = m.Revenue,
            BackdropUrl = m.BackdropUrl,
            PosterUrl = m.PosterUrl,
            ReleaseDate = m.ReleaseDate
        });

        return new PaginatedResult<MovieResponseModel>(movieResponseModels, pageIndex, pageSize, movies.Count);
    }

    public async Task<MovieResponseModel> GetById(int id)
    {
        var result = await _movieRepository.GetById(id);

        if (result != null)
        {
            MovieResponseModel model = new MovieResponseModel();
            model.Id = id;
            model.BackdropUrl = result.BackdropUrl;
            model.Budget = result.Budget;
            model.CreateBy = result.CreateBy;
            model.CreatedDate = result.CreatedDate;
            model.ImdbUrl = result.ImdbUrl;
            model.Overview = result.Overview;
            model.PosterUrl = result.PosterUrl;
            model.Price = result.Price;
            model.ReleaseDate = result.ReleaseDate;
            model.Revenue = result.Revenue;
            model.RunTime = result.RunTime;
            model.Title = result.Title;
            model.TmdbUrl = result.TmdbUrl;
            model.Tagline = result.Tagline;
            return model;
        }

        return null;
    }

    public async Task<List<MovieCastResponseModel>> GetCastsList(int id)
    {
        return await _movieRepository.GetCastsList(id);
    }

    public async Task<PaginatedResult<MovieResponseModel>> GetMoviesByGenre(int genreId, int pageSize, int pageIndex)
    {
        var movies = await _movieRepository.GetMoviesByGenre(genreId, pageSize, pageIndex);
        var movieResponseModels = movies.Data.Select(m => new MovieResponseModel
        {
            Id = m.Id,
            TmdbUrl = m.TmdbUrl,
            ImdbUrl = m.ImdbUrl,
            Title = m.Title,
            Overview = m.Overview,
            Tagline = m.Tagline,
            RunTime = m.RunTime,
            Budget = m.Budget,
            Revenue = m.Revenue,
            BackdropUrl = m.BackdropUrl,
            PosterUrl = m.PosterUrl,
            ReleaseDate = m.ReleaseDate
        });

        return new PaginatedResult<MovieResponseModel>(movieResponseModels, pageIndex, pageSize, movies.Count);
    }
}