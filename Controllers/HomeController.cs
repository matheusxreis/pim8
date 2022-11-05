using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using pim8.Models;

namespace pim8.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    private IActionResult IsLogged(){
         string? loggedIn = Request.Cookies["SESSION_UNIP_PIM8"];
        if(loggedIn == null) { 
          return RedirectToAction("SignIn", "Auth");
        }
        return View();
    }
    public IActionResult Index()
    {
               
        return IsLogged();
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
