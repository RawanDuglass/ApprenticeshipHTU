using ProjectHTU.Entities;

namespace ProjectHTU.Repository
{
    public interface ITrainingRepo
    {
        public List<Training> GetAllTraining();
        public void CreateTraining(Training training, List<int> objectiveIds);
        public Task DeleteTraining(string Id);
        public Task UpdateTraining(Training training);
        public List<Objective> GetAllObjectives();
        public List<TrainingObjective> GetAllTrainingObjectives();

    }
}

