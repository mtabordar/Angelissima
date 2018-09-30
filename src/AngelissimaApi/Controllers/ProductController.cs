namespace AngelissimaApi.Controllers
{
    using System;
    using AngelissimaApi.Core.Interfaces;
    using AngelissimaApi.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductCore _productCore;
        private ILogger<ProductController> _logger;

        public ProductController(IProductCore productCore, ILogger<ProductController> logger)
        {
            _productCore = productCore;
            _logger = logger;
        }

        // GET: api/product
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_productCore.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, Json(ex.Message));
            }
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_productCore.Find(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, Json(ex.Message));
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
                    _productCore.Add(product);
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

        // PUT api/product/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]ProductViewModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productCore.Update(product);
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
                return StatusCode(StatusCodes.Status500InternalServerError, Json(ex.Message));
            }
        }
    }
}
