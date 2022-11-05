using Microsoft.AspNetCore.Mvc;
using pim8.Models;
using Microsoft.AspNetCore;

namespace pim8.Controllers;
public class AuthController : Controller {

    public IActionResult SignIn(){
        return View();
    }

    [HttpPost]
    public IActionResult SignIn(AuthModel authModel){
        if(authModel.username == "adm" && authModel.password == "adm") {
            Response.Cookies.Append("SESSION_UNIP_PIM8", authModel.username);
            return RedirectToAction("Index", "Home");
        }else {
            ModelState.AddModelError("", "Inválido");
        }

        return View();
    }

     public IActionResult SignOut(){
       Response.Cookies.Delete("SESSION_UNIP_PIM8");
       return RedirectToAction("SignIn", "Auth");
    }
      

}
