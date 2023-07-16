using Microsoft.EntityFrameworkCore;

namespace Application.Helpers
{
    public class PagedList<T>
    {
        public int TotalCount { get; }
        public int Page { get; }
        public int PageSize { get; }
        public List<T> Items { get; }

        public PagedList(List<T> items, int totalCount, int page, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            Page = page;
            PageSize = pageSize;
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int page, int pageSize)
        {
            var totalCount = await query.CountAsync();
            var items = await query.Skip((page -1) * pageSize).Take(pageSize).ToListAsync();

            return new(items, totalCount, page, pageSize);
        }
    }
}
