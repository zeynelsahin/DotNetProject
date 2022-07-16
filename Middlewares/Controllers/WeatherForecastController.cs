using Microsoft.AspNetCore.Mvc;

namespace Middlewares.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        throw new Exception("Test Hatası");
    }
    [HttpGet("Student")]
    public Student GetStudent()
    {
        return new Student()
        {
            Id = 1, FullName = "Zeynel Şahin"
        };
    }

    [HttpPost]
    public string CreateStudent([FromBody]Student student)
    {
        return "Student Created";
    }
}

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }
}