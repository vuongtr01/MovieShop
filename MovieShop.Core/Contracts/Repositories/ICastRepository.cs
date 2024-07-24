using MovieShop.Core.Entities;

namespace MovieShop.Core.Contracts.Repositories;

public interface ICastRepository: IRepositoryAsync<Cast>
{
    Task<Cast> GetCastDetails(int id);
}