using System.ComponentModel.DataAnnotations;

namespace ProjectHTU.DTO
{
    public class InsertAssignmentDTO
    {
        public int assignmentId { get; set; }
        [Required]

        public string assignmentName { get; set; }
        [Required]

        public string assignmentDescription { get; set; }
        [Required]

        public string assignmentNote { get; set; }

        public int trainingId { get; set; }
        [Required]

        public DateTime startDate { get; set; }
        [Required]

        public DateTime endDate { get; set; }

        public List<int> objectiveIds { get; set; }

        public int documentId { get; set; }


    }
}
