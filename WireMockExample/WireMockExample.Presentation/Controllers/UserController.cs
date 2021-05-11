using System;
using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WireMockExample.Api.Domains.Entities;
using WireMockExample.Api.Services.Interfaces;

namespace WireMockExample.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserServices userServices, ILogger<UserController> logger)
        {
            _userServices = userServices;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            try
            {
                var result = _userServices.QueryAll();

                return Ok(result.ToList());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, id);
                return new StatusCodeResult(500);
            }
        }
        
        [HttpGet("{id}")]
        public ActionResult<User> Get([FromRoute] Guid id)
        {
            try
            {
                var result = _userServices.Query(id);

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, id);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult<User> Insert([FromBody] User user)
        {
            try
            {
                _userServices.Insert(user);

                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, user);
                return new StatusCodeResult(500);
            }
        }
    }
}