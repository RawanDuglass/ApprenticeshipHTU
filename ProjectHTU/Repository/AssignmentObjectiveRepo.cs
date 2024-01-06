using Microsoft.EntityFrameworkCore;
using ProjectHTU.Data;
using ProjectHTU.Entities;

namespace ProjectHTU.Repository
{
    public class AssignmentObjectiveRepo : IAssignmentObjectiveRepo
    {
        ApplicationDbContext context;
        public AssignmentObjectiveRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<AssignmentObjectives> getAllAssignmentObjectives()
        {
            return context.assignmentObjectives.Include(x => x.objectives).Include(x => x.assignments).ToList();
        }

    }
}
