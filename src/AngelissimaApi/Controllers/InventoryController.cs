namespace AngelissimaApi.Controllers
{
    using AngelissimaApi.Core.Interfaces;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;
    using System;
    using System.Collections.Generic;
    using ViewModels;

    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private IInventoryCore _inventoryCore;
        private IMapper _mapper;
        private ILogger<InventoryController> _logger;

        public InventoryController(IInventoryCore inventoryCore, IMapper mapper, ILogger<InventoryController> logger)
        {
            _inventoryCore = inventoryCore;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/inventory
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<InventoryViewModel>>(_inventoryCore.GetAll()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, Json(ex.Message));
            }
        }

        // GET api/v/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                InventoryViewModel objInventory = _mapper.Map<InventoryViewModel>(_inventoryCore.Find(id));

                return Ok(objInventory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, Json(ex.Message));
            }
        }

        // POST api/inventory
        [HttpPost]
        public IActionResult Post([FromBody]InventoryViewModel inventory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _inventoryCore.Add(_mapper.Map<Inventory>(inventory));
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
                return StatusCode(500, Json(ex.Message));
            }
        }

        // PUT api/inventory/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]InventoryViewModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _inventoryCore.Update(_mapper.Map<Inventory>(product));
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
                return StatusCode(500, Json(ex.Message));
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
                return StatusCode(500, Json(ex.Message));
            }
        }
    }
}
