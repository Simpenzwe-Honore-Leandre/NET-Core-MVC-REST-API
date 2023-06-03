
using Algorithms.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Algorithms.Data
{
    public class AlgorithmsContext : DbContext
    {
        public AlgorithmsContext(DbContextOptions<AlgorithmsContext> opt) : base(opt)
        {
            
        }
        public DbSet<Algorithm> AlgorithmSet { get; set; }


    }
}