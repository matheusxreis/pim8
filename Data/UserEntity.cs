using System.ComponentModel.DataAnnotations.Schema;
namespace pim8.Data {

    [Table("users")]
    public class UserEntity 
    {
        public UserEntity(
            string name,
            string username,
            string email,
            string password, 
            string cpf, 
            string phone
        ){
            this.id = Guid.NewGuid().ToString();
            this.username = username;
            this.email = email;
            this.name = name;
            this.password = password;
            this.cpf = cpf;
            this.phone = phone;
        }
        [Column("id")]
        public string id { get; set; }
        [Column("name")]
        public string? name { get; set; }
        [Column("username")]

        public string? username { get; set; }

       [Column("email")]
       public string? email { get; set; }

       [Column("password")]

        public string? password { get; set; }      
        [Column("cpf")]

        public string? cpf { get; set; }
        [Column("phone")]

        public string? phone { get; set; }

    }
}