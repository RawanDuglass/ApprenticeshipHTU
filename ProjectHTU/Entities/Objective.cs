namespace ProjectHTU.Entities
{
    public class Objective
    {
        public int objectiveId { get; set; }
        public string objectiveName { get; set; }
        public List<ObjectiveSkills> objectiveSkills { get; set; }
        public List<TrainingObjective> trainingObjectives { get; set; }
        public List<AssignmentObjectives> assignmentObjectives { get; set; }
    }
}
