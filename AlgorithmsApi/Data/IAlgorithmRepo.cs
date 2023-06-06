using Algorithms.Models;

namespace Algorithms.Data{
    public interface  IAlgorithmRepo
    {
        IEnumerable <Algorithm> GetAllAlgorithms();

        Algorithm GetAlgorithmByName(string name);

        Algorithm GetAlgorithmById(int Id);

        void DeleteAlgorithm(Algorithm algo);

        void UpdateAlgorithm(Algorithm algo);

        void CreateAlgorithm(Algorithm algo);
        
        bool ValidateSaveChanges();

    }

}