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
    private readonly iValidatorEmail _validator;
    private readonly iValidatorCPF _validatorCPF;


    public AuthController(
        iUserRepository userRepository,
        iComparePassword compare,
        iEncryptPassword encrypt,
        iSendMail sendMail,
        iGenerateEmailToken generateEmailToken,
        iValidatorEmail validator,
        iValidatorCPF validatorCPF)
    {
        _userRepository = userRepository;
        _compare = compare;
        _encrypt = encrypt;
        _sendMail = sendMail;
        _generateEmailToken = generateEmailToken;
        _validator = validator;
        _validatorCPF = validatorCPF;

    }

    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignIn(AuthViewModel authModel)
    {

        UserModel? user = _userRepository.getUserByUsername(authModel.username);
        if (
            user != null &&
            _compare.compare(authModel.password ?? "", user.password ?? "") &&
            user.active == true
        )
        {


            Response.Cookies.Append("SESSION_UNIP_PIM8", user.id.ToString());
            return RedirectToAction("Index", "Home");
        }
        else
        {

            if (user?.active == false)
            {
                ModelState.AddModelError("", "Necessário confirmação de e-mail");
            }
            else
            {
                ModelState.AddModelError("", "Usuário ou senha incorretos");
            }
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
        return View();
    }

    [HttpPost]
    public IActionResult SignUp(UserViewModel userModel)
    {

        if(!_validator.isEmailValid(userModel.email??"")) {
            ModelState.AddModelError("email", "Email inválido.");
            return View();
        }
         if(!_validatorCPF.isCPFValid(userModel.cpf??"")) {
            ModelState.AddModelError("cpf", "CPF inválido.");
            return View();
        }


        if (_userRepository.getUserByUsername(userModel.username) != null)
        {
            ModelState.AddModelError("username", "Nome de usuário existente.");
            return View();
        }
        if (_userRepository.getUserByEmail(userModel.email) != null)
        {
            ModelState.AddModelError("email", "Email existente.");
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

            return RedirectToAction("SignUpSuccess", "Auth", new { email = userModel.email });
        }
        return View();
    }

    [Route("Auth/SignUpSuccess")]
    public IActionResult SignUpSuccess()
    {
        string email = Request.Query["email"];
        UserModel? user = _userRepository.getUserByEmail(email);
        if (user != null && user.active == false)
        {
            return View();
        }
        return RedirectToAction("SignIn", "Auth");
    }

    [HttpPost]
    public IActionResult DeleteProfile()
    {

        string email = Request.Query["email"].ToString();
        _userRepository.remove(email);
        return RedirectToAction("SignOut", "Auth");
    }

    [Route("Auth/ConfirmEmail/{token?}")]
    public IActionResult ConfirmEmail(string? token)
    {
        _userRepository.activeAccount(token ?? "");
        return RedirectToAction("Index", "Home");
    }

}
