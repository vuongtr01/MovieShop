using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Contracts.Repositories;
using MovieShop.Core.Entities;
using MovieShop.Core.Helper;
using MovieShop.Core.Models.ResponseModels;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repositories;

public class MovieRepository: BaseRepositoryAsync<Movie>, IMovieRepository
{
    public MovieRepository(MovieShopDbContext context): base(context)
    {
    }

    public async Task<Movie> GetHighestGrossingMovies()
    {
        var highest = _movieShopDbContext.Purchases.GroupBy(p => p.Movie)
            .Select(g => new
            {
                Movie = g.Key,
                TotalPurchase = g.Sum(p => p.TotalPrice)
            })
            .OrderByDescending(m => m.TotalPurchase)
            .FirstOrDefault();

        if (highest != null)
        {
            return highest.Movie;
        }

        return null;
    }

    public async Task<List<MovieCastResponseModel>> GetCastsList(int id)
    {
        var res = await _movieShopDbContext.Movies
            .Include(m => m.MovieCasts)
            .ThenInclude(mc => mc.Cast)
            .FirstOrDefaultAsync(m => m.Id == id);
        
        return res?.MovieCasts.Select(mc => new MovieCastResponseModel()
        {
            Id = mc.Cast.Id,
            Name = mc.Cast.Name,
            Character = mc.Character,
            ProfilePath = mc.Cast.ProfilePath
        }).ToList();
    }

    public async Task<PaginatedResult<Movie>> GetMoviesByGenre(int genreId, int pageSize, int pageIndex)
    {
        var count = _movieShopDbContext.MovieGenres
            .Where(mg => mg.GenreId == genreId)
            .Select(mg => mg.MovieId)
            .Distinct()
            .Count();
        var movies = await _movieShopDbContext.MovieGenres
            .Where(mg => mg.GenreId == genreId)
            .Include(mg => mg.Movie)
            .Select(mg => new Movie
            {
                Id = mg.MovieId,
                TmdbUrl = mg.Movie.TmdbUrl,
                ImdbUrl = mg.Movie.ImdbUrl,
                Title = mg.Movie.Title,
                Overview = mg.Movie.Overview,
                Tagline = mg.Movie.Tagline,
                RunTime = mg.Movie.RunTime,
                Budget = mg.Movie.Budget,
                Revenue = mg.Movie.Revenue,
                BackdropUrl = mg.Movie.BackdropUrl,
                PosterUrl = mg.Movie.PosterUrl,
                OriginalLanguage = mg.Movie.OriginalLanguage,
                CreatedDate = mg.Movie.CreatedDate,
                CreateBy = mg.Movie.CreateBy,
                ReleaseDate = mg.Movie.ReleaseDate,
                UpdatedDate = mg.Movie.UpdatedDate,
                UpdatedBy = mg.Movie.UpdatedBy,
            })
            .Skip(pageSize * (pageIndex - 1))
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResult<Movie>(movies, pageIndex, pageSize, count);
    }

    public async Task<PaginatedResult<Movie>> GetPaginatedMovie(int pageSize, int pageIndex)
    {
        var count = _movieShopDbContext.Movies.Count();
        var movies =  await _movieShopDbContext.Movies
            .Select(m => new Movie
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
                OriginalLanguage = m.OriginalLanguage,
                CreatedDate = m.CreatedDate,
                CreateBy = m.CreateBy,
                ReleaseDate = m.ReleaseDate,
                UpdatedDate = m.UpdatedDate,
                UpdatedBy = m.UpdatedBy,
            })
            .Skip(pageSize * (pageIndex - 1))
            .Take(pageSize)
            .ToListAsync();
        return new PaginatedResult<Movie>(movies, pageIndex, pageSize, count);
    }
}