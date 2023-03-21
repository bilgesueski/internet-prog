using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting.Server;
using Newtonsoft.Json.Linq;
using internet_prog.Models;

namespace internetProg.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Get the path of the Data.json file relative to the application's root directory
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Data.json");

        // Read the contents of the file into a string variable
        var jsonContent = System.IO.File.ReadAllText(filePath);

        // Parse the JSON string into a JObject
        var json = JObject.Parse(jsonContent);

        // Pass the JSON object to the view as a model
        return View(json);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

