namespace AngelissimaApi.Controllers
{
    using System;
    using AngelissimaApi.Core.Interfaces;
    using AngelissimaApi.ViewModels;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    public class SaleController : Controller
    {
        private ISaleCore _saleCore;
        private IMapper _mapper;
        private ILogger<SaleController> _logger;

        public SaleController(ISaleCore saleCore, IMapper mapper, ILogger<SaleController> logger)
        {
            _saleCore = saleCore;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/sale
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_saleCore.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, Json(ex.Message));
            }
        }

        // GET api/sale/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_saleCore.Find(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, Json(ex.Message));
            }
        }

        // POST api/sale
        [HttpPost]
        public IActionResult Post([FromBody]SaleViewModel sale)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _saleCore.Add(sale);
                    return Created("", sale);
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

        // PUT api/sale/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SaleViewModel sale)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _saleCore.Update(sale);
                    return Created("", sale);
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

        // DELETE api/sale/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _saleCore.Remove(id);
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
