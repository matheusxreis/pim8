namespace pim8.Data 
{

    public interface iUserRepository {
        void save(UserEntity user);
        UserEntity? getUserByUsername(string? username);
        UserEntity? getUserById(string? id);
        void remove(string? email);


    }

}