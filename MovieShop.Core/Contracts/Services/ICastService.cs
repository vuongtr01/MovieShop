using MovieShop.Core.Models.ResponseModels;

namespace MovieShop.Core.Contracts.Services;

public interface ICastService
{
    Task<CastResponseModel> GetById(int id);
}