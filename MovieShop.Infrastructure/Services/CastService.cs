using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieShop.Core.Contracts.Repositories;
using MovieShop.Core.Contracts.Services;
using MovieShop.Core.Models.ResponseModels;

namespace MovieShop.Infrastructure.Services;

public class CastService: ICastService
{
    private readonly ICastRepository _castRepository;

    public CastService(ICastRepository castRepository)
    {
        this._castRepository = castRepository;
    }
    public async Task<CastResponseModel> GetById(int id)
    {
        var result = await _castRepository.GetCastDetails(id);
        if (result != null)
        {
            var moviesList = result.Movies;
            CastResponseModel model = new CastResponseModel();
            model.Name = result.Name;
            model.Gender = result.Gender == "1" ? "F" : "M";
            model.TmdbUrl = result.TmdbUrl;
            model.ProfilePath = result.ProfilePath;
            model.movies = new List<MovieResponseModel>();

            foreach (var movie in moviesList)
            {
                MovieResponseModel movieModel = new MovieResponseModel();
                movieModel.Id = movie.Id;
                movieModel.Title = movie.Title;
                movieModel.PosterUrl = movie.PosterUrl;
                
                model.movies.Add(movieModel);
            }

            return model;
        }

        return null;
    }
}