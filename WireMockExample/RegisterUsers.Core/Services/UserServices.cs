using System;
using System.Linq;
using RegisterUsers.Core.Domain.Entities;
using RegisterUsers.Core.Repository.Intefaces;
using RegisterUsers.Core.Services.Interfaces;

namespace RegisterUsers.Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<User> _userRepository;
        
        public UserServices(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        
        public IQueryable<User> QueryAll()
        {
            var result = _userRepository.QueryAll();

            return result;
        }

        public User Query(string id)
        {
            var result = _userRepository.Query(id);

            return result;
        }

        public User InsertOrUpdate(User user)
        {
            var userDB = Query(user.Id);
            if (userDB is not null)
            {
                userDB.Name = user.Name;
                userDB.Url = user.Url;
            }
            user.InsertDate = DateTime.Now;
            _userRepository.Insert(user);
            return user;
        }
    }
}