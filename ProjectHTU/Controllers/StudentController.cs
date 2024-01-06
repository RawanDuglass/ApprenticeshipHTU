using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectHTU.DTO;
using ProjectHTU.Entities;
using ProjectHTU.Repository;

namespace ProjectHTU.Controllers
{
    public class StudentController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        IStudentRepo studentRepo;
        IReportRepo reportRepo;
        IDocumentRepo documentRepo;
        public StudentController(IStudentRepo studentRepo, IReportRepo reportRepo, IDocumentRepo documentRepo, RoleManager<IdentityRole> roleManager)
        {
            this.studentRepo = studentRepo;
            this.reportRepo = reportRepo;
            this.documentRepo = documentRepo;
            this._roleManager = roleManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewBag.students = studentRepo.GetAllstudents();
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Add()
        {

            ViewBag.roles = _roleManager.Roles.ToList(); // Assuming roleManager is injected via dependency injection

            return View();
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Insert(InsertStudentDTO insertStudent)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();
                student.firstName = insertStudent.firstName;
                student.secondName = insertStudent.secondName;
                student.thiredName = insertStudent.thiredName;
                student.lastName = insertStudent.lastName;
                student.Email = insertStudent.Email;
                student.major = insertStudent.major;

                await studentRepo.CreateStudent(student, insertStudent.password, insertStudent.roleIds);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.roles = _roleManager.Roles.ToList();

                return View("Add");
            }
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Edit(string Id)
        {
            ViewBag.students = studentRepo.GetAllstudents().Where(x => x.Id == Id).SingleOrDefault();

            return View();
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Update(UpdateStudentDTO updateStudent, string Id)
        {
            Student student = new Student();
            student.firstName = updateStudent.firstName;
            student.secondName = updateStudent.secondName;
            student.thiredName = updateStudent.thiredName;
            student.lastName = updateStudent.lastName;
            student.major = updateStudent.major;
            student.Email = updateStudent.Email;
            student.Id = Id;

            await studentRepo.UpdateStudent(student);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete(string Id)
        {
            await studentRepo.DeleteStudent(Id);
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

            Report report = new Report();
            report.assignmentId = Id;

            return View(report);
        }

    }
}
