using Microsoft.AspNetCore.Mvc;
using pim8.Models;
using Microsoft.AspNetCore;
using pim8.Data;
namespace pim8.Controllers;
public class AuthController : Controller {
    private IActionResult IsLogged(){
         string? loggedIn = Request.Cookies["SESSION_UNIP_PIM8"];
        if(loggedIn != null) { 
          return RedirectToAction("Index", "Home");
        }
        return View();
    }
    public IActionResult SignIn(){
        return IsLogged();
    }

    [HttpPost]
    public IActionResult SignIn(AuthModel authModel){
        if(authModel.username == "adm" && authModel.password == "adm") {
            Response.Cookies.Append("SESSION_UNIP_PIM8", authModel.username);
            return RedirectToAction("Index", "Home");
        }else {
            ModelState.AddModelError("", "Usuário ou senha não existem");
        }

        return View();
    }

    public IActionResult SignOut(){
       Response.Cookies.Delete("SESSION_UNIP_PIM8");
       return RedirectToAction("SignIn", "Auth");
    }
     
    public IActionResult SignUp(){
        return IsLogged();
    }

    [HttpPost]
    public IActionResult SignUp(UserModel userModel){

        if(userModel.username=="adm"){
            ModelState.AddModelError("username", "Nome de usuário existente.");
            return View();
        }
        if(userModel.password != userModel.confirmation_password){
            ModelState.AddModelError("confirmation_password", "Senhas não correspodem");
            ModelState.AddModelError("password", "Senhas não correspodem");
            return View();
        }
        if(ModelState.IsValid){
        MockRepository repository = new MockRepository();
            UserEntity user = new UserEntity(
                userModel.name, 
                userModel.username, 
                userModel.password, 
                userModel.cpf,
                userModel.phone
            );
            repository.save(user);
        return RedirectToAction("SignUpSuccess", "Auth");
        }
        return View();
    }

    public IActionResult SignUpSuccess(){
        return View();
    }
}
