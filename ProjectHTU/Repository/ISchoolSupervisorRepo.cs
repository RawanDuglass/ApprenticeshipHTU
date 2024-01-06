using ProjectHTU.Entities;

namespace ProjectHTU.Repository
{
    public interface ISchoolSupervisorRepo
    {
        public List<SchoolSupervisor> GetAllSchoolSupervisors();
        public Task DeleteSchoolSupervisor(string Id);
        public Task UpdateSchoolSupervisor(SchoolSupervisor schoolSupervisor);
        public Task CreateSchoolSupervisor(SchoolSupervisor schoolSupervisor, string password, string roleIds);
    }
}
