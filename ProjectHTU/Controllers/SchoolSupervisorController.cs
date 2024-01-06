using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectHTU.DTO;
using ProjectHTU.Entities;
using ProjectHTU.Repository;

namespace ProjectHTU.Controllers
{

    public class SchoolSupervisorController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        ISchoolSupervisorRepo schoolSupervisorRepo;
        ISchoolRepo schoolRepo;

        public SchoolSupervisorController(ISchoolSupervisorRepo schoolSupervisorRepo, ISchoolRepo schoolRepo, RoleManager<IdentityRole> roleManager)
        {
            this.schoolSupervisorRepo = schoolSupervisorRepo;
            this.schoolRepo = schoolRepo;
            this._roleManager = roleManager;
        }

        [Authorize(Roles = "ADMIN , SCHOOLSUPERVISOR ")]
        public IActionResult Index()
        {
            ViewBag.schoolSupervisor = schoolSupervisorRepo.GetAllSchoolSupervisors();
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Add()
        {
            ViewBag.schools = schoolRepo.GetAllSchools();
            ViewBag.roles = _roleManager.Roles.ToList();
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Insert(InsertSchoolSupervisorDTO insertSchoolSupervisor)
        {
            if (ModelState.IsValid)
            {
                SchoolSupervisor schoolSupervisor = new SchoolSupervisor();
                schoolSupervisor.firstName = insertSchoolSupervisor.firstName;
                schoolSupervisor.secondName = insertSchoolSupervisor.secondName;
                schoolSupervisor.thiredName = insertSchoolSupervisor.thiredName;
                schoolSupervisor.lastName = insertSchoolSupervisor.lastName;
                schoolSupervisor.Email = insertSchoolSupervisor.Email;
                schoolSupervisor.schoolId = insertSchoolSupervisor.schoolId;

                await schoolSupervisorRepo.CreateSchoolSupervisor(schoolSupervisor, insertSchoolSupervisor.password, insertSchoolSupervisor.roleIds);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.roles = _roleManager.Roles.ToList();
                ViewBag.schools = schoolRepo.GetAllSchools();
                return View("Add");

            }
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Edit(string Id)
        {
            ViewBag.schoolSupervisors = schoolSupervisorRepo.GetAllSchoolSupervisors().Where(x => x.Id == Id).SingleOrDefault();
            ViewBag.schoolSupervisors = schoolSupervisorRepo.GetAllSchoolSupervisors().Where(x => x.Id == Id).SingleOrDefault();
            ViewBag.schools = schoolRepo.GetAllSchools();

            return View();
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Update(UpdateSchoolSupervisorDTO updateSUpdateSchool, string Id)
        {
            SchoolSupervisor schoolSupervisor = new SchoolSupervisor();
            schoolSupervisor.firstName = updateSUpdateSchool.firstName;
            schoolSupervisor.secondName = updateSUpdateSchool.secondName;
            schoolSupervisor.thiredName = updateSUpdateSchool.thiredName;
            schoolSupervisor.lastName = updateSUpdateSchool.lastName;
            schoolSupervisor.schoolId = updateSUpdateSchool.schoolId;
            schoolSupervisor.Email = updateSUpdateSchool.Email;
            schoolSupervisor.Id = Id;


            await schoolSupervisorRepo.UpdateSchoolSupervisor(schoolSupervisor);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "ADMIN ")]
        public async Task<IActionResult> Delete(string Id)
        {
            await schoolSupervisorRepo.DeleteSchoolSupervisor(Id);
            return RedirectToAction("Index");
        }
    }
}
