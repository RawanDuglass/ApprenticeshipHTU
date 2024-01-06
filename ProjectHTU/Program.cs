using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectHTU.Data;
using ProjectHTU.Entities;
using ProjectHTU.Repository;
// Startup.cs
var builder = WebApplication.CreateBuilder(args);

//swagger sevices 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Person>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IStudentRepo, StudentRepo>();
builder.Services.AddTransient<ISchoolSupervisorRepo, SchoolSupervisorRepo>();
builder.Services.AddTransient<ITeamLeaderRepo, TeamLeaderRepo>();
builder.Services.AddTransient<ICompanyRepo, CompanyRepo>();
builder.Services.AddTransient<ISchoolRepo, SchoolRepo>();
builder.Services.AddTransient<ITrainingRepo, TrainingRepo>();
builder.Services.AddTransient<ITrainingObjectivesRepo, TrainingObjectivesRepo>();
builder.Services.AddTransient<IAssignmentObjectiveRepo, AssignmentObjectiveRepo>();
builder.Services.AddTransient<IReportRepo, ReportRepo>();
builder.Services.AddTransient<IDocumentRepo, DocumentRepo>();



builder.Services.AddTransient<IAssignmentRepo, AssignmentRepo>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//swagger 
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
