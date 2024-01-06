using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectHTU.DTO;
using ProjectHTU.Entities;
using ProjectHTU.Repository;

namespace ProjectHTU.Controllers
{
    public class AssignmentController : Controller
    {
        ITeamLeaderRepo teamLeaderRepo;
        ISchoolSupervisorRepo schoolSupervisorRepo;
        IStudentRepo studentRepo;
        IAssignmentRepo assignmentRepo;
        ITrainingRepo trainingRepo;
        ITrainingObjectivesRepo trainingObjectivesRepo;
        IAssignmentObjectiveRepo assignmentObjectiveRepo;
        IDocumentRepo documentRepo;

        public AssignmentController(ITrainingRepo trainingRepo, IReportRepo reportRepo, IAssignmentObjectiveRepo assignmentObjectiveRepo, IAssignmentRepo assignmentRepo, ITrainingObjectivesRepo trainingObjectivesRepo, IStudentRepo studentRepo, ISchoolSupervisorRepo schoolSupervisorRepo, ITeamLeaderRepo teamLeaderRepo, IDocumentRepo documentRepo)
        {
            this.trainingRepo = trainingRepo;
            this.studentRepo = studentRepo;
            this.teamLeaderRepo = teamLeaderRepo;
            this.schoolSupervisorRepo = schoolSupervisorRepo;
            this.assignmentRepo = assignmentRepo;
            this.trainingObjectivesRepo = trainingObjectivesRepo;
            this.assignmentObjectiveRepo = assignmentObjectiveRepo;
            this.documentRepo = documentRepo;
        }

        [Authorize]
        public IActionResult Index(int Id)
        {
            ViewBag.assignments = assignmentRepo.GetAllAssignment().Where(x => x.trainingId == Id).ToList();
            return View();
        }

        [Authorize(Roles = "STUDENT , SCHOOLSUPERVISOR , ADMIN")]
        public IActionResult StudentIndex(int Id)
        {
            var assignments = assignmentRepo.GetAllAssignment().Where(x => x.trainingId == Id).ToList();
            if (assignments == null || !assignments.Any())
            {
                ViewBag.NoDataMessage = "There is no data to display.";
            }
            else
            {
                ViewBag.assignments = assignments;
            }
            return View(Id);
        }

        [Authorize(Roles = "TEAMLEADER , SCHOOLSUPERVISOR , ADMIN")]
        public IActionResult TeamleaderIndex(int Id)
        {
            var assignments = assignmentRepo.GetAllAssignment().Where(x => x.trainingId == Id).ToList();

            if (assignments == null || !assignments.Any())
            {
                ViewBag.NoDataMessage = "There is no data to display.";
            }
            else
            {
                ViewBag.assignments = assignments;
            }

            ViewBag.assignmentObjectives = assignmentObjectiveRepo.getAllAssignmentObjectives().ToList();
            Assignment assignment = new Assignment();
            assignment.trainingId = Id;
            ViewBag.doc = documentRepo.getAllDocuments();


            return View(assignment);
        }

        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult Add(int Id)
        {
            ViewBag.assignments = assignmentRepo.GetAllAssignment().Where(x => x.trainingId == Id).ToList();
            ViewBag.trainingObjectives = trainingRepo.GetAllTrainingObjectives().ToList();
            InsertAssignmentDTO insertAssignmentDTO = new InsertAssignmentDTO();
            insertAssignmentDTO.trainingId = Id;


            return View(insertAssignmentDTO);
        }

        [Authorize(Roles = "TEAMLEADER")]
        public async Task<IActionResult> Delete(int Id, int IdTraining)
        {

            await assignmentRepo.DeleteAssignment(Id);

            return RedirectToAction("TeamleaderIndex", new { Id = IdTraining });
        }



        [Authorize(Roles = "TEAMLEADER")]
        [HttpPost]
        public async Task<IActionResult> Insert(InsertAssignmentDTO insertAssignment, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                Assignment assignment = new Assignment();
                assignment.assignmentName = insertAssignment.assignmentName;
                assignment.assignmentDescription = insertAssignment.assignmentDescription;
                assignment.assignmentNote = insertAssignment.assignmentNote;
                assignment.trainingId = insertAssignment.trainingId;
                assignment.endDate = insertAssignment.endDate;
                assignment.startDate = insertAssignment.startDate;

                await assignmentRepo.CreateAssignment(assignment, (List<int>)insertAssignment.objectiveIds);

                Entities.Document document = new Entities.Document();
                if (formFile.Length > 0)
                {
                    Stream st = formFile.OpenReadStream();
                    using (BinaryReader br = new BinaryReader(st))
                    {
                        var byteFile = br.ReadBytes((int)st.Length);
                        document.file = byteFile;
                    }
                }
                document.documentName = formFile.FileName;
                document.contentType = formFile.ContentType;
                document.assignmentId = assignment.assignmentId;
                documentRepo.uploadDocument(document);
                return RedirectToAction("TeamleaderIndex", new { Id = assignment.trainingId });

                //  return RedirectToAction("SendEmail" ,"Email", new { Id = assignment.trainingId });
            }
            else
            {
                ViewBag.assignments = assignmentRepo.GetAllAssignment().Where(x => x.trainingId == insertAssignment.trainingId).ToList();
                ViewBag.trainingObjectives = trainingRepo.GetAllTrainingObjectives().ToList();
                InsertAssignmentDTO insertAssignmentDTO = new InsertAssignmentDTO();
                insertAssignmentDTO.trainingId = insertAssignment.trainingId;
                return View("Add", insertAssignmentDTO);
            }
        }

        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult Edit(int Id)
        {
            ViewBag.assignment = assignmentRepo.GetAllAssignment().Where(x => x.assignmentId == Id).SingleOrDefault();
            ViewBag.objective = trainingRepo.GetAllObjectives();
            ViewBag.doc = documentRepo.getAllDocuments().ToList();

            UpdateAssignmentDTO updateAssignment = new UpdateAssignmentDTO();
            updateAssignment.assignmentId = Id;
            updateAssignment.trainingId = Id;
            return View(updateAssignment);
        }

        [Authorize(Roles = "TEAMLEADER")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAssignmentDTO updateAssignment, IFormFile formFile)
        {
            Assignment assignment = new Assignment();
            assignment.assignmentName = updateAssignment.assignmentName;
            assignment.assignmentDescription = updateAssignment.assignmentDescription;
            assignment.assignmentNote = updateAssignment.assignmentNote;
            assignment.assignmentId = updateAssignment.assignmentId;
            assignment.trainingId = updateAssignment.trainingId;


            await assignmentRepo.UpdateAssignment(assignment, (List<int>)updateAssignment.objectiveIds);
            if (formFile != null)
            {
                Entities.Document document = new Entities.Document();
                if (formFile.Length > 0)
                {
                    Stream st = formFile.OpenReadStream();
                    using (BinaryReader br = new BinaryReader(st))
                    {
                        var byteFile = br.ReadBytes((int)st.Length);
                        document.file = byteFile;
                    }
                }


                document.documentName = formFile.FileName;

                document.contentType = formFile.ContentType;
                document.assignmentId = assignment.assignmentId;

                documentRepo.uploadDocument(document);

            }
            return RedirectToAction("TeamleaderIndex", "Assignment", new { Id = assignment.trainingId });
        }
    }
}
