using pim8.Controllers.iHelpers;

namespace pim8.Helpers
{
    public class GenerateToken:iGenerateEmailToken {
        
       public string generate(){
            return Guid.NewGuid().ToString();
        }
    }
}