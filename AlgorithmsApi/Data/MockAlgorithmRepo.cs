using Algorithms.Models;

namespace Algorithms.Data
{
    public class MockAlgorithmRepo : IAlgorithmRepo
    {
        public IEnumerable<Algorithm> GetAppAlgorithms()
        {
            var commands = new List<Algorithm>
            {
                new Algorithm{Id = 0, HowTo= "Read a letter" ,Line =  "Read a word" , Platform = "Kindle Ebook"},
                new Algorithm{Id = 1, HowTo= "Read two letter" ,Line =  "Read Mistborn" , Platform = "Kindle Ebook"},
                new Algorithm{Id = 2, HowTo= "Read three letter" ,Line =  "Read Stormlight" , Platform = "Kindle Ebook"},
            };

            return commands;
        }

        public Algorithm GetAlgorithmById(int id)
        {
            return new Algorithm{Id = 0, HowTo= "Read a letter" ,Line =  "Read a word" , Platform = "Kindle Ebook"};
        }
    
    }
}