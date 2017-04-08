namespace AngelissimaApi.Controllers
{
    using Models;
    using ViewModels;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using AngelissimaApi.Core.Interfaces;

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
                return Ok(_mapper.Map<IEnumerable<SaleViewModel>>(_saleCore.GetAll()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        // GET api/sale/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_mapper.Map<SaleViewModel>(_saleCore.Find(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
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
                    _saleCore.Add(_mapper.Map<Sale>(sale));
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
                return BadRequest(ex);
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
                    _saleCore.Update(_mapper.Map<Sale>(sale));
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
                return BadRequest(ex);
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
                return BadRequest(ex);
            }
        }
    }
}
