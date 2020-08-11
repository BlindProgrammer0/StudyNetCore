using Microsoft.AspNetCore.Mvc;

namespace Study.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController:Controller
    {
        public TestController()
        {

        }

        [HttpGet]
        public void Test() 
        {

        }
    }
}
