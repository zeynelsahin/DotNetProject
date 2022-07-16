using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private INumberGenerator _generator;

    public WeatherForecastController(INumberGenerator generator)
    {
        _generator = generator;
    }

    [HttpGet]
    public string Get()
    {
        var number = _generator.GetRandomNumber();
        return number.ToString();
    }
}