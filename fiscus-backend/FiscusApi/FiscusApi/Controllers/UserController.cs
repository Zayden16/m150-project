using System;
using System.Collections.Generic;
using FiscusApi.Helpers;
using FiscusApi.Models;
using FiscusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiscusApi.Controllers
{
    [AuthorizationRequired]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _dataAccessProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public UserController(IUserRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dataAccessProvider.GetUsers();
        }

        [HttpGet("ByUsername/{username}")]
        public User Get(string username)
        {
            return _dataAccessProvider.GetUserByUsername(username);
        }
        
        // get users by group
        [HttpGet("ByGroup/{groupId}")]
        public IEnumerable<User> GetByGroup(int groupId)
        {
            return _dataAccessProvider.GetUsersByGroupId(groupId);
        }
        

        [HttpGet("{id}")]
        public User Details(int id)
        {
            return _dataAccessProvider.GetUser(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User patient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.AddUser(patient);
                return Ok(patient);
            }
            catch (Exception exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] User patient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.UpdateUser(patient);
                return Ok(patient);
            }
            catch (Exception exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _dataAccessProvider.GetUser(id);

                if (data == null)
                    return NotFound();

                _dataAccessProvider.DeleteUser(id);
                return Ok();
            }
            catch (Exception exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }
    }
}