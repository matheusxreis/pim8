
namespace pim8.Data {


    public class MockRepository {

        static private MockRepository? INSTANCE;
        private MockRepository(){}

        static public MockRepository getInstance(){
            if(MockRepository.INSTANCE == null){
                MockRepository.INSTANCE = new MockRepository();
            }
            return MockRepository.INSTANCE;
        }

        private List<UserEntity> users = new List<UserEntity>();


        public void save(UserEntity user){
           Console.WriteLine("DAD0 2 = ())()()====>"+user.cpf);
            this.users?.Add(user);
             Console.WriteLine("----------------");
            Console.WriteLine("SIZE 8=>D"+users?.Count().ToString());
            Console.WriteLine("----------------");
        }

        public UserEntity? getUserByUsername(string? username){
            Console.WriteLine("COUNT="+users.Count);
            Console.WriteLine("USERNAME="+username);
            if(username != null){
                            Console.WriteLine("ENTROOOOOOOOOOOOOOU");

            UserEntity? u = users.Last();
            if(u == null) { Console.WriteLine("U É NULL"); } else { Console.WriteLine("U nao eh null"); };
             Console.WriteLine("U="+users[0]?.username);
                return u;
            }
            return null;

        }

    }
}