namespace Leandre.Models
{   
     public class Command
    {
        public int Id { get; set; }
        public string HowTo { get; set; } = default!;
        public string Line {get; set; } = default!;

        public string Platform { get; set; } = default!;
    }

}
