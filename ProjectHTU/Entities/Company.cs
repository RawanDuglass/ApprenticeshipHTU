namespace ProjectHTU.Entities
{
    public class Company
    {
        public int companyId { get; set; }
        public string companyName { get; set; }
        public string companyAddress { set; get; }
        public List<TeamLeader> teamLeaders { set; get; }
    }
}
