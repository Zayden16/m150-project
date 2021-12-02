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
    public class PaymentController : ControllerBase
    {
        private readonly IItemRepository _dataAccessProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemController"/> class.
        /// </summary>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public PaymentController(IItemRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _dataAccessProvider.GetItems();
        }

        [HttpGet("{id}")]
        public Item Details(int id)
        {
            return _dataAccessProvider.GetItem(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Item patient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.AddItem(patient);
                return Ok(patient);
            }
            catch (Exception exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Item patient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.UpdateItem(patient);
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
                var data = _dataAccessProvider.GetItem(id);

                if (data == null)
                    return NotFound($"Entity with {id} not found.");

                _dataAccessProvider.DeleteItem(id);
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
