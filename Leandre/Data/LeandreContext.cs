
namespace Leandre.Data
{
    public class LeandreContext : DbContext
    {
        public LeandreContext(DbContextOptions<LeandreContext> opt) : base(opt)
        {
            
        }

        public Dbset<command> Commands { get; set; }
        

    }
}