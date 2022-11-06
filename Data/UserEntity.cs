
namespace pim8.Data {

    public class UserEntity 
    {
        public UserEntity(
            string name,
            string username,
            string password, 
            string cpf, 
            string phone
        ){
            this.id = Guid.NewGuid().ToString();
            this.username = username;
            this.name = name;
            this.password = password;
            this.cpf = cpf;
            this.phone = phone;
        }
        public string id { get; set; }
        public string? name { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }      
        public string? cpf { get; set; }
        public string? phone { get; set; }


        public string getUsername() { 
            if(this.username == null){
                return "Não tem username"+this.name;
            }
            return "O nome de usuário é:"+this.username;
         }

    }
}