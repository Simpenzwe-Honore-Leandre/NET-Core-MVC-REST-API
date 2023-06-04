
using Algorithms.Models;
using Microsoft.EntityFrameworkCore;

namespace Algorithms.Data
{
    public class AlgorithmsContext : DbContext
    {
        public AlgorithmsContext(DbContextOptions<AlgorithmsContext> opt) : base(opt)
        {
            
        }
        //mapping objects to database in entity framework
        public DbSet<Algorithm> ? AlgorithmSet { get; set; }


    }
}