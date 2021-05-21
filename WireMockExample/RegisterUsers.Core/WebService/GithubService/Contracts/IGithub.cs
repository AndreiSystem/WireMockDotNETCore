using System.Threading.Tasks;
using RegisterUsers.Core.Domain.Entities;

namespace RegisterUsers.Core.WebService.GithubService.Contracts
{
    public interface IGithub
    {
        Task<User> GetUser(QueryStringGithubUser queryStringGithubUser);
    }
}