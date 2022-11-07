﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using pim8.Models;
using pim8.Data;

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

        if(loggedIn==null) {
          return RedirectToAction("SignIn", "Auth");
        }

        MockRepository repository = MockRepository.getInstance();
        UserEntity? user = repository.getUserById(loggedIn);


        ViewData["username"] = user?.username ?? "";
        ViewData["name"] = user?.name ?? "";
        ViewData["cpf"] = user?.cpf ?? "";
        ViewData["email"] = user?.email ?? "";

        if(user?.name == null) { return RedirectToAction("SignOut", "Auth"); }
        return View();
    }
    public IActionResult Index()
    {               
        return IsLogged();
    }

    public IActionResult Profile()
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
