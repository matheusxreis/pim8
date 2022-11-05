
namespace pim8.Data {

    public class UserEntity 
    {
        public UserEntity(
            string? name,
            string? username,
            string? password, 
            string? cpf, 
            string? phone
        ){
            this.id = 102890129292;
            this.name = name;
            this.password = password;
            this.cpf = cpf;
            this.phone = phone;
        }
        public long id { get; set; }
        public string? name { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }      
        public string? cpf { get; set; }
        public string? phone { get; set; }


    }
}