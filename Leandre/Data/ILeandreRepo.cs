using Leandre.Models;

namespace Leandre.Data
{
    public interface  ILeandreRepo
    {
        IEnumerable <Command> GetAppCommands();
        Models.Command GetCommandById(int id);
        
    }
}