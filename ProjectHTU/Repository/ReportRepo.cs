using Microsoft.EntityFrameworkCore;
using ProjectHTU.Data;
using ProjectHTU.Entities;

namespace ProjectHTU.Repository
{
    public class ReportRepo : IReportRepo
    {
        ApplicationDbContext context;
        public ReportRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void createReport(Report report)
        {
            context.reports.Add(report);
            context.SaveChanges();
        }

        public void DeleteReport(int Id)
        {
            var x = context.reports.Where(x => x.reportId == Id).SingleOrDefault();
            context.reports.Remove(x);
            context.SaveChanges();
        }

        public List<Report> GetAllReports()
        {
            return context.reports.Include(x => x.reportStatus).Include(x => x.assignments).ToList();
        }

        public List<ReportLog> GetAllReportLog()
        {
            return context.reportLogs.Include(x => x.report).ToList();
        }

        public async Task UpdateReport(Report report)
        {

            context.reports.Update(report);
            await context.SaveChangesAsync();
        }

        public void createReportLog(ReportLog report)
        {
            context.reportLogs.Add(report);
            context.SaveChanges();
        }

        public void UpdateReportLog(ReportLog reportLog)
        {
            context.reportLogs.Update(reportLog);
            context.SaveChanges();
        }

    }
}
