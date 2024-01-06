using Microsoft.EntityFrameworkCore;
using ProjectHTU.Data;
using ProjectHTU.Entities;

namespace ProjectHTU.Repository
{
    public class AssignmentRepo : IAssignmentRepo
    {
        ApplicationDbContext context;

        public AssignmentRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAssignment(Assignment assignment, List<int> objectiveIds)
        {
            context.assignments.Add(assignment);
            await context.SaveChangesAsync();

            foreach (var objId in (List<int>)objectiveIds)
            {
                context.assignmentObjectives.Add(new AssignmentObjectives()
                {
                    assignmentId = assignment.assignmentId,
                    objectiveId = objId
                }
           );
            }
            context.SaveChanges();
        }

        public async Task DeleteAssignment(int Id)
        {
            var x = context.assignments.Where(x => x.assignmentId == Id).SingleOrDefault();

            context.assignments.Remove(x);
            context.SaveChanges();
        }

        public List<Assignment> GetAllAssignment()
        {
            return context.assignments.Include(x => x.reports).Include(x => x.assignmentObjectives).ToList();
        }

        public async Task UpdateAssignment(Assignment assignment, List<int> objectiveIds)
        {
            context.assignments.Update(assignment);
            await context.SaveChangesAsync();

            if (objectiveIds != null)
            {
                var existingObjectives = context.assignmentObjectives.Where(x => x.assignmentId == assignment.assignmentId);
                context.RemoveRange(existingObjectives);
                await context.SaveChangesAsync();
                // Add new assignment objectives
                foreach (var objId in objectiveIds)
                {
                    context.assignmentObjectives.Add(new AssignmentObjectives
                    {
                        assignmentId = assignment.assignmentId,
                        objectiveId = objId
                    });
                }
                await context.SaveChangesAsync();
            }
            else
            {
                await context.SaveChangesAsync();

            }
        }

    }
}





