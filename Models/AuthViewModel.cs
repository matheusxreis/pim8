using System.ComponentModel.DataAnnotations;

namespace pim8.Models {

    public class AuthViewModel 
    {
        [Required(ErrorMessage = "Informe um nome de usuário.")]
        [Display(Name = "Nome de usuário")]
        public string? username { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string? password { get; set; }

    }
}