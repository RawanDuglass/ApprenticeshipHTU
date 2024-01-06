using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using ProjectHTU.DTO;
using ProjectHTU.Entities;
using ProjectHTU.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ProjectHTU.Controllers
{
    public class ReportController : Controller
    {
        UserManager<Person> userManager;
        IReportRepo reportRepo;
        IAssignmentRepo assignmentRepo;
        IDocumentRepo documentRepo;
        public ReportController(IReportRepo reportRepo, IDocumentRepo documentRepo, IAssignmentRepo assignmentRepo, UserManager<Person> userManager
)
        {
            this.reportRepo = reportRepo;
            this.documentRepo = documentRepo;
            this.assignmentRepo = assignmentRepo;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Index(int Id)
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

            return View();
        }

        [Authorize(Roles = "STUDENT")]
        public IActionResult Add(int Id)
        {
            InsertReportDTO reportDTO = new InsertReportDTO();
            reportDTO.assignmentId = Id;
            reportDTO.reportStatusId = 1;

            return View(reportDTO);
        }

        [Authorize(Roles = "STUDENT")]
        [HttpPost]
        public IActionResult Insert(InsertReportDTO reportDTO, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                Report report = new Report();

                ReportLog reportLog = new ReportLog();

                report.reportName = reportDTO.reportName;
                report.reportDescription = reportDTO.reportDescription;
                report.reportNotes = reportDTO.reportNotes;
                report.assignmentId = reportDTO.assignmentId;
                report.reportStatusId = reportDTO.reportStatusId;
                report.reportId = reportDTO.reportId;
                reportRepo.createReport(report);

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
                document.reportId = report.reportId;
                documentRepo.uploadDocument(document);
                return RedirectToAction("Report", "Student", new { Id = report.assignmentId });
                // return RedirectToAction("SendEmail", "Email", new { Id = report.assignmentId  });
            }
            else
            {
                InsertReportDTO report = new InsertReportDTO();
                report.assignmentId = reportDTO.assignmentId;
                report.reportStatusId = 1;

                return View("Add", reportDTO);

            }
        }

        [Authorize(Roles = "STUDENT")]

        public ActionResult Edit(int Id)
        {
            ViewBag.report = reportRepo.GetAllReports().Where(x => x.reportId == Id).SingleOrDefault();
            ViewBag.doc = documentRepo.getAllDocuments().ToList();
            UpdateReportDTO updateReportDTO = new UpdateReportDTO();
            updateReportDTO.assignmentId = ViewBag.report.assignmentId;
            updateReportDTO.reportStatusId = ViewBag.report.reportStatusId;
            updateReportDTO.reportId = Id;

            return View(updateReportDTO);
        }

        [Authorize(Roles = "STUDENT")]

        [HttpPost]
        public async Task<ActionResult> Update(UpdateReportDTO updateReportDTO, IFormFile formFile)
        {
            Report report = new Report();
            report.reportNotes = updateReportDTO.reportNotes;
            report.reportName = updateReportDTO.reportName;
            report.reportDescription = updateReportDTO.reportDescription;
            report.assignmentId = updateReportDTO.assignmentId;
            if (updateReportDTO.reportStatusId == 3)
            {
                report.reportStatusId = 1;
            }
            else
            {
                report.reportStatusId = updateReportDTO.reportStatusId;
            }
            report.reportId = updateReportDTO.reportId;

            await reportRepo.UpdateReport(report);
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
                document.reportId = report.reportId;

                documentRepo.uploadDocument(document);
            }
            //return RedirectToAction("UploadFile", "Document", new { Id = report.assignmentId });
            return RedirectToAction("Report", "Student", new { Id = report.assignmentId });
        }

        [Authorize(Roles = "STUDENT")]

        public ActionResult Delete(int Id)
        {
            var x = reportRepo.GetAllReports().Where(x => x.reportId == Id).SingleOrDefault();
            reportRepo.DeleteReport(Id);

            return RedirectToAction("Report", "Student", new { Id = x.assignmentId });
        }


        [Authorize(Roles = "TEAMLEADER")]

        public async Task<IActionResult> Approve(int Id)
        {
            var x = reportRepo.GetAllReports().Where(x => x.reportId == Id).SingleOrDefault();

            x.reportStatusId = 2;
            await reportRepo.UpdateReport(x);


            return RedirectToAction("Report", "TeamLeader", new { Id = x.assignmentId });
        }

        [Authorize(Roles = "TEAMLEADER")]

        public async Task<IActionResult> Reject(int Id)
        {
            var x = reportRepo.GetAllReports().Where(x => x.reportId == Id).SingleOrDefault();

            x.reportStatusId = 3;


            await reportRepo.UpdateReport(x);
            return RedirectToAction("Report", "TeamLeader", new { Id = x.assignmentId });
        }

        [Authorize(Roles = "ADMIN , SCHOOLSUPERVISOR")]

        public IActionResult ReportTimeline(int Id)
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

            ViewBag.name = assignmentRepo.GetAllAssignment().Where(x => x.assignmentId == Id).SingleOrDefault();
            InsertAssignmentDTO insertAssignmentDTO = new InsertAssignmentDTO();
            insertAssignmentDTO.assignmentName = ViewBag.name.assignmentName;

            return View(insertAssignmentDTO);
        }

    }


}
