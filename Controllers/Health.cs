using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    public class Health : ControllerBase
    {
        [HttpGet]
        [Route("/health")]
        public ActionResult sysHealth()
        {
            return Ok();
        }
    }
}
