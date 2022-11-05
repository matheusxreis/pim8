using System.ComponentModel.DataAnnotations;

namespace pim8.Models {

    public class UserModel 
    {
        
        [Required(ErrorMessage = "Nome obrigatório")]
        [Display(Name = "Nome Completo")]
        public string? name { get; set; }

        [Required(ErrorMessage = "Nome de usuário obrigatório")]
        [Display(Name = "Nome de Usuário")]
        public string? username { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]

        public string? password { get; set; }

        [Required(ErrorMessage = "Confirmação de senha é obrigatória")]
        [Display(Name = "Confirmação de senha")]
        [DataType(DataType.Password)]

        public string? confirmation_password { get; set; }
        
        [Required(ErrorMessage = "CPF obrigatório")]
        [Display(Name = "CPF")]
        public string? cpf { get; set; }

        [Required(ErrorMessage = "Telefone obrigatório")]
        [Display(Name = "Telefone")]
        public string? phone { get; set; }


    }
}