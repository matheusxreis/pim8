using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using pim8.Models;
using pim8.Models.Database;

namespace pim8.Controllers;

public class HomeController : Controller
{
    private readonly iUserRepository _userRepository;

    public HomeController(iUserRepository userRepository)
    {
     _userRepository = userRepository;
    }

   
    private UserModel? getUserFromCookies(){
        string? userId = Request.Cookies["SESSION_UNIP_PIM8"];
         UserModel? user = _userRepository.getUserById(userId);
         return user;
    }

    public IActionResult Index()
    {              
        UserModel? user = getUserFromCookies();

        ViewData["username"] = user?.username ?? "";
        ViewData["name"] = user?.name ?? "";
        ViewData["email"] = user?.email ?? "";

        return View();
    }

    public IActionResult Profile()
    {
        UserModel? user = getUserFromCookies();

        ViewData["username"] = user?.username ?? "";
        ViewData["name"] = user?.name ?? "";
        ViewData["email"] = user?.email ?? "";
        ViewData["cpf"] = user?.cpf ?? "";
        ViewData["photo"] = user?.photo ?? "~/img/avatar.png";

        return View();
    }

    public IActionResult Default(){
        return RedirectToAction("Index", "Home");
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
