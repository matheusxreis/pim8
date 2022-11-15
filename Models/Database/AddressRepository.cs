

namespace pim8.Models.Database {


    public class AddressRepository: iAddressRepository {
        public AddressRepository(Context context){
            _context = context;
        }

        private readonly Context _context;

        public void save(AddressModel address) {

            AddressModel? alreadyExist = _context.address.FirstOrDefault(x=> x.user == address.user);
            Console.WriteLine(alreadyExist?.ToString());
            if(alreadyExist == null){
            _context.address.Add(address);
            _context.SaveChanges();
            return;
            }

             alreadyExist.cep = address.cep;
             alreadyExist.city = address.city;
             alreadyExist.state = address.state;
             alreadyExist.neighborhood = address.neighborhood;
             alreadyExist.complement = address.complement;
             alreadyExist.number = address.number;
             alreadyExist.place = address.place;

             _context.address.Update(alreadyExist);
            _context.SaveChanges();
        }

        public AddressModel? getAddress(string id){

          return _context.address.FirstOrDefault(x=> x.user == id);
        }


   
    }
}