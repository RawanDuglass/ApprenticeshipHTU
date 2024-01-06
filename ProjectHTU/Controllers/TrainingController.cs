using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectHTU.DTO;
using ProjectHTU.Entities;
using ProjectHTU.Repository;

namespace ProjectHTU.Controllers
{

    public class TrainingController : Controller
    {
        ITeamLeaderRepo teamLeaderRepo;
        ISchoolSupervisorRepo schoolSupervisorRepo;
        IStudentRepo studentRepo;
        ITrainingRepo trainingRepo;
        public TrainingController(ITrainingRepo trainingRepo, IStudentRepo studentRepo, ISchoolSupervisorRepo schoolSupervisorRepo, ITeamLeaderRepo teamLeaderRepo)
        {
            this.trainingRepo = trainingRepo;
            this.studentRepo = studentRepo;
            this.teamLeaderRepo = teamLeaderRepo;
            this.schoolSupervisorRepo = schoolSupervisorRepo;
        }

        [Authorize(Roles = "ADMIN , SCHOOLSUPERVISOR")]
        public IActionResult Index()
        {
            ViewBag.trainings = trainingRepo.GetAllTraining().ToList();
            ViewBag.trainingobj = trainingRepo.GetAllTrainingObjectives();

            return View();
        }


        [Authorize(Roles = "ADMIN , STUDENT , SCHOOLSUPERVISOR")]
        public IActionResult TrainingStudent(string Id)
        {

            var trainings = trainingRepo.GetAllTraining().Where(x => x.studentId == Id).ToList();
            if (trainings == null || !trainings.Any())
            {
                ViewBag.NoDataMessage = "There is no data to display.";
            }
            else
            {
                ViewBag.trainings = trainings;
            }
            return View();
        }


        [Authorize(Roles = "ADMIN , TEAMLEADER , SCHOOLSUPERVISOR")]
        public IActionResult TrainingTeamleader(string Id)
        {
            var trainings = trainingRepo.GetAllTraining().Where(x => x.teamLeaderId == Id).ToList();

            if (trainings == null || !trainings.Any())
            {
                ViewBag.NoDataMessage = "There is no data to display.";
            }
            else
            {
                ViewBag.trainings = trainings;
            }
            ViewBag.objectives = trainingRepo.GetAllObjectives();
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Add()
        {
            ViewBag.students = studentRepo.GetAllstudents();
            ViewBag.schoolsupervisors = schoolSupervisorRepo.GetAllSchoolSupervisors();
            ViewBag.teamlraders = teamLeaderRepo.GetAllTeamLeaders();
            ViewBag.objectives = trainingRepo.GetAllObjectives();

            return View();

        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Insert(InsertTrainingDTO insertTraining)
        {
            if (ModelState.IsValid)
            {
                Training training = new Training();
                training.schoolSupervisorId = insertTraining.schoolSupervisorId;
                training.studentId = insertTraining.studentId;
                training.teamLeaderId = insertTraining.teamLeaderId;
                training.startDate = insertTraining.startDate;
                training.endDate = insertTraining.endDate;
                trainingRepo.CreateTraining(training, (List<int>)insertTraining.objectiveIds);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.students = studentRepo.GetAllstudents();
                ViewBag.schoolsupervisors = schoolSupervisorRepo.GetAllSchoolSupervisors();
                ViewBag.teamlraders = teamLeaderRepo.GetAllTeamLeaders();
                ViewBag.objectives = trainingRepo.GetAllObjectives();
                return View("Add");
            }
        }
    }
}
