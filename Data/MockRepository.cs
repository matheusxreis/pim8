
namespace pim8.Data {


    public class MockRepository: iUserRepository {
        public MockRepository(Context context){
            _context = context;
        }

        private readonly Context _context;

        public void save(UserEntity user){
           
            _context.users.Add(user);
            _context.SaveChanges();
           
        }

        public UserEntity? getUserByUsername(string? username){

            UserEntity? u = _context.users.FirstOrDefault(x=> x.username == username);
            return u;

        }

        public UserEntity? getUserById(string? id){
            UserEntity? u = _context.users.FirstOrDefault(x=> x.id == id);
             return u;

        }


        public void remove(string? email){
            UserEntity? u = _context.users.FirstOrDefault(x=> x.email == email);
            Console.WriteLine("++++++++++++++++++");
            Console.WriteLine("Ooooooooi"+email+u?.email);
            Console.WriteLine("++++++++++++++++++");

            if(u != null) { _context.users.Remove(u); }
            _context.SaveChanges();

        }
   
    }
}