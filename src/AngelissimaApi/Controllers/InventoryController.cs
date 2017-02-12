namespace AngelissimaApi.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;
    using Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using ViewModels;

    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private IInventoryRepository _inventoryRepository;
        private IMapper _mapper;
        private ILogger<InventoryController> _logger;

        public InventoryController(IInventoryRepository inventoryRepository, IMapper mapper, ILogger<InventoryController> logger)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/product
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<InventoryViewModel>>(_inventoryRepository.GetAll()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_mapper.Map<InventoryViewModel>(_inventoryRepository.Find(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        // POST api/product
        [HttpPost]
        public IActionResult Post([FromBody]InventoryViewModel inventory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _inventoryRepository.Add(_mapper.Map<Inventory>(inventory));
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
                return BadRequest();
            }
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]InventoryViewModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _inventoryRepository.Update(_mapper.Map<Inventory>(product));
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
                return BadRequest();
            }
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _inventoryRepository.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}
