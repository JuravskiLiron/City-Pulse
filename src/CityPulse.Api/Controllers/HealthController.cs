using Microsoft.AspNetCore.Mvc;

namespace CityPulse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public string Get() => "OK";
}
