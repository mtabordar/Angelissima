namespace AngelissimaApi.Controllers
{
    using System;
    using AngelissimaApi.Core.Interfaces;
    using AngelissimaApi.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private IInventoryItemCore _inventoryCore;
        private ILogger<InventoryController> _logger;

        public InventoryController(IInventoryItemCore inventoryCore, ILogger<InventoryController> logger)
        {
            _inventoryCore = inventoryCore;
            _logger = logger;
        }

        // GET: api/inventory
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_inventoryCore.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, Json(ex.Message));
            }
        }

        // GET api/v/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_inventoryCore.Find(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, Json(ex.Message));
            }
        }

        // POST api/inventory
        [HttpPost]
        public IActionResult Post([FromBody]InventoryItemViewModel inventory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _inventoryCore.Add(inventory);
                    return Created("", inventory);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, Json(ex.Message));
            }
        }

        // PUT api/inventory/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]InventoryItemViewModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _inventoryCore.Update(product);
                    return Created("", product);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, Json(ex.Message));
            }
        }

        // DELETE api/inventory/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _inventoryCore.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, Json(ex.Message));
            }
        }
    }
}
