using System.ComponentModel.DataAnnotations.Schema;
namespace pim8.Models.Database
 {

    [Table("users")]
    public class UserModel
    {
        public UserModel(
            string name,
            string username,
            string email,
            string password, 
            string cpf, 
            string phone,
            string confirmationToken
        ){
            this.id = Guid.NewGuid().ToString();
            this.username = username;
            this.email = email;
            this.name = name;
            this.password = password;
            this.cpf = cpf;
            this.phone = phone;
            this.confirmationToken = confirmationToken;
            this.active = false;
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
        [Column("confirmation_token")]

        public string? confirmationToken { get; set; }
        [Column("active")]

        public Boolean? active { get; set; }

    }
}