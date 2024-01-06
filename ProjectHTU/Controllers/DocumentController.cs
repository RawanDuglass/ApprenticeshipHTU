using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectHTU.Entities;
using ProjectHTU.Repository;

namespace ProjectHTU.Controllers
{
    public class DocumentController : Controller
    {
        IDocumentRepo documentRepo;
        public DocumentController(IDocumentRepo documentRepo)
        {
            this.documentRepo = documentRepo;
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewBag.doc = documentRepo.getAllDocuments().ToList();
            return View();
        }

        [Authorize(Roles = "TEAMLEADER , STUDENT")]

        public IActionResult Delete(int documentId, int reportId)
        {
            documentRepo.deleteDocument(documentId);
            // return RedirectToAction("Edit" , "Report" , new { Id = reportId }
            return RedirectToAction("Edit", "Report", new { Id = reportId }
     );
        }


        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult DeleteAssignment(int documentId, int assignmentId)
        {
            documentRepo.deleteDocument(documentId);
            // return RedirectToAction("Edit" , "Report" , new { Id = reportId }
            return RedirectToAction("Edit", "Assignment", new { Id = assignmentId }
     );
        }

        [Authorize(Roles = "TEAMLEADER , STUDENT")]
        [HttpPost]
        public IActionResult UploadFile(IFormFile formFile /*, int Id*/)
        {
            Document document = new Document();
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
            documentRepo.uploadDocument(document);

            return RedirectToAction("Index");
        }

        [Authorize]
        public FileStreamResult GetFile(long documentId)
        {
            var file = documentRepo.GetFile(documentId);
            Stream stream = new MemoryStream(file.file);
            return new FileStreamResult(stream, file.contentType);

        }
    }
}
