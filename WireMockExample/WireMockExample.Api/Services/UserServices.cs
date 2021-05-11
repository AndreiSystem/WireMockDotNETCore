using System;
using System.Linq;
using WireMockExample.Api.Domains.Entities;
using WireMockExample.Api.Repository.Interfaces;
using WireMockExample.Api.Services.Interfaces;

namespace WireMockExample.Api.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<User> _repository;

        public UserServices(IRepository<User> repository)
        {
            _repository = repository;
        }
        
        public IQueryable<User> QueryAll()
        {
            var result = _repository.QueryAll();

            return result;
        }

        public User Query(Guid id)
        {
            var result = _repository.Query(id);

            return result;
        }

        public void Insert(User user)
        {
            _repository.Insert(user);
        }
    }
}