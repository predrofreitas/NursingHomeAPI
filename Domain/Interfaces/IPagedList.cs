namespace Domain.Interfaces
{
    public interface IPagedList<T>
    {
        List<T> Items { get; set; }
        int TotalCount { get; }
        int Page { get; }
        int PageSize { get; }
    }
}
