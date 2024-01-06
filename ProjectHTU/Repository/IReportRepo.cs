using ProjectHTU.Entities;

namespace ProjectHTU.Repository
{
    public interface IReportRepo
    {
        public List<Report> GetAllReports();
        public void DeleteReport(int Id);
        public Task UpdateReport(Report report);
        public void createReport(Report report);
        public List<ReportLog> GetAllReportLog();
        public void createReportLog(ReportLog report);
        public void UpdateReportLog(ReportLog reportLog);
    }
}
