using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Contracts.Repositories;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repositories;

public class BaseRepository<T>: IRepository<T> where T: class
{
    protected readonly MovieShopDbContext _movieShopDbContext;

    public BaseRepository(MovieShopDbContext movieShopDbContext)
    {
        this._movieShopDbContext = movieShopDbContext;
    }
    public int Insert(T obj)
    {
        this._movieShopDbContext.Set<T>().Add(obj);
        return this._movieShopDbContext.SaveChanges();
    }

    public int DeleteById(int id)
    {
        var obj = GetById(id);
        if (obj != null)
        {
            this._movieShopDbContext.Set<T>().Remove(obj);
            return this._movieShopDbContext.SaveChanges();
        }

        return -1;
    }

    public int Update(T obj)
    {
        this._movieShopDbContext.Entry(obj).State = EntityState.Modified;
        return this._movieShopDbContext.SaveChanges();
    }

    public T GetById(int id)
    {
        return this._movieShopDbContext.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        var res = _movieShopDbContext.Set<T>().ToList().Take(5);
        return res;
    }
}