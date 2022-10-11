namespace API.Shared.RequestFeatures;

public class PagedList<TSource> : List<TSource>
{
    public MetaData MetaData { get; set; }

    public PagedList(IEnumerable<TSource> items, int count, int pageNumber, int pageSize)
    {
        MetaData = new MetaData
        {
            TotalCount = count,
            PageSize = pageSize,
            CurrentPage = pageNumber,
            TotalPages = (int) Math.Ceiling(count / (double) pageSize)
        };

        AddRange(items);
    }

    public static PagedList<TSource> ToPagedList(IEnumerable<TSource> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var items = source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).ToList();
        
        return new PagedList<TSource>(items, count, pageNumber, pageSize);
    }
}