using pim8.Controllers.iHelpers;

namespace pim8.Helpers
{

    public class Validator: iValidatorEmail {

       public Boolean isEmailValid(string email) {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith(".")) {
                return false;
            }
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch {
                return false;
            }
        }

    }
}