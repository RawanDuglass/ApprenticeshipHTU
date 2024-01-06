using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectHTU.Entities;

namespace ProjectHTU.Data
{
    public class ApplicationDbContext : IdentityDbContext<Person>
    {
        public DbSet<Student> students { get; set; }
        public DbSet<SchoolSupervisor> schoolSupervisors { get; set; }
        public DbSet<TeamLeader> teamLeaders { get; set; }
        public DbSet<Assignment> assignments { get; set; }
        public DbSet<AssignmentObjectives> assignmentObjectives { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Objective> objectives { get; set; }
        public DbSet<ObjectiveSkills> objectiveSkills { get; set; }
        public DbSet<Report> reports { get; set; }
        public DbSet<School> schools { get; set; }
        public DbSet<Skill> skills { get; set; }
        public DbSet<ReportStatus> reportStatuses { get; set; }
        public DbSet<Training> trainings { get; set; }
        public DbSet<TrainingObjective> trainingObjectives { get; set; }
        public DbSet<ReportLog> reportLogs { get; set; }
        public DbSet<Document> documents { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Training>().HasKey(x => x.trainigId);
            builder.Entity<ObjectiveSkills>().HasKey(x => new { x.objectiveId, x.skillId });
            builder.Entity<TrainingObjective>().HasKey(x => new { x.trainingId, x.objectiveId });
            builder.Entity<AssignmentObjectives>().HasKey(x => new { x.assignmentId, x.objectiveId });
        }

    }
}