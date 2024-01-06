using ProjectHTU.Data;
using ProjectHTU.Entities;

namespace ProjectHTU.Repository
{
    public class CompanyRepo : ICompanyRepo
    {
        ApplicationDbContext context;
        public CompanyRepo(ApplicationDbContext context)
        {
            this.context = context;
        }


        public List<Company> getAllCompanies()
        {
            return context.companies.ToList();
        }
    }
}
