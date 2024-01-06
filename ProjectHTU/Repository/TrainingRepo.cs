using Microsoft.EntityFrameworkCore;
using ProjectHTU.Data;
using ProjectHTU.Entities;

namespace ProjectHTU.Repository
{
    public class TrainingRepo : ITrainingRepo
    {
        ApplicationDbContext context;

        public TrainingRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CreateTraining(Training training, List<int> objectiveIds)
        {
            context.trainings.Add(training);
            context.SaveChanges();


            foreach (var objId in (List<int>)objectiveIds)
            {
                context.trainingObjectives.Add(new TrainingObjective()
                {
                    trainingId = training.trainigId,
                    objectiveId = objId
                }
           );

            }
            context.SaveChanges();

        }

        public Task DeleteTraining(string Id)
        {
            throw new NotImplementedException();
        }


        public List<Training> GetAllTraining()
        {
            return context.trainings.Include(x => x.teamLeader).ThenInclude(x => x.company).Include(x => x.student).Include(x => x.schoolSupervisor).ThenInclude(x => x.school).Include(x => x.trainingObjectives).ThenInclude(x => x.objectives).ToList();
        }

        public List<TrainingObjective> GetAllTrainingObjectives()
        {
            return context.trainingObjectives.Include(x => x.objectives).ToList();
        }

        public Task UpdateTraining(Training training)
        {
            throw new NotImplementedException();
        }

        public List<Objective> GetAllObjectives()
        {
            return context.objectives.ToList();
        }
    }
}

