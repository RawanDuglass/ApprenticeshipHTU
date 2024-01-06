namespace ProjectHTU.Entities
{
    public class Skill
    {
        public int skillId { get; set; }
        public string skillName { get; set; }
        public Assignment assignmentName { get; set; }
        public List<ObjectiveSkills> objectiveSkills { get; set; }

    }
}
