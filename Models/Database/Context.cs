using Microsoft.EntityFrameworkCore;

namespace pim8.Models.Database
{
    public class Context: DbContext
    {

        public Context(DbContextOptions<Context>options)
        :base(options) 
        {
        }

        public DbSet<UserModel> users { get; set; }
        public DbSet<AddressModel> address { get; set; }
    }
}