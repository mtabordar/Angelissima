namespace AngelissimaApi.Controllers
{
    using System;
    using AngelissimaApi.Core.Interfaces;
    using AngelissimaApi.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    public class ReportDayController : Controller
    {
        private IReportCore _reportCore;
        private ILogger<ReportDayController> _logger;

        public ReportDayController(IReportCore reportCore, ILogger<ReportDayController> logger)
        {
            _reportCore = reportCore;
            _logger = logger;
        }        

        // GET api/reportday/5
        [HttpGet]
        public IActionResult Get(ReportFilterViewModel filter)
        {
            try
            {
                return Ok(_reportCore.Find(filter));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, Json(ex.Message));
            }
        }
    }
}
