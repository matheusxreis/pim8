namespace pim8.Models.Database
{

    public interface iUserRepository {
        void save(UserModel user);
        UserModel? getUserByUsername(string? username);
        UserModel? getUserById(string? id);
        void remove(string? email);


    }

}