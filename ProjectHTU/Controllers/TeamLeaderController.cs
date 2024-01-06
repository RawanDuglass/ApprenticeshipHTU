using Microsoft.AspNetCore.Mvc;
using ProjectHTU.DTO;
using ProjectHTU.Entities;
using ProjectHTU.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ProjectHTU.Controllers
{
    public class TeamleaderController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        ITeamLeaderRepo teamLeaderRepo;
        ICompanyRepo companyRepo;
        IReportRepo reportRepo;
        IDocumentRepo documentRepo;

        public TeamleaderController(ITeamLeaderRepo teamLeaderRepo, IReportRepo reportRepo, ICompanyRepo companyRepo, IDocumentRepo documentRepo, RoleManager<IdentityRole> roleManager)
        {
            this.teamLeaderRepo = teamLeaderRepo;
            this.companyRepo = companyRepo;
            this.reportRepo = reportRepo;
            this.documentRepo = documentRepo;

            this._roleManager = roleManager;
        }

        [Authorize(Roles = "ADMIN , SCHOOLSUPERVISOR")]
        public IActionResult Index(string Id)
        {

            ViewBag.teamleaders = teamLeaderRepo.GetAllTeamLeaders();
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Add()
        {
            ViewBag.roles = _roleManager.Roles.ToList();
            ViewBag.companies = companyRepo.getAllCompanies();
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Insert(InsertTeamLeaderDTO insertTeamLeader)
        {
            if (ModelState.IsValid)
            {
                TeamLeader teamLeader = new TeamLeader();
                teamLeader.firstName = insertTeamLeader.firstName;
                teamLeader.secondName = insertTeamLeader.secondName;
                teamLeader.thiredName = insertTeamLeader.thiredName;
                teamLeader.lastName = insertTeamLeader.lastName;
                teamLeader.Email = insertTeamLeader.Email;
                teamLeader.companyId = insertTeamLeader.companyId;
                await teamLeaderRepo.CreateTeamLeader(teamLeader, insertTeamLeader.password, insertTeamLeader.roleIds);
                return RedirectToAction("SendEmail", "TeamLeader");
            }
            else
            {
                ViewBag.roles = _roleManager.Roles.ToList();
                ViewBag.companies = companyRepo.getAllCompanies();
                return View("Add");
            }
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Update(UpdateTeamLeaderDTO updateTeamLeader, string Id)
        {
            TeamLeader teamLeader = new TeamLeader();
            teamLeader.firstName = updateTeamLeader.firstName;
            teamLeader.secondName = updateTeamLeader.secondName;
            teamLeader.thiredName = updateTeamLeader.thiredName;
            teamLeader.lastName = updateTeamLeader.lastName;
            teamLeader.companyId = updateTeamLeader.companyId;
            teamLeader.Email = updateTeamLeader.Email;
            teamLeader.Id = Id;
            teamLeader.companyId = updateTeamLeader.companyId;
            await teamLeaderRepo.UpdateTeamLeader(teamLeader);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Edit(string Id)
        {
            ViewBag.teamleader = teamLeaderRepo.GetAllTeamLeaders().Where(x => x.Id == Id).SingleOrDefault();
            ViewBag.companies = companyRepo.getAllCompanies();
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(string Id)
        {
            await teamLeaderRepo.DeleteTeamLeader(Id);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Report(int Id)
        {
            var reports = reportRepo.GetAllReports().Where(x => x.assignmentId == Id).ToList();
            if (reports == null || !reports.Any())
            {
                ViewBag.NoDataMessage = "There is no data to display.";
            }
            else
            {
                ViewBag.reports = reports;
            }
            ViewBag.doc = documentRepo.getAllDocuments();

            return View();
        }
    }
}


