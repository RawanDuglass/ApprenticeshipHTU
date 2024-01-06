using ProjectHTU.Entities;
namespace ProjectHTU.Repository
{
    public interface IDocumentRepo
    {
        public List<Document> getAllDocuments();
        public void deleteDocument(int documentId);
        public void uploadDocument(Document document);
        public Document GetFile(long documentId);
    }
}
