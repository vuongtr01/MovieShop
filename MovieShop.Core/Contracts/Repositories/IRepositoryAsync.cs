namespace MovieShop.Core.Contracts.Repositories;

public interface IRepositoryAsync<T> where T: class
{
    Task<int> Insert(T obj);
    Task<int> DeleteById(int id);
    Task<int> Update(T obj);
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
}