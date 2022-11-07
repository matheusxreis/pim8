using pim8.Controllers.iHelpers;
using BCrypt.Net;
namespace pim8.Helpers
{

    public class Encrypter: iComparePassword, iEncryptPassword {

        public string encrypt(string password){
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
            

        }
        public Boolean compare(string password, string hash){
            
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

    }
}