using Microsoft.AspNetCore.Mvc;
using pim8.Models;
using pim8.Models.Database;
namespace pim8.Controllers;
public class AuthController : Controller
{
    
    private readonly iUserRepository _userRepository;
   
    public AuthController(iUserRepository userRepository){
        _userRepository = userRepository;
    }
   
    private IActionResult IsLogged()
    {
        string? loggedIn = Request.Cookies["SESSION_UNIP_PIM8"];
        if (loggedIn != null)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }
    public IActionResult SignIn()
    {
        return IsLogged();
    }



    [HttpPost]
    public IActionResult SignIn(AuthViewModel authModel)
    {


        UserModel? user = _userRepository.getUserByUsername(authModel.username);
        if (user != null && user.password == authModel.password)
        {
            Response.Cookies.Append("SESSION_UNIP_PIM8", user.id.ToString());
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError("", "Usuário ou senha incorretos");
        }

        return View();
    }

    public IActionResult SignOut()
    {
        Response.Cookies.Delete("SESSION_UNIP_PIM8");
        return RedirectToAction("SignIn", "Auth");
    }

    public IActionResult SignUp()
    {
        return IsLogged();
    }

    [HttpPost]
    public IActionResult SignUp(UserViewModel userModel)
    {

        if (userModel.username == "adm")
        {
            ModelState.AddModelError("username", "Nome de usuário existente.");
            return View();
        }
        if (userModel.password != userModel.confirmation_password)
        {
            ModelState.AddModelError("confirmation_password", "Senhas não correspodem");
            ModelState.AddModelError("password", "Senhas não correspodem");
            return View();
        }
        if (ModelState.IsValid)
        {
            UserModel user = new UserModel(
                userModel.name ?? "gio",
                userModel.username ?? "gio",
                userModel.email ?? "email",
                userModel.password ?? "gio",
                userModel.cpf ?? "",
                userModel.phone ?? ""
                );
            _userRepository.save(user);

            return RedirectToAction("SignUpSuccess", "Auth");
        }
        return View();
    }

    public IActionResult SignUpSuccess()
    {

        return View();
    }

    [HttpPost]
    public IActionResult DeleteProfile()
    {

        string email = Request.Query["email"].ToString();
        _userRepository.remove(email);
        return RedirectToAction("Index", "Home");
    }
}
