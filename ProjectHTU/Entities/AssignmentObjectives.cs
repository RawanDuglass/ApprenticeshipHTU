namespace ProjectHTU.Entities
{
    public class AssignmentObjectives
    {
        public int assignmentId { get; set; }
        public int objectiveId { get; set; }
        public Assignment assignments { get; set; }
        public Objective objectives { get; set; }
    }
}
