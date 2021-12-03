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
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListRepository _dataAccessProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingListController"/> class.
        /// </summary>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public ShoppingListController(IShoppingListRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<ShoppingList> Get()
        {
            return _dataAccessProvider.GetShoppingLists();
        }

        [HttpGet("{id}")]
        public ShoppingList Details(int id)
        {
            return _dataAccessProvider.GetShoppingList(id);
        }

        [HttpGet("ByGroupId/{groupId}")]
        public ShoppingList GetByGroupId(int groupId)
        {
            return _dataAccessProvider.GetShoppingListByGroupId(groupId);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ShoppingList shoppingList)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.AddShoppingList(shoppingList);
                return Ok(shoppingList);
            }
            catch (Exception exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] ShoppingList shoppingList)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _dataAccessProvider.UpdateShoppingList(shoppingList);
                return Ok(shoppingList);
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
                var data = _dataAccessProvider.GetShoppingList(id);

                if (data == null)
                    return NotFound($"Entity with {id} not found.");

                _dataAccessProvider.DeleteShoppingList(id);
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
