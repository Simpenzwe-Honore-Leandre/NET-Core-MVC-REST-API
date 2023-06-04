
using Algorithms.Models;
using Microsoft.EntityFrameworkCore;

namespace Algorithms.Data
{
    public class AlgorithmsContext : DbContext
    {
        public AlgorithmsContext(DbContextOptions<AlgorithmsContext> options) : base(options)
        {
            
        }
        //mapping objects to database in entity framework
        public DbSet<Algorithm>? AlgorithmSet { get; set; }

    }
}