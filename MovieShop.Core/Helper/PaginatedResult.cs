namespace MovieShop.Core.Helper;

public class PaginatedResult<T> where T : class
{
    public PaginatedResult(IEnumerable<T> data, int pageIndex, int pageSize, long count)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Count = count;
        Data = data;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }

    public int PageIndex { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public long Count { get; }
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;

    public IEnumerable<T> Data { get; }
}