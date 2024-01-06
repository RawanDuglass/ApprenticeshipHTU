using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectHTU.Data;
using ProjectHTU.Entities;
using ProjectHTU.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace ProjectHTU.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context =
                context;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)

                if (User.IsInRole("TEAMLEADER")) { return RedirectToAction("IndexUser", new { Id = User.FindFirst(ClaimTypes.NameIdentifier).Value }); }
                else if (User.IsInRole("STUDENT")) { return RedirectToAction("IndexUser", new { Id = User.FindFirst(ClaimTypes.NameIdentifier).Value }); }
                else if (User.IsInRole("ADMIN")) { return RedirectToAction("IndexUser", new { Id = User.FindFirst(ClaimTypes.NameIdentifier).Value }); }
                else if (User.IsInRole("SCHOOLSUPERVISOR")) { return RedirectToAction("IndexUser", new { Id = User.FindFirst(ClaimTypes.NameIdentifier).Value }); }

            return View();
        }

        public IActionResult IndexUser(string Id)
        {
            return View(new { Id = Id });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        [Authorize(Roles = "TEAMLEADER , STUDENT")]
        public IActionResult UploadFile(IFormFile formFile)
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
            context.documents.Add(document);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        [Authorize]
        public FileStreamResult GetFile(long documentId)
        {
            var file = context.documents.Where(x => x.documentId == documentId).SingleOrDefault();
            Stream stream = new MemoryStream(file.file);
            return new FileStreamResult(stream, file.contentType);
        }

    }
}