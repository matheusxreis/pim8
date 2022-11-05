using Microsoft.AspNetCore.Mvc;
namespace pim8.Controllers;

public class AuthController : Controller {

    public IActionResult SignIn(){
        return View();
    }
}
