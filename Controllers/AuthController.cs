using Microsoft.AspNetCore.Mvc;
using pim8.Models;
using pim8.Models.Database;
using pim8.Controllers.iHelpers;
using pim8.Services;

namespace pim8.Controllers;
public class AuthController : Controller
{
    
    private readonly iUserRepository _userRepository;
    private readonly iComparePassword _compare;
    private readonly iEncryptPassword _encrypt;
    private readonly iSendMail _sendMail;
    private readonly iGenerateEmailToken _generateEmailToken;
   
    public AuthController(
        iUserRepository userRepository,
        iComparePassword compare,
        iEncryptPassword encrypt,
        iSendMail sendMail,
        iGenerateEmailToken generateEmailToken){
        _userRepository = userRepository;
        _compare = compare;
        _encrypt = encrypt;
        _sendMail = sendMail;
        _generateEmailToken = generateEmailToken;
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
        if (
            user != null && 
            _compare.compare(authModel.password ?? "", user.password ?? "")
        )
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
            string confirmationToken = _generateEmailToken.generate();
            UserModel user = new UserModel(
                userModel.name ?? "gio",
                userModel.username ?? "gio",
                userModel.email ?? "email",
                _encrypt.encrypt(userModel.password ?? ""),
                userModel.cpf ?? "",
                userModel.phone ?? "",
                confirmationToken
                );
            _userRepository.save(user);
            _sendMail.send(userModel.email ?? "", confirmationToken);

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

    [Route("Auth/ConfirmEmail/{token?}")]
    public IActionResult ConfirmEmail(string? token){
        _userRepository.activeAccount(token ?? "");
        return RedirectToAction("Index", "Home");
    }

}
