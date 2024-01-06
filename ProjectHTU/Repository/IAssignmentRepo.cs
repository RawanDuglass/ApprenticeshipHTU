using ProjectHTU.Entities;

namespace ProjectHTU.Repository
{
    public interface IAssignmentRepo
    {
        public List<Assignment> GetAllAssignment();
        public Task DeleteAssignment(int Id);
        public Task UpdateAssignment(Assignment assignment, List<int> objectiveIds);
        public Task CreateAssignment(Assignment assignment, List<int> objectiveIds);

    }
}
