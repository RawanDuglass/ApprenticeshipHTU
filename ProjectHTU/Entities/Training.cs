
namespace ProjectHTU.Entities
{
    public class Training
    {
        public int trainigId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string teamLeaderId { get; set; }
        public string studentId { get; set; }
        public string schoolSupervisorId { get; set; }
        public TeamLeader teamLeader { get; set; }
        public Student student { get; set; }
        public SchoolSupervisor schoolSupervisor { get; set; }
        public List<Assignment> assignments { get; set; }
        public List<TrainingObjective> trainingObjectives { get; set; }

    }
}
