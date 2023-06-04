using Algorithms.Models;

namespace Algorithms.Data
{
    public class MockAlgorithmRepo : IAlgorithmRepo
    {
        public IEnumerable<Algorithm> GetAppAlgorithms()
        {
            var AlgorithmList = new List<Algorithm>
            {
                new Algorithm{Id = 0, description= "Read a letter" , usecases =  "Read a word" },
                new Algorithm{Id = 1, description= "Read two letter" , usecases =  "Read a word" },
                new Algorithm{Id = 2, description= "Read three letter" , usecases =  "Read a word" },
            };

            return AlgorithmList;
        }

        public Algorithm GetAlgorithmById(int id)
        {
            return new Algorithm{Id = id, description= "Read a letter" , usecases =  "Read a word" };
        }
    
    }
}