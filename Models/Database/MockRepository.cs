
namespace pim8.Models.Database {


    public class MockRepository: iUserRepository {
        public MockRepository(Context context){
            _context = context;
        }

        private readonly Context _context;

        public void save(UserModel user){
           
            _context.users.Add(user);
            _context.SaveChanges();
           
        }

        public UserModel? getUserByUsername(string? username){

            UserModel? u = _context.users.FirstOrDefault(x=> x.username == username);
            return u;

        }

        public UserModel? getUserById(string? id){
            UserModel? u = _context.users.FirstOrDefault(x=> x.id == id);
             return u;

        }


        public void remove(string? email){
            UserModel? u = _context.users.FirstOrDefault(x=> x.email == email);
            Console.WriteLine("++++++++++++++++++");
            Console.WriteLine("Ooooooooi"+email+u?.email);
            Console.WriteLine("++++++++++++++++++");

            if(u != null) { _context.users.Remove(u); }
            _context.SaveChanges();

        }
   
    }
}