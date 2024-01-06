namespace ProjectHTU.Entities
{
    public class ReportStatus
    {
        public int reportStatusId { get; set; }
        public string reportStatusName { get; set; }
        public List<Report> reports { get; set; }
    }
}
