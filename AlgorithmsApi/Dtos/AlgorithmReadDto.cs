namespace Algorithms.Dtos
{
    //Data transfer objects to be used to abstract domain models
    //allows independence between model implementation and user's interpretation
    //can be added for all models if there are more
    public class AlgorithmReadDto
    {
        public string algorithmname { get; set; }

        public string description { get; set; } 

        public string usecases {get; set; } 
    }
}