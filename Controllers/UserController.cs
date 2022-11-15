using Microsoft.AspNetCore.Mvc;
using pim8.Models.Database;


namespace pim8.Controllers
{
    public class UserController : Controller
    {


        private readonly iUserRepository _userRepository;

        public UserController(iUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult UpdatePhoto(string file)
        {

            if (file != null)
            {
                string? id = Request.Cookies["SESSION_UNIP_PIM8"];
                _userRepository.updatePhoto(file, id ?? "");

            }


            return Json(new { status = "success" });
        }

        [HttpPost]
        public IActionResult UpdateData(string username, string name)
        {
            string? id = Request.Cookies["SESSION_UNIP_PIM8"];
            if(id!=null){
             _userRepository.updateData(id, username, name);
            }
             return Json(new { status = "success" });
        }


        public IActionResult UpdateAddress(){
            return View();
        }
    }

}