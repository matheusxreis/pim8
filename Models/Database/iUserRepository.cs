namespace pim8.Models.Database
{

    public interface iUserRepository {
        void save(UserModel user);
        UserModel? getUserByUsername(string? username);
        UserModel? getUserByEmail(string? email);
        UserModel? getUserById(string? id);
        void remove(string? email);
        void activeAccount(string token);


    }

}