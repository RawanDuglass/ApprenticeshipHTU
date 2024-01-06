
namespace ProjectHTU.Entities

{
    public class Student : Person
    {
        public string major { get; set; }
        public List<Training> trainings { get; set; }

    }
}
