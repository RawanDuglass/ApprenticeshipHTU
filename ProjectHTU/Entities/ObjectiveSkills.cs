namespace ProjectHTU.Entities
{
    public class ObjectiveSkills
    {
        public int objectiveId { get; set; }
        public int skillId { get; set; }
        public Objective objectives { get; set; }
        public Skill skills { get; set; }
    }
}
