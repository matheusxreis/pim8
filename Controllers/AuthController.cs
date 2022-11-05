using Microsoft.AspNetCore.Mvc;
using pim8.Models;

namespace pim8.Controllers;
public class AuthController : Controller {

    public IActionResult SignIn(){
        return View();
    }

    [HttpPost]
    public IActionResult SignIn(AuthModel authModel){

        Console.WriteLine(authModel.password);

        if(authModel.username == "adm") {
            Console.WriteLine("inside condition");
            return RedirectToAction("Index", "Home");
        }else {
            ModelState.AddModelError("", "Inválido");
        }

        return View();
    }
}
