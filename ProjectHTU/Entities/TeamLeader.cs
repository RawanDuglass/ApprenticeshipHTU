namespace ProjectHTU.Entities
{
    public class TeamLeader : Person
    {
        List<Training> trainings { get; set; }
        public int companyId { get; set; }
        public Company company { get; set; }

    }
}
