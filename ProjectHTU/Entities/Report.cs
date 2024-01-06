namespace ProjectHTU.Entities
{
    public class Report
    {
        public int reportId { get; set; }
        public string reportName { get; set; }
        public string reportDescription { get; set; }
        public string reportNotes { get; set; }
        public int assignmentId { get; set; }
        public Assignment assignments { get; set; }
        public ReportStatus reportStatus { get; set; }
        public int reportStatusId { get; set; }
        public int? documentId { get; set; }
    }
}
