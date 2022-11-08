namespace pim8.Controllers.iHelpers 
{

    public interface iSendMail {
        public void send(string toAddress, string confirmationToken);
    }


}