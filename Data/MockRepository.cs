
namespace pim8.Data {


    public class MockRepository {
        List<UserEntity?> users = new List<UserEntity?>();

        public void save(UserEntity user){
            users.Add(user);  
        }

        public UserEntity? getUserByUsername(string username){
            return users.Find(x => x?.username == username);
        }

    }
}