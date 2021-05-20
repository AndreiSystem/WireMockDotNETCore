using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RegisterUsers.Core.Domain.Entities;
using RegisterUsers.Core.Services.Interfaces;

namespace RegisterUsers.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get([FromRoute] string id)
        {
            var result = _userServices.Query(id);

            return Ok(result);
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            try
            {
                var result = _userServices.QueryAll();

                return Ok(result.ToList());
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }
        
        [HttpPost]
        public ActionResult<User> Insert([FromBody] User user)
        {
            try
            {
                return Ok( _userServices.InsertOrUpdate(user).Id);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}