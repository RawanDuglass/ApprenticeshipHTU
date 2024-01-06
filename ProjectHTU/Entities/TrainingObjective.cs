namespace ProjectHTU.Entities
{
    public class TrainingObjective
    {
        public int objectiveId { get; set; }
        public int trainingId { get; set; }
        public Training trainings { get; set; }
        public Objective objectives { get; set; }
    }
}
