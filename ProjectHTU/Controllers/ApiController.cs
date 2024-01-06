using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHTU.Data;
using ProjectHTU.Entities;

namespace ProjectHTU.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Api
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Training>>> GetTrainings()
        {
          if (_context.trainings == null)
          {
              return NotFound();
          }
            return await _context.trainings.ToListAsync();
        }

        // GET: api/Api/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Training>> GetTraining(int id)
        {
          if (_context.trainings == null)
          {
              return NotFound();
          }
            var training = await _context.trainings.FindAsync(id);

            if (training == null)
            {
                return NotFound();
            }

            return training;
        }

        // GET: Api/GetCompany
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            if (_context.companies == null)
            {
                return NotFound();
            }
            return await _context.companies.ToListAsync();
        }

        // GET: Api/GetCompany/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            if (_context.companies == null)
            {
                return NotFound();
            }
            var company = await _context.companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // GET: Api/GetSchool
        [HttpGet]
        public async Task<ActionResult<IEnumerable<School>>> GetSchools()
        {
            if (_context.schools == null)
            {
                return NotFound();
            }
            return await _context.schools.ToListAsync();
        }

        // GET: Api/GetSchool/5
        [HttpGet("{id}")]
        public async Task<ActionResult<School>> GetSchool(int id)
        {
            if (_context.schools == null)
            {
                return NotFound();
            }
            var school = await _context.schools.FindAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            return school;
        }
     
    }
}
