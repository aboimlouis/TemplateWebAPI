using Microsoft.AspNetCore.Mvc;
using Template.Application.Interfaces;

namespace Template.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private ITestBusiness _testBusiness { get; set; }

        public TestController(ILogger<TestController> logger, ITestBusiness testBusiness)
        {
            _testBusiness = testBusiness;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                //return Ok();
                return Ok(await _testBusiness.GetTest());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
