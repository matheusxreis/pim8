
using System.ComponentModel.DataAnnotations;
namespace pim8.Models
{
    public class AddressViewModel 
    {


   
    [Required(ErrorMessage = "Logradouro obrigatório")]
    [Display(Name = "Logradouro")]
     public string place { get; set; }
    
    [Required(ErrorMessage = "Número obrigatório")]
    [Display(Name = "Número")]
    public string number { get; set; }
    [Required(ErrorMessage = "CEP obrigatório")]
    [Display(Name = "CEP")]
     public string cep { get; set; }
    [Required(ErrorMessage = "Bairro obrigatório")]
    [Display(Name = "Bairro")]     
    public string neighborhood { get; set; }     
    [Required(ErrorMessage = "Cidade obrigatória")]
    [Display(Name = "Cidade")]     
    public string city { get; set; }
    [Required(ErrorMessage = "Estado obrigatório")]
    [Display(Name = "Estado")]     
     public string state { get; set; }

    [Display(Name = "Complemento")]     
     public string complement { get; set; }
    
    }
}
