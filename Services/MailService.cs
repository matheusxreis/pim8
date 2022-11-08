using System.Net;
using System.Net.Mail;
using pim8.Controllers.iHelpers;

namespace pim8.Services 
{
    public class MailService: iSendMail {


        private readonly IConfiguration _config;
        public MailService(IConfiguration config){
            _config = config;
        }
        public void send(string toAddress, string confirmationToken){
            
            SmtpClient client = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false, 
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587, 
                Credentials = new NetworkCredential($"{_config["MailService:email"]}", $"{_config["MailService:password"]}")
            };
         
            try{
                client.Send(
                $"{_config["MailService:email"]}", 
                toAddress,
                "Não Responda",
                $"Você se cadastrou no Projeto Integrado Multidisciplinar 8. Por favor acesse o link: https://localhost:7186/Auth/ConfirmEmail/{confirmationToken} para confirmar a conta. Caso tenha sido um engano basta ignorar."
                );
                
            }catch(SmtpException e) {
                Console.WriteLine(e);
            }
        }

    }
}