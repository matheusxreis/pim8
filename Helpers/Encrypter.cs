using pim8.Controllers.iHelpers;

namespace pim8.Helpers
{

    public class Encrypter: iDecryptPassword, iEncryptPassword {

        public string encrypt(string password){
            return  password.Replace("1", "J");

        }
        public string decrypt(string password){
            
            return  password.Replace("J", "1");
        }

    }
}