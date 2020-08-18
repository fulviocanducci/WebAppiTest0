using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAppiTest0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok(new { DateTime.Now });
        }
    }
}
