using Microsoft.EntityFrameworkCore;

namespace pim8.Data
{
    public class Context: DbContext
    {

        public Context(DbContextOptions<Context>options)
        :base(options) 
        {
        }

        public DbSet<UserEntity> users { get; set; }
    }
}