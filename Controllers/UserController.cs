using Microsoft.AspNetCore.Mvc;


namespace pim8.Controllers
{
    public class UserController: Controller
    {
        public IActionResult UpdatePhoto(string files){
            if(files != null) { 
                // var byteArrayFile = System.fILE
                // var x = Convert.ToBase64String();

                var filePath = Path.GetTempFileName();
                byte[] byteFile = System.IO.File.ReadAllBytes(filePath);
                string base64 = Convert.ToBase64String(byteFile);

                //var stream = System.IO.File.Create(filePath);
                //files[0].CopyToAsync(stream);
                Console.WriteLine($"toptop, file veio{files.ToString()}");
            }else {
                Console.WriteLine($"TRISTEZA TRISTEZA!");

            }

            return RedirectToAction("Profile", "Home");
        }
    }

}