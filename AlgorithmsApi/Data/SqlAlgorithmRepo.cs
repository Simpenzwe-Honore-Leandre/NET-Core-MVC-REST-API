using Algorithms.Dtos;
using Algorithms.Models;

namespace Algorithms.Data
{
    public class SqlAlgorithmRepo:IAlgorithmRepo
    {
        private AlgorithmsContext _context;

        public SqlAlgorithmRepo(AlgorithmsContext context)
        {
            //injecting dependicies via constructor 
            _context = context;
        }
        public IEnumerable<Algorithm> GetAllAlgorithms()
        {
            //returning the dbset
            return _context.AlgorithmSet.ToList();
        }

        public Algorithm GetAlgorithmByName(string name)
        {
            return _context.AlgorithmSet.FirstOrDefault(algo => algo.algorithmname == name);
        }

        public Algorithm GetAlgorithmById(int Id)
        {
            return _context.AlgorithmSet.FirstOrDefault(algo => algo.Id == Id);
        }

        public bool ValidateSaveChanges()
        {
            return (_context.SaveChanges() > 0 );
        }

        public void CreateAlgorithm(Algorithm algo)
        {
            if(algo == null)
            {
                throw new ArgumentNullException(nameof(algo));
            }

            _context.AlgorithmSet.Add(algo);
        }

        public void UpdateAlgorithm(Algorithm algo)
        {
            //no implementation required for now
        }

        public void DeleteAlgorithm(Algorithm algo)
        {
            if(algo == null)
            {
                throw new ArgumentNullException(nameof(algo));
            }
            _context.Remove(algo);
        }
    }
}