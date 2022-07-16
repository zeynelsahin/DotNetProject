using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : Controller
{
    [HttpGet]
    public string Get()
    {
        var generator = new NumberGenerator();
        var number = generator.GetRandomNumber();
        generator = null;
        return number.ToString();
    }
}