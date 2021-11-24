﻿using System;
using System.Collections.Generic;
using FiscusApi.Helpers;
using FiscusApi.Models;
using FiscusApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiscusApi.Controllers
{
    [AuthorizationRequired]
    [Route("api/[controller]")]
    public class CostController : ControllerBase
    {
        private readonly ICostRepository _dataAccessProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CostController"/> class.
        /// </summary>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public CostController(ICostRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Cost> Get()
        {
            return _dataAccessProvider.GetCosts();
        }

        [HttpGet("{id}")]
        public Cost Details(int id)
        {
            return _dataAccessProvider.GetCost(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cost patient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.AddCost(patient);
                return Ok();
            }
            catch (Exception exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Cost patient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.UpdateCost(patient);
                return Ok();
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
                var data = _dataAccessProvider.GetCost(id);

                if (data == null)
                    return NotFound($"Entity with {id} not found.");

                _dataAccessProvider.DeleteCost(id);
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