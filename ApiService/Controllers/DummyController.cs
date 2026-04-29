using Microsoft.AspNetCore.Mvc;
using ZooFramework.ApiService.Base;

namespace ZooFramework.WhiteApp.ApiService.Controllers
{
    [Route("dummy")]
    public class DummyController : ZooFrameworkController
    {
        [HttpGet]
        [Route("")]
        public ActionResult<string> DummyGey()
        {
            return Ok("dummy");
        }
    }
}