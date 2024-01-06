using ProjectHTU.Entities;

namespace ProjectHTU.Repository
{
    public interface ITeamLeaderRepo
    {
        public List<TeamLeader> GetAllTeamLeaders();
        public Task DeleteTeamLeader(string Id);
        public Task UpdateTeamLeader(TeamLeader teamLeader);
        public Task CreateTeamLeader(TeamLeader teamLeader, string password, string roleIds);
    }
}
