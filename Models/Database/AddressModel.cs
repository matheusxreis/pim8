//id
//logradouro
//num
//cep
//bairro
//cidade
//estado
using System.ComponentModel.DataAnnotations.Schema;
namespace pim8.Models.Database
{
    [Table("address")]
    public class AddressModel 
    {
        public AddressModel(
            string place, 
            string number, 
            string cep, 
            string neighborhood, 
            string city, 
            string state,
            string user
        ){
            this.id = Guid.NewGuid().ToString();
            this.place = place;
            this.number = number;
            this.cep = cep;
            this.neighborhood = neighborhood;
            this.city = city;
            this.state = state;
            this.user = user;
        }

    [Column("id")]
     public string id { get; set; }
    [Column("place")]
     public string place { get; set; }
    
    [Column("number")]
    public string number { get; set; }
     [Column("cep")]
     public string cep { get; set; }
      [Column("neighborhood")]
     public string neighborhood { get; set; }
     [Column("city")]
     
     public string city { get; set; }
     [Column("state")]
     public string state { get; set; }
      [Column("complement")]
     public string complement { get; set; }
     [Column("user")]
     public string user { get; set; }


    }
}
