namespace ProjectHTU.Entities
{
    public class School
    {
        public int schoolId { get; set; }
        public string schoolName { get; set; }
        public string schoolAddress { set; get; }
        public List<SchoolSupervisor> schoolSupervisors { set; get; }

    }
}
