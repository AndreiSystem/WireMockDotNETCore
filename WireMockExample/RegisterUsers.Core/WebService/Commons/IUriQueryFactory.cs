namespace RegisterUsers.Core.WebService.Commons
{
    public interface IUriQueryFactory
    {
        string BuildQueryString(object queryObject);
    }
}