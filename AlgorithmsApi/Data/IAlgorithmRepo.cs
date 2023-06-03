using Algorithms.Models;

namespace Algorithms.Data{
    public interface  IAlgorithmRepo
    {
        IEnumerable <Algorithm> GetAppAlgorithms();
        Models.Algorithm GetAlgorithmById(int id);
        
    }

}