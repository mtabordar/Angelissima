namespace AngelissimaApi.Controllers
{
    using AutoMapper;
    using Core.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;
    using System;
    using System.Collections.Generic;
    using ViewModels;

    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductCore _productCore;
        private IMapper _mapper;
        private ILogger<ProductController> _logger;

        public ProductController(IProductCore productCore, IMapper mapper, ILogger<ProductController> logger)
        {
            _productCore = productCore;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/product
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<ProductViewModel>>(_productCore.GetAll()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, Json(ex.Message));
            }
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_mapper.Map<ProductViewModel>(_productCore.Find(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, Json(ex.Message));
            }
        }

        // POST api/product
        [HttpPost]
        public IActionResult Post([FromBody]ProductViewModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productCore.Add(_mapper.Map<Product>(product));
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

        // PUT api/product/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]ProductViewModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productCore.Update(_mapper.Map<Product>(product));
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

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productCore.Remove(id);
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
