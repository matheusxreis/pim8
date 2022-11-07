
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
            this.users?.Add(user);
           
        }

        public UserEntity? getUserByUsername(string? username){
            UserEntity? u = users.Find(x=> x.username == username);
            return u;

        }

        public UserEntity? getUserById(string? id){
            return users.Find(x=> x.id == id);
        }


        public void remove(string? email){
            UserEntity? u = users.Find(x=>x.email == email);
            if(u != null) { users.Remove(u); }
        }
   
    }
}