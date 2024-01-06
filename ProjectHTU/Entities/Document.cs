namespace ProjectHTU.Entities
{
    public class Document
    {
        public int documentId { get; set; }
        public string documentName { get; set; }
        public string contentType { get; set; }
        public byte[] file { get; set; }
        public int reportId { get; set; }
        public int assignmentId { get; set; }

    }
}
