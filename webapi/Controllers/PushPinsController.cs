using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class PushPinsController : ControllerBase
{
    private readonly ILogger<PushPinsController> _logger;

    public PushPinsController(ILogger<PushPinsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPushPins")]
    [Produces("application/json", Type = typeof(IEnumerable<PushPin>))]
    public IEnumerable<PushPin> Get()
    {
        return Enumerable.Range(1, 20).Select(index => new PushPin
        {
            Latitude = Math.Round(Random.Shared.NextDouble() * (43.3 - 43.2) + 43.2, 5),
            Longitude = Math.Round(Random.Shared.NextDouble() * (-88.18 - -88.22) + -88.18, 5)
        })
        .ToArray();
    }
}
