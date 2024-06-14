using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using exo10._06.Models;

namespace exo10._06.Controllers;

public class HomeController : Controller
{
     /*private readonly ILogger<HomeController> _logger;
   public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }*/

    // IActionResult  -  type de la methode

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        System.Console.WriteLine("Je suis dans Privacy");
        return View();
    }
    public IActionResult Maroute()
    {
        System.Console.WriteLine("Je suis ici");
        return View("Privacy");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
