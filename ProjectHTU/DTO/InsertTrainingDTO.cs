using System.ComponentModel.DataAnnotations;

namespace ProjectHTU.DTO
{
    public class InsertTrainingDTO
    {
        [Required]
        public string studentId { get; set; }
        [Required]
        public string teamLeaderId { get; set; }
        [Required]
        public string schoolSupervisorId { get; set; }
        [Required]
        public DateTime startDate { get; set; }
        [Required]
        public DateTime endDate { get; set; }
        [Required]
        public List<int> objectiveIds { get; set; }
    }
}
