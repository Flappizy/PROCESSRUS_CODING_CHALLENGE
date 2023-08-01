using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace PROCESSRUS_CODING_CHALLENGE.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccessController : ControllerBase
{
    [HttpGet("fruits")]
    [Authorize(Roles = "Admin,BackOffice")]
    public IActionResult GetFruits()
    {
        var fruits = new string[]
        {
            "blueberry",
            "pineapple",
            "orange",
            "mango",
            "pear",
            "lemon"
        };

        return Ok(fruits);
    }
}
