using Microsoft.EntityFrameworkCore;
using ProjectHTU.Data;
using ProjectHTU.Entities;

namespace ProjectHTU.Repository
{
    public class TrainingObjectivesRepo : ITrainingObjectivesRepo
    {

        ApplicationDbContext context;
        public TrainingObjectivesRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<TrainingObjective> getAllTrainingObjectives()
        {
            return context.trainingObjectives.Include(x => x.objectives).ToList();
        }

    }
}
