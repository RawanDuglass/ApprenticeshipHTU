using System.ComponentModel.DataAnnotations;

namespace ProjectHTU.DTO
{
    public class InsertReportDTO
    {

        public int reportId { get; set; }
        [Required]
        public string reportName { get; set; }
        [Required]

        public string reportDescription { get; set; }
        [Required]

        public string reportNotes { get; set; }
        [Required]

        public int assignmentId { get; set; }
        [Required]

        public int reportStatusId { get; set; }

        public int documentId { get; set; }
    }
}
