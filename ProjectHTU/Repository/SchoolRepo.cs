using ProjectHTU.Data;
using ProjectHTU.Entities;

namespace ProjectHTU.Repository
{
    public class SchoolRepo : ISchoolRepo
    {

        ApplicationDbContext context;
        public SchoolRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<School> GetAllSchools()
        {
            return context.schools.ToList();
        }
    }
}
