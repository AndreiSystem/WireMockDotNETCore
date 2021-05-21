using System;
using System.Linq;
using System.Threading.Tasks;
using RegisterUsers.Core.Domain.Entities;
using RegisterUsers.Core.Repository.Interfaces;
using RegisterUsers.Core.Services.Interfaces;
using RegisterUsers.Core.WebService.GithubService;
using RegisterUsers.Core.WebService.GithubService.Contracts;

namespace RegisterUsers.Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<User> _userRepository;
        private readonly IGithub _github;
        
        public UserServices(IRepository<User> userRepository, IGithub github)
        {
            _userRepository = userRepository;
            _github = github;
        }
        
        public IQueryable<User> GetAll()
        {
            var result = _userRepository.QueryAll();

            return result;
        }

        public User Insert(User user)
        {
            _userRepository.Insert(user);
            return user;
        }

        public async Task<User> GetUserGithub(string userName)
        {
            var queryString = new QueryStringGithubUser
            {
                UserName = userName
            };

            try
            {
                var receivedUsers = await _github.GetUser(queryString);
                var userSaved = Insert(receivedUsers);
                return userSaved;
            }
            
            catch (Exception e)
            {
                Console.WriteLine($"ERRO {e}");
                throw;
            }
        }
    }
}