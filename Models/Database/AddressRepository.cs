

namespace pim8.Models.Database {


    public class AddressRepository: iAddressRepository {
        public AddressRepository(Context context){
            _context = context;
        }

        private readonly Context _context;

        public void save(AddressModel address) {
            _context.address.Add(address);
            _context.SaveChanges();
        }


   
    }
}