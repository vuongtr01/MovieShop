using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Contracts.Repositories;
using MovieShop.Core.Entities;
using MovieShop.Core.Models.ResponseModels;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repositories;

public class CastRepository: BaseRepositoryAsync<Cast>, ICastRepository
{
    public CastRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
    {
    }

    public async Task<Cast> GetCastDetails(int id)
    {
        return await _movieShopDbContext.Casts
            .Include(c => c.MovieCasts)
            .ThenInclude(c => c.Movie)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}