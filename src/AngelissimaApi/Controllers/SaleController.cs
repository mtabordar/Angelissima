namespace AngelissimaApi.Controllers
{
    using Models;
    using Models.Interfaces;
    using ViewModels;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    public class SaleController : Controller
    {
        private ISaleRepository _registryRepository;
        private IMapper _mapper;
        private ILogger<ProductController> _logger;

        public SaleController(ISaleRepository registryRepository, IMapper mapper, ILogger<ProductController> logger)
        {
            _registryRepository = registryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/registry
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<RegistryViewModel>>(_registryRepository.GetAll()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        // GET api/registry/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_mapper.Map<RegistryViewModel>(_registryRepository.Find(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        // POST api/registry
        [HttpPost]
        public IActionResult Post([FromBody]RegistryViewModel registry)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _registryRepository.Add(_mapper.Map<Sale>(registry));
                    return Created("", registry);
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

        // PUT api/registry/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProductViewModel registry)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _registryRepository.Update(_mapper.Map<Sale>(registry));
                    return Created("", registry);
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

        // DELETE api/registry/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _registryRepository.Remove(id);
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
