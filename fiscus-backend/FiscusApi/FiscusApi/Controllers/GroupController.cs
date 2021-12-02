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
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _dataAccessProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupController"/> class.
        /// </summary>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public GroupController(IGroupRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Group> Get()
        {
            return _dataAccessProvider.GetGroups();
        }

        [HttpGet("{id}")]
        public Group Details(int id)
        {
            return _dataAccessProvider.GetGroup(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Group patient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.AddGroup(patient);
                return Ok(patient);
            }
            catch (Exception exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Group patient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.UpdateGroup(patient);
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
                var data = _dataAccessProvider.GetGroup(id);

                if (data == null)
                    return NotFound($"Entity with {id} not found.");

                _dataAccessProvider.DeleteGroup(id);
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
