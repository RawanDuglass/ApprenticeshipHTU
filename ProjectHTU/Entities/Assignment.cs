
namespace ProjectHTU.Entities;

public class Assignment
{
    public int assignmentId { get; set; }
    public string assignmentName { get; set; }
    public string assignmentDescription { get; set; }
    public string assignmentNote { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public Training trainings { get; set; }
    public int trainingId { get; set; }
    public List<AssignmentObjectives> assignmentObjectives { get; set; }
    public List<Report> reports { get; set; }
    public int? documentId { get; set; }

}
