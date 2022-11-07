namespace pim8.Controllers.iHelpers 
{

    public interface iComparePassword {
        public Boolean compare(string password, string hash);
    }


}