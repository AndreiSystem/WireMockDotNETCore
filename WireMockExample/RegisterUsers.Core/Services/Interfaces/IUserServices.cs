using System;
using System.Linq;
using System.Threading.Tasks;
using RegisterUsers.Core.Domain.Entities;

namespace RegisterUsers.Core.Services.Interfaces
{
    public interface IUserServices
    {
        Task<User> GetUserGithub(string userName);
    }
}