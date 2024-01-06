using ProjectHTU.Data;
using ProjectHTU.Entities;

namespace ProjectHTU.Repository
{
    public class DocumentRepo : IDocumentRepo
    {
        ApplicationDbContext context;
        public DocumentRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void deleteDocument(int documentId)
        {
            var del = context.documents.Where(x => x.documentId == documentId).SingleOrDefault();
            context.documents.Remove(del);
            context.SaveChanges();
        }

        public List<Document> getAllDocuments()
        {
            return context.documents.ToList();
        }

        public void uploadDocument(Document document)
        {
            context.documents.Add(document);
            context.SaveChanges();
        }

        public Document GetFile(long documentId)
        {
            return context.documents.Where(x => x.documentId == documentId).SingleOrDefault();
        }
    }
}
