using Algorithms.Models;

namespace Algorithms.Data
{
    public class MockAlgorithmRepo : IAlgorithmRepo
    {
        public IEnumerable<Algorithm> GetAllAlgorithms()
        {
            var AlgorithmList = new List<Algorithm>
            {
                new Algorithm{Id = 0, algorithmname="quicksorting is fun", description= "Read a letter" , usecases =  "Read a word" },
                new Algorithm{Id = 1, algorithmname="quicksorting is fun",description= "Read two letter" , usecases =  "Read a word" },
                new Algorithm{Id = 2, algorithmname="quicksorting is fun",description= "Read three letter" , usecases =  "Read a word" },
            };

            return AlgorithmList;
        }

        public Algorithm GetAlgorithmByName(string name)
        {
            return new Algorithm{Id = 0,algorithmname=name, description= "Read a letter" , usecases =  "Read a word" };
        }

        public bool ValidateSaveChanges()
        {
            throw new NotImplementedException();
        }

        public void CreateAlgorithm(Algorithm algo)
        {
            throw new NotImplementedException();
        }

        public Algorithm GetAlgorithmById(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAlgorithm(Algorithm algo)
        {
            throw new NotImplementedException();
        }

        public void DeleteAlgorithm(Algorithm algo)
        {
            throw new NotImplementedException();
        }
    }
}