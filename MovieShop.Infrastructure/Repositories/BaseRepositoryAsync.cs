using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Contracts.Repositories;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repositories;

public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T: class
{
    protected readonly MovieShopDbContext _movieShopDbContext;

    public BaseRepositoryAsync(MovieShopDbContext movieShopDbContext)
    {
        this._movieShopDbContext = movieShopDbContext;
    }
    public async Task<int> Insert(T obj)
    {
        await _movieShopDbContext.Set<T>().AddAsync(obj);
        return await _movieShopDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteById(int id)
    {
        var obj = await GetById(id);
        if (obj != null)
        {
            this._movieShopDbContext.Set<T>().Remove(obj);
            return await _movieShopDbContext.SaveChangesAsync();
        }

        return -1;
    }

    public async Task<int> Update(T obj)
    {
        this._movieShopDbContext.Entry(obj).State = EntityState.Modified;
        return await _movieShopDbContext.SaveChangesAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _movieShopDbContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        var res = await _movieShopDbContext.Set<T>().ToListAsync();
        return res.Take(5);
    }
}