using Leandre.Models;

namespace Leandre.Data
{
    public class MockLeandreRepo : ILeandreRepo
    {
        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id = 0, HowTo= "Read a letter" ,Line =  "Read a word" , Platform = "Kindle Ebook"},
                new Command{Id = 1, HowTo= "Read two letter" ,Line =  "Read Mistborn" , Platform = "Kindle Ebook"},
                new Command{Id = 2, HowTo= "Read three letter" ,Line =  "Read Stormlight" , Platform = "Kindle Ebook"},
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id = 0, HowTo= "Read a letter" ,Line =  "Read a word" , Platform = "Kindle Ebook"};
        }
    
    }
}